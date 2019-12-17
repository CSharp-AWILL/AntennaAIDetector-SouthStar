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

namespace AntennaAIDetector_SouthStar.DataSave
{
    public partial class DataSaveForm : Form
    {
        private DataSave _dataSave = null;
        private string _header = "";

        private FilePathView _filePathView = null;

        public DataSaveForm(DataSave dataSave)
        {
            _dataSave = dataSave;
            InitializeComponent();
            LoadViews();
            DoDataBindings();
            RefreshDataGrid();
        }
        
        private void LoadViews()
        {
            _filePathView = new FilePathView(_dataSave);
            _filePathView.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(_filePathView);
            this.panel1.Hide();

            return;
        }

        private void DoDataBindings()
        {
            var mode = DataSourceUpdateMode.OnPropertyChanged | DataSourceUpdateMode.OnValidation;

            //
            this.numericUpDown_TimeSpanForNewFile.DataBindings.Add(new Binding("Text", _dataSave, "SpanOfTime", true, mode));
            this.numericUpDown_QueueSize.DataBindings.Add(new Binding("Text", _dataSave, "QueueSize", true, mode));

            return;
        }

        private void GetHeader()
        {
            _header = _dataSave.GetHeader();

            return;
        }

        private void RefreshDataGrid()
        {
            this.dataGridView_ResultDatas.Rows.Clear();

            GetHeader();
            var headerDetail = _header.Split(',');
            foreach (var tempColumnItem in headerDetail)
            {
                if (!string.IsNullOrWhiteSpace(tempColumnItem))
                {
                    this.dataGridView_ResultDatas.Columns.Add(tempColumnItem, tempColumnItem);
                }
            }

            foreach (var temp in _dataSave.ResultDatas)
            {
                var resultDetail = temp.Split(',');
                this.dataGridView_ResultDatas.Rows.Add(resultDetail);
            }

            return;
        }

        #region Event

        private void ToolStripMenuItem_PathSettingView_Click(object sender, EventArgs e)
        {
            if ("打开路径设置" == this.ToolStripMenuItem_PathSettingView.Text)
            {
                this.panel1.Show();
                this.ToolStripMenuItem_PathSettingView.Text = "关闭路径设置";
            }
            else
            {
                this.panel1.Hide();
                this.ToolStripMenuItem_PathSettingView.Text = "打开路径设置";
            }

            return;
        }

        #endregion
    }
}
