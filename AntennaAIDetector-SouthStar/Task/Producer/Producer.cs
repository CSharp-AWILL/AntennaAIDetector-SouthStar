using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SimpleGroup.Core.Struct;
using Aqrose.Framework.Core.Attributes;
using Aqrose.Framework.Core.DataType;
using Aqrose.Framework.Core.Interface;
using Aqrose.Framework.Utility.MessageManager;
using Aqrose.Framework.Utility.Tools;
using AqVision.Graphic.AqVision.shape;

namespace AntennaAIDetector_SouthStar.Task.Producer
{
    [Module("Producer", "AntennaAIDetector", "")]
    public class Producer : ModuleData, IModule, IDisplay
    {
        private Task _device = null;
        private List<Bitmap> _images = new List<Bitmap>();

        [InputData]
        public Bitmap ImageIn { get; set; } = null;
        public int Number { get; set; } = 0;
        public Rectangle[] Rects { get; set; } = new Rectangle[6]
        {
            Rectangle.Empty, Rectangle.Empty, Rectangle.Empty,
            Rectangle.Empty, Rectangle.Empty, Rectangle.Empty
        };

        #region IDisplay

        public Bitmap DisplayBitmap { get; set; } = null;
        public List<AqShap> DisplayShapes { get; set; } = new List<AqShap>();
        public string DisplayWindowName { get; set; } = "Image0";
        public bool IsDisplay { get; set; } = true;
        public bool IsUpdate { get; set; } = false;

        #endregion

        public Producer()
        {
            _device = TaskPool.GetInstance();
        }

        private void SetTask()
        {
            _device.SetTaskSize(Number);

            return;
        }

        private Bitmap CropImage(Bitmap src, Rectangle roi)
        {
            if (null == src || null == roi || Rectangle.Empty == roi)
            {
                return null;
            }

            //
            roi.X = Math.Max(roi.X, 0);
            roi.Y = Math.Max(roi.Y, 0);
            roi.Width = Math.Max(roi.Width, 0);
            roi.Height = Math.Max(roi.Height, 0);
            //
            roi.X = Math.Min(roi.X, src.Width);
            roi.Y = Math.Min(roi.Y, src.Height);
            roi.Width = Math.Min(roi.Width, src.Width - roi.X);
            roi.Height = Math.Min(roi.Height, src.Height - roi.Y);
            ImageOperateTools.BitmapCropImage(src, roi, out var res);

            return res;
            // slow
            //return src.Clone(roi, System.Drawing.Imaging.PixelFormat.DontCare);
        }

        #region IModule

        public void CloseModule()
        {
            //throw new NotImplementedException();
        }

        public void InitModule(string projectDirectory, string nodeName)
        {
            string configFile = projectDirectory + @"\Producer-" + nodeName + ".xml";
            string strParamInfo = "";
            XmlParameter xmlParameter = null;
            if (File.Exists(configFile))
            {
                xmlParameter = new XmlParameter();
                xmlParameter.ReadParameter(configFile);

                #region IDisplay

                strParamInfo = xmlParameter.GetParamData("DisplayWindowName");
                if (strParamInfo != "")
                {
                    DisplayWindowName = strParamInfo;
                }
                strParamInfo = xmlParameter.GetParamData("IsDisplay");
                if (strParamInfo != "")
                {
                    IsDisplay = Convert.ToBoolean(strParamInfo);
                }

                #endregion

                //
                strParamInfo = xmlParameter.GetParamData("Number");
                if (strParamInfo != "")
                {
                    Number = Convert.ToInt32(strParamInfo);
                }
                SetTask();  // attention
                for (int index = 0; index < Rects.Length; ++index)
                {
                    string param = "Rect-" + index;
                    strParamInfo = xmlParameter.GetParamData(param + "-X");
                    if (strParamInfo != "")
                    {
                        Rects[index].X = Convert.ToInt32(strParamInfo);
                    }
                    strParamInfo = xmlParameter.GetParamData(param + "-Y");
                    if (strParamInfo != "")
                    {
                        Rects[index].Y = Convert.ToInt32(strParamInfo);
                    }
                    strParamInfo = xmlParameter.GetParamData(param + "-Width");
                    if (strParamInfo != "")
                    {
                        Rects[index].Width = Convert.ToInt32(strParamInfo);
                    }
                    strParamInfo = xmlParameter.GetParamData(param + "-Height");
                    if (strParamInfo != "")
                    {
                        Rects[index].Height = Convert.ToInt32(strParamInfo);
                    }
                }
            }

            return;
        }

        public void Run()
        {
            if (null != ImageIn)
            {
                var temp = CropImage();

                MessageManager.Instance().Info("++++++Producer.Run(): begin.");
                lock (TaskPool.PAD_LOCK)
                {
                    _device.OriginImages.Add(ImageIn);
                    _device.TryPushImages(temp);
                }
                MessageManager.Instance().Info("++++++Producer.Run(): end.");

                DisplayShapes = new List<AqShap>();
                if (IsDisplay)
                {
                    List<double> y = new List<double>();
                    List<double> x = new List<double>();
                    List<int> num = new List<int>();
                    for (int index = 0; index < Number; ++index)
                    {
                        ShapeOf2D.ConvertRectToShapeOf2D(Rects[index], out var shapeOf2D);
                        y.AddRange(shapeOf2D.XldPointYs);
                        x.AddRange(shapeOf2D.XldPointXs);
                        num.AddRange(shapeOf2D.XldPointsNums);
                    }
                    DisplayContour.GetContours(y, x, num, out var contours, AqVision.Graphic.AqColorEnum.Yellow, 2);
                    DisplayShapes = contours;

                    IsUpdate = true;
                }
                else
                {
                    IsUpdate = false;
                }

                IsResultOK = true;
            }

            return;
        }

        public void SaveModule(string projectDirectory, string nodeName)
        {
            string configFile = projectDirectory + @"\Producer-" + nodeName + ".xml";
            XmlParameter xmlParameter = new XmlParameter();

            #region IDisplay

            xmlParameter.Add("DisplayWindowName", DisplayWindowName);
            xmlParameter.Add("IsDisplay", IsDisplay);

            #endregion

            //
            xmlParameter.Add("Number", Number);
            for (int index = 0; index < Rects.Length; ++index)
            {
                string param = "Rect-" + index;
                xmlParameter.Add(param+"-X", Rects[index].X);
                xmlParameter.Add(param+"-Y", Rects[index].Y);
                xmlParameter.Add(param+"-Width", Rects[index].Width);
                xmlParameter.Add(param+"-Height", Rects[index].Height);
            }

            xmlParameter.WriteParameter(configFile);

            return;
        }

        public bool StartSetForm()
        {
            var form = new ProducerForm(this);
            form.ShowDialog();
            form.Close();

            return true;
        }

        #endregion

        public List<Bitmap> CropImage()
        {
            List<Bitmap> res = new List<Bitmap>();
            for (int index = 0; index < Number; ++index)
            {
                res.Add(CropImage(ImageIn, Rects[index]));
            }

            return res;
        }

        public void AddRect()
        {
            int y = 200 * (Number++);
            int width = null == ImageIn ? 100 : ImageIn.Width;

            Rects[Number-1]=new Rectangle(0, y, width, 100);
            SetTask();

            return;
        }

        public void RemoveRect()
        {
            Rects[--Number] = Rectangle.Empty;
            SetTask();

            return;
        }

        public int GetTaskSize()
        {
            if (null == _device)
            {
                MessageManager.Instance().Warn("Consumer: _device is null.");

                return 0;
            }

            return _device.GetTaskSize();
        }
    }
}
