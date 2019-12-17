using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntennaAIDetector_SouthStar.View
{
    public partial class FilePathView : UserControl
    {
        private DataSave.DataSave _dataSave = null;

        public FilePathView(DataSave.DataSave dataSave)
        {
            _dataSave = dataSave;
            InitializeComponent();
            DoDataBindings();
        }

        private void DoDataBindings()
        {
            var mode = DataSourceUpdateMode.OnPropertyChanged | DataSourceUpdateMode.OnValidation;

            //
            this.textBoxDirPath.DataBindings.Add(new Binding("Text", _dataSave, "DirectoryPath", true, mode));
            this.textBoxFileName.DataBindings.Add(new Binding("Text", _dataSave, "CodeOfProduct", true, mode));

            return;
        }

        #region Event

        private void btnOpenDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = "选择文件存放目录";
            folder.RootFolder = Environment.SpecialFolder.MyComputer;
            if (folder.ShowDialog() == DialogResult.OK)
            {
                _dataSave.DirectoryPath = folder.SelectedPath;
                this.textBoxDirPath.Text = _dataSave.DirectoryPath;
            }

            return;
        }

        private void btnClearText_Click(object sender, EventArgs e)
        {
            this.textBoxFileName.Clear();
            _dataSave.CodeOfProduct = "";
        }

        #endregion
    }
}
