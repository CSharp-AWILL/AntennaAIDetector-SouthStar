using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntennaAIDetector_SouthStar.DataSave
{
    public partial class DataSaveForm : Form
    {
        private DataSave _dataSave = null;
        private string _header = "";
        public DataSaveForm(DataSave dataSave)
        {
            _dataSave = dataSave;
            InitializeComponent();
            GetHeader();
            RefreshDataGrid();
        }

        private void GetHeader()
        {
            _header = _dataSave.GetHeader();

            return;
        }

        private void RefreshDataGrid()
        {
            this.dataGridView_ResultDatas.Rows.Clear();

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
    }
}
