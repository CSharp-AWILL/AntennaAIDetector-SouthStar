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

        private void RefreshStatusStrip()
        {
            this.labelResult.Text = _defaultView.GetResultInfo();
            this.labelRunTime.Text = _defaultView.TimeInfo;

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
            _defaultView.Process();
            _paramView.RefreshControl();
            RefreshStatusStrip();

            return;
        }

        #endregion
    }
}
