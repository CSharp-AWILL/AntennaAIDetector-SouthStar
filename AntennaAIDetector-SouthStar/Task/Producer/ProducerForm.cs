using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleGroup.Core.Struct;
using Aqrose.Framework.Utility.Tools;
using Aqrose.Framework.Utility.WindowConfig;
using AntennaAIDetector_SouthStar.View;

namespace AntennaAIDetector_SouthStar.Task.Producer
{
    public partial class ProducerForm : Form
    {
        private Task _device = null;
        private Producer _producer = null;
        private NumericUpDown[,] _numericUpDown;
        private Panel[] _panel;

        private AqVision.Graphic.AqColorEnum[] _aqColor = new AqVision.Graphic.AqColorEnum[6]
        {
            AqVision.Graphic.AqColorEnum.Blue,
            AqVision.Graphic.AqColorEnum.DarkRed,
            AqVision.Graphic.AqColorEnum.Green,
            AqVision.Graphic.AqColorEnum.Orange,
            AqVision.Graphic.AqColorEnum.Yellow,
            AqVision.Graphic.AqColorEnum.Red
        };
        private Color[] _color = new Color[6]
        {
            Color.Blue,
            Color.DarkRed,
            Color.Green,
            Color.Orange,
            Color.Yellow,
            Color.Red
        };

        public ProducerForm(Producer producer)
        {
            _device = TaskPool.GetInstance();
            _producer = producer;
            InitializeComponent();
            InitializeComboxWndName(this.comboBoxDisplayWindowName, _producer.DisplayWindowName);
            MergeControls();
            RefreshControls();
            DoDataBindings();
            FormRefresh(true);
            DoDelegateOfControl();
        }

        private void MergeControls()
        {
            _numericUpDown = new NumericUpDown[6, 4]
            {
                { this.numericUpDown_L0, this.numericUpDown_U0, this.numericUpDown_W0, this.numericUpDown_H0},
                { this.numericUpDown_L1, this.numericUpDown_U1, this.numericUpDown_W1, this.numericUpDown_H1},
                { this.numericUpDown_L2, this.numericUpDown_U2, this.numericUpDown_W2, this.numericUpDown_H2},
                { this.numericUpDown_L3, this.numericUpDown_U3, this.numericUpDown_W3, this.numericUpDown_H3},
                { this.numericUpDown_L4, this.numericUpDown_U4, this.numericUpDown_W4, this.numericUpDown_H4},
                { this.numericUpDown_L5, this.numericUpDown_U5, this.numericUpDown_W5, this.numericUpDown_H5},
            };

            _panel = new Panel[6] { flowLayoutPanel_Rect0, flowLayoutPanel_Rect1, flowLayoutPanel_Rect2, flowLayoutPanel_Rect3, flowLayoutPanel_Rect4, flowLayoutPanel_Rect5 };

            return;
        }

        private void DoDelegateOfControl()
        {
            for (int i = 0; i < 6; ++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    _numericUpDown[i,j].Click+= new System.EventHandler(this.numericUpDown_ValueChanged);
                }
            }
            this.button_AddRect.Click += new System.EventHandler(this.button_Click);
            this.button_RemoveRect.Click+=new System.EventHandler(this.button_Click);

            return;
        }

        private void DoDataBindings()
        {
            var mode = DataSourceUpdateMode.OnPropertyChanged | DataSourceUpdateMode.OnValidation;

            //
            this.comboBoxDisplayWindowName.DataBindings.Add(new Binding("Text", _producer, "DisplayWindowName", true, mode));
            this.checkBoxShow.DataBindings.Add(new Binding("Checked", _producer, "IsDisplay", true, mode));

            return;
        }

        private void RefreshControls()
        {
            //
            this.button_RemoveRect.Enabled = 0 != _device.TaskSize;
            this.button_AddRect.Enabled = _device.Roi.Length > _device.TaskSize;

            //
            for (int index = _device.TaskSize; index < _panel.Length; ++index)
            {
                _panel[index].Hide();
            }
            for (int index = _device.TaskSize - 1; index >= 0; --index)
            {
                _panel[index].Show();
                _panel[index].BorderStyle = BorderStyle.FixedSingle;
                for (int j = 0; j < 4; ++j)
                {
                    _numericUpDown[index, j].ForeColor = _color[index];
                }
            }

            //
            for (int index = 0; index < _device.Roi.Length; ++index)
            {
                _numericUpDown[index, 0].Value = Convert.ToDecimal(_device.Roi[index].X);
                _numericUpDown[index, 1].Value = Convert.ToDecimal(_device.Roi[index].Y);
                _numericUpDown[index, 2].Value = Convert.ToDecimal(_device.Roi[index].Width);
                _numericUpDown[index, 3].Value = Convert.ToDecimal(_device.Roi[index].Height);
            }

            return;
        }

        private void UpdateRects()
        {
            //
            for (int index = 0; index < _device.Roi.Length; ++index)
            {
                _device.Roi[index].X = Convert.ToInt32(_numericUpDown[index, 0].Value);
                _device.Roi[index].Y = Convert.ToInt32(_numericUpDown[index, 1].Value);
                _device.Roi[index].Width = Convert.ToInt32(_numericUpDown[index, 2].Value);
                _device.Roi[index].Height = Convert.ToInt32(_numericUpDown[index, 3].Value);
            }

            return;
        }

        private void FormRefresh(bool isAutoFit)
        {
            this.aqDisplay1.InteractiveGraphics.Clear();
            if (null != _producer.ImageIn)
            {
                this.aqDisplay1.Image = _producer.ImageIn.Clone() as Bitmap;
                if (_producer.IsDisplay)
                {
                    for (int index = 0; index < _device.TaskSize; ++index)
                    {
                        ShapeOf2D.ConvertRectToShapeOf2D(Rectangle.Truncate(_device.Roi[index]), out var shapeOf2D);
                        DisplayContour.GetContours(shapeOf2D.XldPointYs, shapeOf2D.XldPointXs, shapeOf2D.XldPointsNums, out var contours, _aqColor[index], 2);
                        DisplayContour.Display(this.aqDisplay1, contours);
                    }
                }
            }

            if (isAutoFit)
            {
                this.aqDisplay1.FitToScreen();
            }
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
            _producer.DisplayWindowName = windowNameList.Contains(windowName) ? windowName : windowNameList[0];

            return;
        }

        #region Event

        private void numericUpDown_ValueChanged(object sender, System.EventArgs e)
        {
            UpdateRects();
            FormRefresh(false);

            return;
        }

        private void button_Click(object sender, System.EventArgs e)
        {
            RefreshControls();
            FormRefresh(true);

            return;
        }

        private void button_AddRect_Click(object sender, EventArgs e)
        {
            _producer.AddRect();

            return;
        }

        private void button_RemoveRect_Click(object sender, EventArgs e)
        {
            _producer.RemoveRect();

            return;
        }

        private void button_Test_Click(object sender, EventArgs e)
        {
            _producer.Test();

            return;
        }

        private void button_SetTaskMode_Click(object sender, EventArgs e)
        {
            var form = new TaskModeForm();
            form.ShowDialog();

            return;
        }

        #endregion

    }
}
