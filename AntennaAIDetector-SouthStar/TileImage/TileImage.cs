using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using AntennaAIDetector_SouthStar.Result;
using Aqrose.Framework.Core.Attributes;
using Aqrose.Framework.Core.DataType;
using Aqrose.Framework.Core.Interface;
using Aqrose.Framework.Utility.MessageManager;
using Aqrose.Framework.Utility.Tools;
using AqVision.Graphic.AqVision.shape;
using SimpleGroup.Core.Struct;

namespace AntennaAIDetector_SouthStar.TileImage
{
    [Module("TileImage", "AntennaAIDetector", "")]
    public class TileImage : ModuleData, IModule, IDisplay
    {
        private Task.Task _device = null;
        private ResultDevice _result = null;
        private ShapeOf2D _singleRois = new ShapeOf2D();

        public int CurrTotalSize { get; set; } = 0;
        public Bitmap SingleImage { get; set; } = null;
        public Bitmap WholeImage { get; set; } = null;
        public List<Bitmap> SingleImages { get; set; } = new List<Bitmap>();

        #region IDisplay

        public Bitmap DisplayBitmap { get; set; } = null;
        public List<AqShap> DisplayShapes { get; set; } = new List<AqShap>();
        public string DisplayWindowName { get; set; } = "Image0";
        public bool IsDisplay { get; set; } = true;
        public bool IsUpdate { get; set; } = false;

        #endregion

        public TileImage()
        {
            _device = Task.TaskPool.GetInstance();
            _result = ResultDevice.GetInstance();
            CurrTotalSize = _device.TotalSize;
        }

        //private void GetSingleRois()
        //{
        //    List<RectangleF> rectangles = new List<RectangleF>();
        //    _singleRois = new ShapeOf2D();

        //    if (null == _originImages)
        //    {
        //        return;
        //    }

        //    for (int index = 0; index < _originImages.Count; ++index)
        //    {
        //        var singleImage = _originImages[index];
        //        var roi = new RectangleF((float)0, (float)0, (float)singleImage.Width, (float)singleImage.Height);
        //        var center = new PointF((float)(singleImage.Width / 2.0), (float)(singleImage.Height / 2.0));
        //        var offset = new PointF((float)0, (float)(singleImage.Height * index));
        //        roi.Offset(offset);
        //        center.X += offset.X;
        //        center.Y += offset.Y;

        //        ShapeOf2D.ConvertRectToShapeOf2D(Rectangle.Truncate(roi), out var edgeOfRoi);
        //        ShapeOf2D.ConverPoint2DToCross(new PointF(roi.X, roi.Y), 50, out var ltOfRoi);
        //        ShapeOf2D.ConverPoint2DToCross(new PointF(roi.X + roi.Width, roi.Y), 50, out var rtOfRoi);
        //        ShapeOf2D.ConverPoint2DToCross(new PointF(roi.X, roi.Y + roi.Height), 50, out var lbOfRoi);
        //        ShapeOf2D.ConverPoint2DToCross(new PointF(roi.X + roi.Width, roi.Y + roi.Height), 50, out var rbOfRoi);
        //        ShapeOf2D.ConverPoint2DToCross(center, 20, out var centerOfRoi);

        //        _singleRois += ltOfRoi;
        //        _singleRois += rtOfRoi;
        //        _singleRois += lbOfRoi;
        //        _singleRois += rbOfRoi;
        //        _singleRois += centerOfRoi;
        //    }

        //    return;
        //}

        #region IModule

        public void CloseModule()
        {
            //throw new NotImplementedException();
        }

        public void InitModule(string projectDirectory, string nodeName)
        {
            string imageFilePath;

            imageFilePath = projectDirectory + @"\TileImage-" + nodeName + @".bmp";
            if (File.Exists(imageFilePath))
            {
                SingleImage = new Bitmap(imageFilePath, true);
            }
            else
            {
                SingleImage = new Bitmap(500, 100);
            }

            return;
        }

        public void Run()
        {
            //throw new NotImplementedException();
            //WholeImage = null;
            //_originImages = new List<Bitmap>();

            //MessageManager.Instance().Info("++++++TileImage.Run(): begin.");
            //lock (Task.TaskPool.PadLock)
            //{
            //    if (null != _device && null != _device.OriginImages && 0 < _device.OriginImages.Count)
            //    {
            //        foreach (var temp in _device.OriginImages)
            //        {
            //            _originImages.Add(_device.OriginImages.Dequeue());
            //        }
            //    }
            //}
            //TileSingleImages();
            //GetSingleRois();
            //MessageManager.Instance().Info("++++++TileImage.Run(): end.");

            //
            if (null == SingleImage)
            {
                MessageManager.Instance().Warn("TileImage.Run: lack of single image.");

                return;
            }
            if (_device.TotalSize != CurrTotalSize)
            {
                WholeImage = null;
                CurrTotalSize = _device.TotalSize;
                SingleImages = new List<Bitmap>();
                
            }
            if (null == SingleImages || 0 >= SingleImages.Count)
            {
                SingleImages = new List<Bitmap>();
                for (int index = 0; index < CurrTotalSize; ++index)
                {
                    SingleImages.Add(SingleImage);
                }
            }

            if (null == WholeImage)
            {
                TileSingleImages(SingleImages, out var wholeImage);
                if (null == wholeImage)
                {
                    MessageManager.Instance().Alarm("TileImage.Run: error in TileSingleImages.");

                    return;
                }
            }

            //
            DisplayBitmap = null;
            DisplayShapes = new List<AqShap>();
            if (IsDisplay)
            {
                DisplayBitmap = WholeImage;
                DisplayContour.GetContours(_singleRois.XldPointYs, _singleRois.XldPointXs, _singleRois.XldPointsNums, out var contours, AqVision.Graphic.AqColorEnum.Yellow, 1);
                DisplayShapes = contours;
                IsUpdate = true;
            }
            else
            {
                IsUpdate = false;
            }

            return;
        }

        public void SaveModule(string projectDirectory, string nodeName)
        {
            string imageFilePath;

            imageFilePath = projectDirectory + @"\TileImage-" + nodeName + @".bmp";
            if (SingleImage != null)
            {
                SingleImage.Save(imageFilePath, ImageFormat.Bmp);
            }

            return;
        }

        public bool StartSetForm()
        {
            TileImageForm form = null;
            if (null == this)
            {
                return false;
            }

            form = new TileImageForm(this);
            form.ShowDialog();
            form.Close();

            return true;
        }

        #endregion

        public void TileSingleImages(List<Bitmap> singleImages, out Bitmap wholeImage)
        {
            int count = 0;

            wholeImage = null;

            if (null == singleImages)
            {
                return;
            }

            count = singleImages.Count;
            if (0 > count)
            {
                return;
            }

            //
            var singleImage = singleImages[0];
            var bitmapDataOfSingleImage = singleImage.LockBits(new Rectangle(0, 0, singleImage.Width, singleImage.Height), ImageLockMode.ReadOnly, singleImage.PixelFormat);
            var ptrOfSingleImage = bitmapDataOfSingleImage.Scan0;
            int bytesOfSingleImage = Math.Abs(bitmapDataOfSingleImage.Stride) * singleImage.Height;
            int bytesOfWholeImage = bytesOfSingleImage * count;
            byte[] byteValuesOfSingleImage = new byte[bytesOfSingleImage];
            byte[] byteValuesOfWholeImage = new byte[bytesOfWholeImage];

            wholeImage = new Bitmap(singleImage.Width, singleImage.Height * count, singleImage.PixelFormat);
            var bitmapDataOfWholeImage = wholeImage.LockBits(new Rectangle(0, 0, wholeImage.Width, wholeImage.Height), ImageLockMode.ReadWrite, wholeImage.PixelFormat);
            var ptrOfWholeImage = bitmapDataOfWholeImage.Scan0;
            singleImage.UnlockBits(bitmapDataOfSingleImage);

            try
            {
                for (int index = 0; index < count; ++index)
                {
                    singleImage = singleImages[index];
                    bitmapDataOfSingleImage = singleImage.LockBits(new Rectangle(0, 0, singleImage.Width, singleImage.Height), ImageLockMode.ReadOnly, singleImage.PixelFormat);
                    ptrOfSingleImage = bitmapDataOfSingleImage.Scan0;
                    Marshal.Copy(ptrOfSingleImage, byteValuesOfSingleImage, 0, bytesOfSingleImage);
                    byteValuesOfSingleImage.CopyTo(byteValuesOfWholeImage, index * bytesOfSingleImage);
                    singleImage.UnlockBits(bitmapDataOfSingleImage);
                }
            }
            catch (Exception ex)
            {
                wholeImage = null;
                MessageManager.Instance().Warn("TileImage.TileSingleImages error: " + ex.Message);
            }
            finally
            {
                //
                Marshal.Copy(byteValuesOfWholeImage, 0, ptrOfWholeImage, bytesOfWholeImage);
                wholeImage.UnlockBits(bitmapDataOfWholeImage);
            }

            return;
        }

        public void GenerateResultDisplay(int stride, out List<AqShap> aqShaps)
        {
            string resultString = _result.ResultString;
            string prefix = "";
            aqShaps = new List<AqShap>();

            if (null == _device)
            {
                MessageManager.Instance().Warn("TileImage.GenerateResultDisplay: null _device");

                return;
            }
            prefix = "-" + _device.TotalSize + ":  ";

            if (string.IsNullOrWhiteSpace(resultString))
            {
                for (int index = 0; index < _device.TotalSize; ++index)
                {
                    var temp = index.ToString() + prefix + "NULL";
                    var displayChar = new DisplayChar();

                    displayChar.Text = temp;
                    displayChar.Size = new Size(200, 200);
                    displayChar.Position = new Point(100, index * stride);
                    displayChar.Color = Color.Yellow;
                    aqShaps.Add(displayChar.ConvertToAqCharacter());
                }
            }
            else
            {
                var info = resultString.Split(',');
                var lengthOfInfo = info.Length;
                var size = Math.Min(lengthOfInfo, _device.TotalSize);

                if (size <= 0)
                {
                    return;
                }

                for (int index = 0; index < size; ++index)
                {
                    var temp = index.ToString() + prefix + info[index];
                    var displayChar = new DisplayChar();

                    displayChar.Text = temp;
                    displayChar.Size = new Size(200, 200);
                    displayChar.Position = new Point(100, index * stride);
                    displayChar.Color = ("OK" != temp) ? Color.Red : Color.Green;
                    aqShaps.Add(displayChar.ConvertToAqCharacter());
                }
            }

            return;
        }
    }
}
