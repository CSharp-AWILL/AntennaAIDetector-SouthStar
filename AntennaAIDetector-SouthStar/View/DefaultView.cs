using System.Drawing;
using System.Windows.Forms;
using AntennaAIDetector_SouthStar.Detector;
using Aqrose.Framework.Utility.WindowConfig;

namespace AntennaAIDetector_SouthStar.View
{
    public partial class DefaultView : UserControl
    {
        private Detector.Detector _detector = null;
        public DefaultView(Detector.Detector detector)
        {
            _detector = detector;
            InitializeComponent();
            DoDataBindings();
            InitializeComboxWndName(this.comboBoxDisplayWindowName, _detector.DisplayWindowName);
            FormRefresh(true);
        }

        private void DoDataBindings()
        {
            var mode = DataSourceUpdateMode.OnPropertyChanged | DataSourceUpdateMode.OnValidation;

            //
            this.checkBox_Defect_IsShow.DataBindings.Add(new Binding("Checked", _detector, "IsDisplayOfDefect", true, mode));
            this.checkBox_BadConnection_IsShow.DataBindings.Add(new Binding("Checked", _detector, "IsDisplayOfBadConnection", true, mode));
            this.checkBox_Overage_IsShow.DataBindings.Add(new Binding("Checked", _detector, "IsDisplayOfOverage", true, mode));
            this.checkBox_Offset_IsShow.DataBindings.Add(new Binding("Checked", _detector, "IsDisplayOfOffset", true, mode));
            this.checkBox_Tip_IsShow.DataBindings.Add(new Binding("Checked", _detector, "IsDisplayOfTip", true, mode));
            //
            this.comboBoxDisplayWindowName.DataBindings.Add(new Binding("Text", _detector, "DisplayWindowName", true, mode));
            this.checkBoxShow.DataBindings.Add(new Binding("Checked", _detector, "IsDisplay", true, mode));

            return;
        }

        private void FormRefresh(bool isAutoFit)
        {
            this.aqDisplay1.InteractiveGraphics.Clear();
            if (null != _detector.ImageIn)
            {
                this.aqDisplay1.Image = _detector.ImageIn.Clone() as Bitmap;
            }
            if (isAutoFit)
            {
                this.aqDisplay1.FitToScreen();
            }
            this.aqDisplay1.Update();

            return;
        }

        private void InitializeComboxWndName(ComboBox comboBox, string windowName)
        {
            comboBox.Items.Clear();
            WindowNum.Instance().GetWindowNameList(out var windowNameList);
            if (null == windowNameList)
            {
                return;
            }
            foreach (var obj in windowNameList)
            {
                comboBox.Items.Add(obj);
            }
            _detector.DisplayWindowName = windowNameList.Contains(windowName) ? windowName : windowNameList[0];

            return;
        }

        public void Refresh()
        {
            FormRefresh(true);

            return;
        }

        private void splitContainer1_SizeChanged(object sender, System.EventArgs e)
        {
            FormRefresh(true);

            return;
        }
    }
}
