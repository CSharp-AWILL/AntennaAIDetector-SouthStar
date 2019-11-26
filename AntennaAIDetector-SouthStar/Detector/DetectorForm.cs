using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AntennaAIDetector_SouthStar.View;
using Aqrose.Framework.Core.DataType;
using Aqrose.Framework.Utility.Tools;

namespace AntennaAIDetector_SouthStar.Detector
{
    public partial class DetectorForm : Form
    {
        private Detector _detector = null;
        private DefaultView _defaultView = null;
        private ParamView _paramView = null;
        public DetectorForm(Detector detector)
        {
            _detector = detector;
            InitializeComponent();
            LoadViews();
            RefreshStatusStrip();
        }

        private void LoadViews()
        {
            _defaultView = new DefaultView(_detector);
            _defaultView.Dock = DockStyle.Fill;
            this.panelOfDefaultView.Controls.Add(_defaultView);
            _paramView = new ParamView(_detector.ProductManager);
            _paramView.Dock = DockStyle.Fill;
            this.panelOfParamView.Controls.Add(_paramView);
            this.panelOfParamView.Hide();

            return;
        }

        private void RefreshStatusStrip(double time = 0.0)
        {
            string resultInfo = "";

            this.labelResult.Text = "";
            this.labelRunTime.Text = "";
            foreach (var result in _detector.ProductManager.Result)
            {
                resultInfo += (EnumTools.GetDescription(result) + "  ");
            }
            this.labelResult.Text = "运行结果：" + resultInfo;
            this.labelResult.ForeColor = _detector.ProductManager.IsResultOK ? Color.Blue : Color.Red;
            this.labelRunTime.Text = "运行时间：" + time.ToString() + " ms";

            return;
        }

        #region Event

        private void ToolStripMenuItem_ParamView_Click(object sender, EventArgs e)
        {
            if ("打开参数设置" == this.ToolStripMenuItem_ParamView.Text)
            {
                this.panelOfParamView.Show();
                this.ToolStripMenuItem_ParamView.Text = "关闭参数设置";
            }
            else
            {
                this.panelOfParamView.Hide();
                this.ToolStripMenuItem_ParamView.Text = "打开参数设置";
            }

            return;
        }

        private void ToolStripMenuItem_Run_Click(object sender, EventArgs e)
        {
            RunTime runTime = new RunTime();
            double time;
            if (null == _detector.ImageIn)
            {
                MessageBox.Show("DetectorForm: 当前无图像！");

                return;
            }
            
            runTime.LogStartRunTime();
            _detector.Process();
            runTime.LogEndRunTime();
            runTime.GetRunTime(out time);

            _defaultView.Refresh();
            RefreshStatusStrip(time);

            return;
        }

        #endregion
    }
}
