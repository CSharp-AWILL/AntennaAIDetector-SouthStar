using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aqrose.Framework.Utility.Tools;

namespace AntennaAIDetector_SouthStar.View
{
    public partial class TaskSizeForm : Form
    {
        private int _taskSize = 3;

        public TaskSizeForm()
        {
            InitializeComponent();
            LoadConfiguration();
        }

        private void LoadConfiguration()
        {
            string info = "";
            XmlParameter xmlParameter = new XmlParameter();

            xmlParameter.ReadParameter(Application.StartupPath + @"\ParamFile.xml");
            info = xmlParameter.GetParamData("TaskSize");
            if (!string.IsNullOrWhiteSpace(info))
            {
                _taskSize = Convert.ToInt32(info);
            }

            this.numericUpDown_TaskSize.Value = _taskSize;

            return;
        }

        private void SaveConfiguration()
        {
            XmlParameter xmlParameter = new XmlParameter();

            xmlParameter.Add("TaskSize", _taskSize);
            xmlParameter.WriteParameter(Application.StartupPath + @"\ParamFile.xml");

            return;
        }

        #region Event

        private void button_Ensure_Click(object sender, EventArgs e)
        {
            SaveConfiguration();

            this.Close();

            return;
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();

            return;
        }

        #endregion
    }
}
