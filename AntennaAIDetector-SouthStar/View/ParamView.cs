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
            var mode = DataSourceUpdateMode.OnPropertyChanged | DataSourceUpdateMode.OnValidation;

            //
            this.checkBox_Defect_IsAddToDetection.DataBindings.Add(new Binding("Checked", _productManager.DefectParam, "IsAddToDetection", true, mode));
            this.numericUpDown_Defect_TinyAreaFilter.DataBindings.Add(new Binding("Text", _productManager.DefectParam, "TinyAreaFilter", true, mode));
            this.numericUpDown_Defect_TinyNumFilter.DataBindings.Add(new Binding("Text", _productManager.DefectParam, "TinyNumFilter", true, mode));
            this.numericUpDown_Defect_ObvAreaFilter.DataBindings.Add(new Binding("Text", _productManager.DefectParam, "ObvAreaFilter", true, mode));
            this.numericUpDown_Defect_ObvNumFilter.DataBindings.Add(new Binding("Text", _productManager.DefectParam, "ObvNumFilter", true, mode));
            //
            this.checkBox_BadConnection_IsAddToDetection.DataBindings.Add(new Binding("Checked", _productManager.BadConnectionParam, "IsAddToDetection", true, mode));
            //
            this.checkBox_Overage_IsAddToDetection.DataBindings.Add(new Binding("Checked", _productManager.OverageParam, "IsAddToDetection", true, mode));
            this.numericUpDown_Overage_AreaOfLeftFilter.DataBindings.Add(new Binding("Text", _productManager.OverageParam, "AreaOfLeftFilter", true, mode));
            this.numericUpDown_Overage_AreaOfRightFilter.DataBindings.Add(new Binding("Text", _productManager.OverageParam, "AreaOfRightFilter", true, mode));
            this.numericUpDown_Overage_CurrAreaOfLeft.DataBindings.Add(new Binding("Text", _productManager.OverageParam, "CurrAreaOfLeft", true, mode));
            this.numericUpDown_Overage_CurrAreaOfRight.DataBindings.Add(new Binding("Text", _productManager.OverageParam, "CurrAreaOfRight", true, mode));
            //
            this.checkBox_Offset_IsAddToDetection.DataBindings.Add(new Binding("Checked", _productManager.OffsetParam, "IsAddToDetection", true, mode));
            //
            this.checkBox_Tip_IsAddToDetection.DataBindings.Add(new Binding("Checked", _productManager.TipParam, "IsAddToDetection", true, mode));

            return;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
