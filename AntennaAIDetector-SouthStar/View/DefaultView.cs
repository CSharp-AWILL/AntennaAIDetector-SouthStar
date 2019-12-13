using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AntennaAIDetector_SouthStar.Detector;
using Aqrose.Framework.Core.DataType;
using Aqrose.Framework.Utility.Tools;
using Aqrose.Framework.Utility.WindowConfig;
using SimpleGroup.Core.Struct;

namespace AntennaAIDetector_SouthStar.View
{
    public partial class DefaultView : UserControl
    {
        private Detector.Detector _detector = null;
        private double _timeOfRun = 0.0;

        public string TimeInfo
        {
            get
            {
                return "运行时间：" + _timeOfRun.ToString() + " ms";
            }
        }

        public DefaultView(Detector.Detector detector)
        {
            _detector = detector;
            InitializeComponent();
            DoDataBindings();
            InitializeComboxWndName(this.comboBoxDisplayWindowName, _detector.DisplayWindowName);
            //FormRefresh(true);
            DoCheckBoxDelegate();
        }

        private void DoCheckBoxDelegate()
        {
            this.checkBox_Defect_IsShow.Click += new System.EventHandler(this.checkBox_Clicked);
            this.checkBox_BadConnection_IsShow.Click += new System.EventHandler(this.checkBox_Clicked);
            this.checkBox_Overage_IsShow.Click += new System.EventHandler(this.checkBox_Clicked);
            this.checkBox_Offset_IsShow.Click += new System.EventHandler(this.checkBox_Clicked);
            this.checkBox_Tip_IsShow.Click += new System.EventHandler(this.checkBox_Clicked);
            this.checkBoxShow.Click+=new System.EventHandler(this.checkBox_Clicked);

            return;
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
                if (_detector.IsDisplay)
                {
                    //
                    if (_detector.IsDisplayOfDefect)
                    {
                        if (null != _detector.ProductManager.DefectParam.Region && 0 != _detector.ProductManager.DefectParam.Region.XldPointsNums.Count)
                        {
                            var temp = _detector.ProductManager.DefectParam.Region;
                            DisplayContour.GetContours(temp.XldPointYs, temp.XldPointXs, temp.XldPointsNums, out var shape, AqVision.Graphic.AqColorEnum.Green, 2);
                            DisplayContour.Display(this.aqDisplay1, shape);
                        }
                    }
                    //
                    if (_detector.IsDisplayOfBadConnection)
                    {
                        if (null != _detector.ProductManager.BadConnectionParam.Region && 0 != _detector.ProductManager.BadConnectionParam.Region.XldPointsNums.Count)
                        {
                            var temp = _detector.ProductManager.BadConnectionParam.Region;
                            DisplayContour.GetContours(temp.XldPointYs, temp.XldPointXs, temp.XldPointsNums, out var shape, AqVision.Graphic.AqColorEnum.Red, 2);
                            DisplayContour.Display(this.aqDisplay1, shape);
                        }
                    }
                    //
                    if (_detector.IsDisplayOfOverage)
                    {
                        if (null != _detector.ProductManager.OverageParam.Region && 0 != _detector.ProductManager.OverageParam.Region.XldPointsNums.Count)
                        {
                            var temp = _detector.ProductManager.OverageParam.Region;
                            DisplayContour.GetContours(temp.XldPointYs, temp.XldPointXs, temp.XldPointsNums, out var shape, AqVision.Graphic.AqColorEnum.Blue, 2);
                            DisplayContour.Display(this.aqDisplay1, shape);
                        }
                    }
                    //
                    if (_detector.IsDisplayOfOffset)
                    {
                        if (null != _detector.ProductManager.OffsetParam.Region && 0 != _detector.ProductManager.OffsetParam.Region.XldPointsNums.Count)
                        {
                            var temp = _detector.ProductManager.OffsetParam.Region;
                            DisplayContour.GetContours(temp.XldPointYs, temp.XldPointXs, temp.XldPointsNums, out var shape, AqVision.Graphic.AqColorEnum.Yellow, 2);
                            DisplayContour.Display(this.aqDisplay1, shape);
                        }
                        //
                        ShapeOf2D.ConverPoint2DToCross(_detector.ProductManager.OffsetParam.StandardPoint, 3, out var standardPoint);
                        DisplayContour.GetContours(standardPoint.XldPointYs, standardPoint.XldPointXs, standardPoint.XldPointsNums, out var shapeOfStandardPoint, AqVision.Graphic.AqColorEnum.Yellow, 4);
                        DisplayContour.Display(this.aqDisplay1, shapeOfStandardPoint);
                        //
                        ShapeOf2D.ConverPoint2DToCross(_detector.ProductManager.OffsetParam.CurrPoint, 3, out var currPoint);
                        DisplayContour.GetContours(currPoint.XldPointYs, currPoint.XldPointXs, currPoint.XldPointsNums, out var shapeOfCurrPoint, AqVision.Graphic.AqColorEnum.Yellow, 2);
                        DisplayContour.Display(this.aqDisplay1, shapeOfCurrPoint);
                    }
                    //
                    if (_detector.IsDisplayOfTip)
                    {
                        if (null != _detector.ProductManager.TipParam.Region && 0 != _detector.ProductManager.TipParam.Region.XldPointsNums.Count)
                        {
                            var temp = _detector.ProductManager.TipParam.Region;
                            DisplayContour.GetContours(temp.XldPointYs, temp.XldPointXs, temp.XldPointsNums, out var shape, AqVision.Graphic.AqColorEnum.Orange, 2);
                            DisplayContour.Display(this.aqDisplay1, shape);
                        }
                    }
                }
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

        #region Event

        private void splitContainer1_SizeChanged(object sender, System.EventArgs e)
        {
            //if (!_isFirstOpen)
            //{
            //}
            //else
            //{
            //    _isFirstOpen = false;
            //}
            FormRefresh(true);

            return;
        }

        private void checkBox_Clicked(object sender, System.EventArgs e)
        {
            FormRefresh(false);

            return;
        }

        #endregion

        public void Process()
        {
            RunTime runTime = new RunTime();

            if (null != _detector.ImageIn)
            {
                runTime.LogStartRunTime();
                _detector.Process();
                runTime.LogEndRunTime();
                runTime.GetRunTime(out _timeOfRun);
            }
            else
            {
                MessageBox.Show("DetectorForm: 当前无图像！");
            }
            FormRefresh(true);

            return;
        }

        public string GetResultInfo()
        {
            string res = "运行结果：";
            if (null != _detector)
            {
                foreach (var temp in _detector.ResultInfo)
                {
                    res += temp;
                }
            }

            return res;
        }

    }
}
