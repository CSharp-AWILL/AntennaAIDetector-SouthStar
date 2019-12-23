using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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

            }

            _device.LoadConfiguration();

            return;
        }

        public void Run()
        {
            if (null != ImageIn)
            {
                MessageManager.Instance().Info("++++++Producer.Run(): begin.");
                lock (TaskPool.PAD_LOCK)
                {
                    _device.TryPushImages(ImageIn);
                }
                MessageManager.Instance().Info("++++++Producer.Run(): end.");

                DisplayShapes = new List<AqShap>();
                if (IsDisplay)
                {
                    List<double> y = new List<double>();
                    List<double> x = new List<double>();
                    List<int> num = new List<int>();
                    for (int index = 0; index < _device.TaskSize; ++index)
                    {
                        ShapeOf2D.ConvertRectToShapeOf2D(Rectangle.Truncate(_device.Roi[index]), out var shapeOf2D);
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

            xmlParameter.WriteParameter(configFile);

            _device.SaveConfiguration();

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

        public void AddRect()
        {
            int y = 200 * (_device.TaskSize + 1);
            int width = null == ImageIn ? 100 : ImageIn.Width;
            var roi = new RectangleF((float)0, (float)y, (float)width, (float)100);

            _device.TryAddRoi(roi);

            return;
        }

        public void RemoveRect()
        {
            _device.TryRemoveRoi();

            return;
        }

        public void Test()
        {
            Run();
            for (int index = 0; index < _device.TaskSize; ++index)
            {
                _device.PopBitmap(index).Save("E:/xia-" + (index) + ".bmp");
            }

            return;
        }
    }
}
