using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntennaAIDetector_SouthStar.Task.Spy
{
    public partial class SpyForm : Form
    {
        private Spy _spy = null;
        private readonly string[] _status = new string[2] { "非空", "空" };

        public SpyForm(Spy spy)
        {
            _spy = spy;
            InitializeComponent();
            InitializeComboxIndex(this.comboBox_IndexOfTask, _spy);
            DoDataBindings();
        }

        private void DoDataBindings()
        {
            var mode = DataSourceUpdateMode.OnPropertyChanged | DataSourceUpdateMode.OnValidation;

            this.comboBox_IndexOfTask.DataBindings.Add(new Binding("Text", _spy, "Index", true, mode));

            return;
        }

        private void InitializeComboxIndex(ComboBox comboBox, Spy spy)
        {
            comboBox.Items.Add("-1");
            for (int index = 0; index < spy.GetTaskSize(); ++index)
            {
                comboBox.Items.Add(index.ToString());
            }
            spy.Index = Math.Min(spy.Index, spy.GetTaskSize() - 1);

            return;
        }

        #region Event

        private void comboBox_IndexOfTask_TextChanged(object sender, EventArgs e)
        {
            var isEmpty = _spy.IsTaskQueueEmpty();
            _spy.IsEmpty = isEmpty ? "OK" : "NG";
            this.label_Status.Text = _status[Convert.ToInt32(_spy.IsTaskQueueEmpty())];

            return;
        }

        #endregion

    }
}
