using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
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
        private Bitmap _wholeImage = null;
        private ShapeOf2D _singleRois = new ShapeOf2D();
        private List<Bitmap> _originImages { get; set; } = new List<Bitmap>();

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
        }

        private void TileSingleImages()
        {
            int count = 0;

            _wholeImage = null;

            if (null == _originImages)
            {
                return;
            }

            count = _originImages.Count;
            if (0 > count)
            {
                return;
            }

            //
            var singleImage = _originImages[0];
            var bitmapDataOfSingleImage = singleImage.LockBits(new Rectangle(0, 0, singleImage.Width, singleImage.Height), ImageLockMode.ReadOnly, singleImage.PixelFormat);
            var ptrOfSingleImage = bitmapDataOfSingleImage.Scan0;
            int bytesOfSingleImage = Math.Abs(bitmapDataOfSingleImage.Stride) * singleImage.Height;
            int bytesOfWholeImage = bytesOfSingleImage * count;
            byte[] byteValuesOfSingleImage = new byte[bytesOfSingleImage];
            byte[] byteValuesOfWholeImage = new byte[bytesOfWholeImage];

            _wholeImage = new Bitmap(singleImage.Width, singleImage.Height * count, singleImage.PixelFormat);
            var bitmapDataOfWholeImage = _wholeImage.LockBits(new Rectangle(0, 0, _wholeImage.Width, _wholeImage.Height), ImageLockMode.ReadWrite, _wholeImage.PixelFormat);
            var ptrOfWholeImage = bitmapDataOfWholeImage.Scan0;
            singleImage.UnlockBits(bitmapDataOfSingleImage);

            try
            {
                for (int index = 0; index < count; ++index)
                {
                    singleImage = _originImages[index];
                    bitmapDataOfSingleImage = singleImage.LockBits(new Rectangle(0, 0, singleImage.Width, singleImage.Height), ImageLockMode.ReadOnly, singleImage.PixelFormat);
                    ptrOfSingleImage = bitmapDataOfSingleImage.Scan0;
                    Marshal.Copy(ptrOfSingleImage, byteValuesOfSingleImage, 0, bytesOfSingleImage);
                    byteValuesOfSingleImage.CopyTo(byteValuesOfWholeImage, index * bytesOfSingleImage);
                    singleImage.UnlockBits(bitmapDataOfSingleImage);
                }
            }
            catch (Exception ex)
            {
                _wholeImage = null;
                MessageManager.Instance().Warn("TileImage.TileSingleImages error: " + ex.Message);
            }
            finally
            {
                //
                Marshal.Copy(byteValuesOfWholeImage, 0, ptrOfWholeImage, bytesOfWholeImage);
                _wholeImage.UnlockBits(bitmapDataOfWholeImage);
            }

            return;
        }

        private void GetSingleRois()
        {
            List<RectangleF> rectangles = new List<RectangleF>();
            _singleRois = new ShapeOf2D();

            if (null == _originImages)
            {
                return;
            }

            for (int index = 0; index < _originImages.Count; ++index)
            {
                var singleImage = _originImages[index];
                var roi = new RectangleF((float)0, (float)0, (float)singleImage.Width, (float)singleImage.Height);
                var center = new PointF((float)(singleImage.Width / 2.0), (float)(singleImage.Height / 2.0));
                var offset = new PointF((float)0, (float)(singleImage.Height * index));
                roi.Offset(offset);
                center.X += offset.X;
                center.Y += offset.Y;

                ShapeOf2D.ConvertRectToShapeOf2D(Rectangle.Truncate(roi), out var edgeOfRoi);
                ShapeOf2D.ConverPoint2DToCross(new PointF(roi.X, roi.Y), 50, out var ltOfRoi);
                ShapeOf2D.ConverPoint2DToCross(new PointF(roi.X + roi.Width, roi.Y), 50, out var rtOfRoi);
                ShapeOf2D.ConverPoint2DToCross(new PointF(roi.X, roi.Y + roi.Height), 50, out var lbOfRoi);
                ShapeOf2D.ConverPoint2DToCross(new PointF(roi.X + roi.Width, roi.Y + roi.Height), 50, out var rbOfRoi);
                ShapeOf2D.ConverPoint2DToCross(center, 20, out var centerOfRoi);

                _singleRois += ltOfRoi;
                _singleRois += rtOfRoi;
                _singleRois += lbOfRoi;
                _singleRois += rbOfRoi;
                _singleRois += centerOfRoi;
            }

            return;
        }

        #region IModule

        public void CloseModule()
        {
            //throw new NotImplementedException();
        }

        public void InitModule(string projectDirectory, string nodeName)
        {
            //throw new NotImplementedException();
        }

        public void Run()
        {
            //throw new NotImplementedException();
            _wholeImage = null;
            _originImages = new List<Bitmap>();

            MessageManager.Instance().Info("++++++TileImage.Run(): begin.");
            lock (Task.TaskPool.PadLock)
            {
                if (null != _device && null != _device.OriginImages && 0 < _device.OriginImages.Count)
                {
                    _originImages = _device.OriginImages;
                    _device.OriginImages.Clear();
                }
            }
            TileSingleImages();
            GetSingleRois();
            MessageManager.Instance().Info("++++++TileImage.Run(): end.");

            //
            DisplayBitmap = null;
            DisplayShapes = new List<AqShap>();
            if (IsDisplay)
            {
                DisplayBitmap = _wholeImage;
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
            //throw new NotImplementedException();
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
    }
}
