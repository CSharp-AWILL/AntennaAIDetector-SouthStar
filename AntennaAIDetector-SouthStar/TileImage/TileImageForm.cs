using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntennaAIDetector_SouthStar.TileImage
{
    public partial class TileImageForm : Form
    {
        private TileImage _tileImage = null;
        private Bitmap _currImage = null;
        public TileImageForm(TileImage tileImage)
        {
            _tileImage = tileImage;
            InitializeComponent();
        }

        private void FormRefresh()
        {
            if (null != _tileImage.SingleImage && null == _tileImage.WholeImage)
            {
                _currImage = _tileImage.SingleImage.Clone() as Bitmap;
            }
            if (null != _tileImage.WholeImage)
            {
                _currImage = _tileImage.WholeImage.Clone() as Bitmap;
            }

            this.aqDisplay1.InteractiveGraphics.Clear();
            if (null != _currImage)
            {
                this.aqDisplay1.Image = _currImage;
            }

            this.aqDisplay1.FitToScreen();
            this.aqDisplay1.Update();

            return;
        }

        #region Event

        private void button1_Click(object sender, EventArgs e)
        {
            _tileImage.Run();
        }

        private void button_LoadSingleImage_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Multiselect = false;
            dlg.Title = "请选择模板图片";
            dlg.Filter = "模板图片(*.bmp)|*.bmp";
            dlg.InitialDirectory = Application.StartupPath + @"\Images";
            dlg.RestoreDirectory = true;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string filePath = dlg.FileName;
                if (File.Exists(filePath))
                {
                    Bitmap bitmap = new Bitmap(filePath, true);
                    _tileImage.SingleImage = bitmap.Clone() as Bitmap;
                    _tileImage.SingleImages = new List<Bitmap>();
                    for (int index = 0; index < _tileImage.CurrTotalSize; ++index)
                    {
                        _tileImage.SingleImages.Add(_tileImage.SingleImage);
                    }
                    // attention
                    _tileImage.WholeImage = null;
                    bitmap.Dispose();
                    this.aqDisplay1.InteractiveGraphics.Clear();
                    FormRefresh();
                }
            }

            return;
        }

        private void button_TileSingleImages_Click(object sender, EventArgs e)
        {
            _tileImage.WholeImage = null;
            if (null == _tileImage.SingleImage)
            {
                MessageBox.Show("没有拼接模型图像！");

                return;
            }
            if (null == _tileImage.SingleImages || 0 >= _tileImage.SingleImages.Count)
            {
                _tileImage.SingleImages = new List<Bitmap>();
                for (int index = 0; index < _tileImage.CurrTotalSize; ++index)
                {
                    _tileImage.SingleImages.Add(_tileImage.SingleImage);
                }
            }
            _tileImage.TileSingleImages(_tileImage.SingleImages, out var wholeImage);
            if (null == wholeImage)
            {
                MessageBox.Show("拼接模型出错！");

                return;
            }
            _tileImage.WholeImage = wholeImage.Clone() as Bitmap;

            FormRefresh();

            return;
        }

        private void button_DisplayResult_Click(object sender, EventArgs e)
        {
            if (null == _tileImage.WholeImage)
            {
                MessageBox.Show("请先拼接模型！");

                return;
            }

            return;
        }

        #endregion
    }
}
