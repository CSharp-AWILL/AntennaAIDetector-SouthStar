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
        private Task.Task _device = null;

        public TaskModeForm()
        {
            _device = Task.TaskPool.GetInstance();
            InitializeComponent();
            DoDataBindings();
        }

        private void DoDataBindings()
        {
            var mode = DataSourceUpdateMode.OnPropertyChanged | DataSourceUpdateMode.OnValidation;

            //
            this.numericUpDown_TaskSize.DataBindings.Add(new Binding("Text", _device, "TaskSize", true, mode));
            this.numericUpDown_TotalSize.DataBindings.Add(new Binding("Text", _device, "TotalSize", true, mode));

            return;
        }

        #region Event

        private void button_Ensure_Click(object sender, EventArgs e)
        {
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
