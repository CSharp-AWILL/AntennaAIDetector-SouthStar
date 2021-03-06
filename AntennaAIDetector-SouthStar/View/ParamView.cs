﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AntennaAIDetector_SouthStar.Product;

namespace AntennaAIDetector_SouthStar.View
{
    public partial class ParamView : UserControl
    {
        public ProductManager _productManager = null;
        public ParamView(ProductManager productManager)
        {
            _productManager = productManager;
            InitializeComponent();
            DoDataBindings();
        }

        private void DoDataBindings()
        {
            var mode = DataSourceUpdateMode.OnPropertyChanged/* | DataSourceUpdateMode.OnValidation*/;

            //
            this.checkBox_Defect_IsAddToDetection.DataBindings.Add(new Binding("Checked", _productManager.DefectParam, "IsAddToDetection", true, mode));
            this.numericUpDown_Defect_TinyAreaFilter.DataBindings.Add(new Binding("Text", _productManager.DefectParam, "TinyAreaFilter", true, mode));
            this.numericUpDown_Defect_TinyNumFilter.DataBindings.Add(new Binding("Text", _productManager.DefectParam, "TinyNumFilter", true, mode));
            this.numericUpDown_Defect_ObvAreaFilter.DataBindings.Add(new Binding("Text", _productManager.DefectParam, "ObvAreaFilter", true, mode));
            this.numericUpDown_Defect_ObvNumFilter.DataBindings.Add(new Binding("Text", _productManager.DefectParam, "ObvNumFilter", true, mode));
            this.numericUpDown_Defect_CurrTinyArea.DataBindings.Add(new Binding("Text", _productManager.DefectParam, "CurrTinyArea", true, mode));
            this.numericUpDown_Defect_CurrObvArea.DataBindings.Add(new Binding("Text", _productManager.DefectParam, "CurrObvArea", true, mode));
            //
            this.checkBox_BadConnection_IsAddToDetection.DataBindings.Add(new Binding("Checked", _productManager.BadConnectionParam, "IsAddToDetection", true, mode));
            //
            this.checkBox_Overage_IsAddToDetection.DataBindings.Add(new Binding("Checked", _productManager.OverageParam, "IsAddToDetection", true, mode));
            this.numericUpDown_Overage_Number.DataBindings.Add(new Binding("Text", _productManager.OverageParam, "Number", true, mode));
            this.numericUpDown_Overage_AreaOfLeftFilter.DataBindings.Add(new Binding("Text", _productManager.OverageParam, "AreaOfLeftFilter", true, mode));
            this.numericUpDown_Overage_AreaOfRightFilter.DataBindings.Add(new Binding("Text", _productManager.OverageParam, "AreaOfRightFilter", true, mode));
            this.numericUpDown_Overage_AreaOfRightFilter1.DataBindings.Add(new Binding("Text", _productManager.OverageParam, "AreaOfRightFilter1", true, mode));
            this.numericUpDown_Overage_CurrAreaOfLeft.DataBindings.Add(new Binding("Text", _productManager.OverageParam, "CurrAreaOfLeft", true, mode));
            this.numericUpDown_Overage_CurrAreaOfRight.DataBindings.Add(new Binding("Text", _productManager.OverageParam, "CurrAreaOfRight", true, mode));
            this.numericUpDown_Overage_CurrAreaOfRight1.DataBindings.Add(new Binding("Text", _productManager.OverageParam, "CurrAreaOfRight1", true, mode));
            //
            this.checkBox_Offset_IsAddToDetection.DataBindings.Add(new Binding("Checked", _productManager.OffsetParam, "IsAddToDetection", true, mode));
            this.numericUpDown_Offset_StandardXFilter.DataBindings.Add(new Binding("Text", _productManager.OffsetParam, "StandardXFilter", true, mode));
            this.numericUpDown_Offset_StandardYFilter.DataBindings.Add(new Binding("Text", _productManager.OffsetParam, "StandardYFilter", true, mode));
            this.numericUpDown_Offset_LeftFilter.DataBindings.Add(new Binding("Text", _productManager.OffsetParam, "LeftFilter", true, mode));
            this.numericUpDown_Offset_RightFilter.DataBindings.Add(new Binding("Text", _productManager.OffsetParam, "RightFilter", true, mode));
            this.numericUpDown_Offset_UpFilter.DataBindings.Add(new Binding("Text", _productManager.OffsetParam, "UpFilter", true, mode));
            this.numericUpDown_Offset_DownFilter.DataBindings.Add(new Binding("Text", _productManager.OffsetParam, "DownFilter", true, mode));
            this.numericUpDown_Offset_CurrX.DataBindings.Add(new Binding("Text", _productManager.OffsetParam, "CurrX", true, mode));
            this.numericUpDown_Offset_CurrY.DataBindings.Add(new Binding("Text", _productManager.OffsetParam, "CurrY", true, mode));
            //
            this.checkBox_Tip_IsAddToDetection.DataBindings.Add(new Binding("Checked", _productManager.TipParam, "IsAddToDetection", true, mode));

            return;
        }

        public void RefreshControl()
        {
            //
            this.numericUpDown_Overage_CurrAreaOfLeft.Value = Convert.ToDecimal(_productManager.OverageParam.CurrAreaOfLeft);
            this.numericUpDown_Overage_CurrAreaOfRight.Value = Convert.ToDecimal(_productManager.OverageParam.CurrAreaOfRight);
            //
            this.numericUpDown_Offset_CurrX.Value = Convert.ToDecimal(_productManager.OffsetParam.CurrX);
            this.numericUpDown_Offset_CurrY.Value = Convert.ToDecimal(_productManager.OffsetParam.CurrY);

            return;
        }

        #region Event

        private void button_Overage_Adjust_Click(object sender, EventArgs e)
        {
            _productManager.AdjustOverageAsCurrent();
            //
            if (3 == _productManager.OverageParam.Number)
            {
                this.numericUpDown_Overage_AreaOfRightFilter1.Value = Convert.ToDecimal(_productManager.OverageParam.AreaOfRightFilter1);
            }
            this.numericUpDown_Overage_AreaOfLeftFilter.Value = Convert.ToDecimal(_productManager.OverageParam.AreaOfLeftFilter);
            this.numericUpDown_Overage_AreaOfRightFilter.Value = Convert.ToDecimal(_productManager.OverageParam.AreaOfRightFilter);

            return;
        }

        private void button_Offset_Adjust_Click(object sender, EventArgs e)
        {
            _productManager.AdjustOffsetAsCurrent();
            //
            this.numericUpDown_Offset_StandardXFilter.Value = Convert.ToDecimal(_productManager.OffsetParam.StandardXFilter);
            this.numericUpDown_Offset_StandardYFilter.Value = Convert.ToDecimal(_productManager.OffsetParam.StandardYFilter);

            return;
        }

        #endregion


    }
}
