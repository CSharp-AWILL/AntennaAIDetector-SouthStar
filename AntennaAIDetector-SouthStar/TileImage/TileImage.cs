using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Aqrose.Framework.Core.Attributes;
using Aqrose.Framework.Core.DataType;
using Aqrose.Framework.Core.Interface;
using Aqrose.Framework.Utility.MessageManager;

namespace AntennaAIDetector_SouthStar.TileImage
{
    [Module("TileImage", "AntennaAIDetector", "")]
    public class TileImage : ModuleData, IModule
    {
        private Bitmap _wholeImage = null;
        private List<Bitmap> _singleImages = new List<Bitmap>();

        [InputData]
        public Bitmap ImageIn { get; set; } = null;

        public TileImage()
        {
        }

        private void TileSingleImages()
        {
            int count = 0;

            _wholeImage = null;

            if (null == _singleImages)
            {
                return;
            }

            count = _singleImages.Count;
            if (0 > count)
            {
                return;
            }

            //
            var singleImage = _singleImages[0];
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
                    singleImage = _singleImages[index];
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
            if (null == ImageIn)
            {
                return;
            }
            _singleImages.Add(ImageIn);
            _singleImages.Add(ImageIn);
            TileSingleImages();
            _wholeImage.Save("E://a.bmp");

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
