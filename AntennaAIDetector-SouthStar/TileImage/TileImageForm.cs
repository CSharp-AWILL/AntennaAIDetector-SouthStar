﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aqrose.Framework.Utility.Tools;
using Aqrose.Framework.Utility.WindowConfig;
using AqVision.Graphic.AqVision.shape;

namespace AntennaAIDetector_SouthStar.TileImage
{
    public partial class TileImageForm : Form
    {
        private TileImage _tileImage = null;
        private Bitmap _currImage = null;
        private List<AqShap> _currDisplayShape = new List<AqShap>();
        public TileImageForm(TileImage tileImage)
        {
            _tileImage = tileImage;
            InitializeComponent();
            DoDataBindings();
            if (null != _tileImage.DisplayShapes)
            {
                _currDisplayShape = _tileImage.DisplayShapes;
            }
            InitializeComboxWndName(this.comboBoxDisplayWindowName, _tileImage.DisplayWindowName);
            FormRefresh();
        }

        private void DoDataBindings()
        {
            var mode = DataSourceUpdateMode.OnPropertyChanged | DataSourceUpdateMode.OnValidation;

            //
            this.comboBoxDisplayWindowName.DataBindings.Add(new Binding("Text", _tileImage, "DisplayWindowName", true, mode));
            this.checkBoxShow.DataBindings.Add(new Binding("Checked", _tileImage, "IsDisplay", true, mode));

            this.numericUpDown_SizeOfText.DataBindings.Add(new Binding("Text", _tileImage, "SizeOfText", true, mode));

            return;
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
                if (null != _currDisplayShape)
                {
                    DisplayContour.Display(this.aqDisplay1, _currDisplayShape);
                }
            }

            this.aqDisplay1.FitToScreen();
            this.aqDisplay1.Update();

            return;
        }

        private void InitializeComboxWndName(ComboBox comboBox, string windowName)
        {
            comboBox.Items.Clear();
            WindowNum.Instance().GetWindowNameList(out var windowNameList);
            if (null == windowNameList)
            {
                return;
            }
            foreach (var obj in windowNameList)
            {
                comboBox.Items.Add(obj);
            }
            _tileImage.DisplayWindowName = windowNameList.Contains(windowName) ? windowName : windowNameList[0];

            return;
        }

        #region Event

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
            _currDisplayShape = new List<AqShap>();

            if (null == _tileImage.WholeImage)
            {
                MessageBox.Show("请先拼接模型！");

                return;
            }

            if (null == _tileImage.SingleImage)
            {
                MessageBox.Show("没有拼接模型！");

                return;
            }
            _tileImage.GenerateResultDisplay(_tileImage.SingleImage.Height, out _currDisplayShape);

            FormRefresh();

            return;
        }

        private void aqDisplay1_SizeChanged(object sender, EventArgs e)
        {
            FormRefresh();

            return;
        }

        #endregion


    }
}
