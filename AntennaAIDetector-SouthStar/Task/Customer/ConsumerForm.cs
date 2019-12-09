using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aqrose.Framework.Utility.WindowConfig;

namespace AntennaAIDetector_SouthStar.Task.Consumer
{
    public partial class ConsumerForm : Form
    {
        private Consumer _Consumer = null;
        public ConsumerForm(Consumer Consumer)
        {
            _Consumer = Consumer;
            InitializeComponent();
            InitializeComboxWndName(this.comboBoxDisplayWindowName, _Consumer.DisplayWindowName);
            InitializeComboxIndex(this.comboBox_Index, _Consumer);
            DoDataBindings();
            FormRefresh(true);
        }

        private void DoDataBindings()
        {
            var mode = DataSourceUpdateMode.OnPropertyChanged | DataSourceUpdateMode.OnValidation;

            this.comboBox_Index.DataBindings.Add(new Binding("Text", _Consumer, "Index", true, mode));

            //
            this.comboBoxDisplayWindowName.DataBindings.Add(new Binding("Text", _Consumer, "DisplayWindowName", true, mode));
            this.checkBoxShow.DataBindings.Add(new Binding("Checked", _Consumer, "IsDisplay", true, mode));

            return;
        }

        private void InitializeComboxIndex(ComboBox comboBox, Consumer Consumer)
        {
            for (int index = 0; index < Consumer.Amount; ++index)
            {
                comboBox.Items.Add(index.ToString());
            }
            Consumer.Index = Math.Min(Consumer.Index, Consumer.Amount);

            return;
        }

        private void FormRefresh(bool isAutoFit)
        {
            this.aqDisplay1.InteractiveGraphics.Clear();
            if (null != _Consumer.Image)
            {
                this.aqDisplay1.Image = _Consumer.Image.Clone() as Bitmap;
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
            _Consumer.DisplayWindowName = windowNameList.Contains(windowName) ? windowName : windowNameList[0];

            return;
        }

        #region Event

        private void button_Test_Click(object sender, EventArgs e)
        {
            if (!_Consumer.Test())
            {
                MessageBox.Show("无图像！");

                return;
            }

            FormRefresh(true);

            return;
        }

        #endregion
    }
}
