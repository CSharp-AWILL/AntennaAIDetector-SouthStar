using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntennaAIDetector_SouthStar.Result
{
    public partial class ResultForm : Form
    {
        private Result _result = null;
        public ResultForm(Result result)
        {
            _result = result;
            InitializeComponent();
            RefreshStatusStrip();
        }

        public void RefreshStatusStrip()
        {
            if (null == _result)
            {
                return;
            }

            this.toolStripStatusLabel_TaskModeInfo.Text = "当前模式：" + _result.TaskSize.ToString() + "-" + _result.TotalSize.ToString();
            if (null == _result.SingleResult)
            {
                this.label_SingleResult.Text = "空";
            }
            else
            {
                this.label_SingleResult.Text = "下标：" + _result.SingleResult.Index.ToString() + "-" + "结果信息：" + _result.SingleResult.DefectInfo;
            }

            return;
        }

        #region Event

        private void button_UpdateTaskMode_Click(object sender, EventArgs e)
        {
            _result.RetrieveTaskMode();
            RefreshStatusStrip();

            return;
        }

        #endregion

    }
}
