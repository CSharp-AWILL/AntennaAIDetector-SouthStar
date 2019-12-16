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
    public partial class TaskModeForm : Form
    {
        private static object _padLock = new object();

        public TaskModeForm()
        {
            InitializeComponent();
            LoadConfiguration(out var taskSize, out var totalSize);
            this.numericUpDown_TaskSize.Value = taskSize;
        }

        public static void LoadConfiguration(out int taskSize, out int totalSize)
        {
            string info = "";
            taskSize = 0;
            totalSize = 0;

            lock (_padLock)
            {
                XmlParameter xmlParameter = new XmlParameter();

                xmlParameter.ReadParameter(Application.StartupPath + @"\ParamFile.xml");
                info = xmlParameter.GetParamData("TaskSize");
                if (!string.IsNullOrWhiteSpace(info))
                {
                    taskSize = Convert.ToInt32(info);
                }

                xmlParameter.ReadParameter(Application.StartupPath + @"\ParamFile.xml");
                info = xmlParameter.GetParamData("TotalSize");
                if (!string.IsNullOrWhiteSpace(info))
                {
                    totalSize = Convert.ToInt32(info);
                }
            }
            return;
        }

        private void SaveConfiguration()
        {
            lock (_padLock)
            {
                XmlParameter xmlParameter = new XmlParameter();

                var info = this.numericUpDown_TaskSize.Value;
                xmlParameter.Add("TaskSize", Convert.ToInt32(info));

                info = this.numericUpDown_TotalSize.Value;
                xmlParameter.Add("TotalSize", Convert.ToInt32(info));

                xmlParameter.WriteParameter(Application.StartupPath + @"\ParamFile.xml");
            }

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
