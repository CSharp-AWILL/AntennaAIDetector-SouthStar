using System;
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
            //
            this.checkBox_BadConnection_IsAddToDetection.DataBindings.Add(new Binding("Checked", _productManager.BadConnectionParam, "IsAddToDetection", true, mode));
            //
            this.checkBox_Overage_IsAddToDetection.DataBindings.Add(new Binding("Checked", _productManager.OverageParam, "IsAddToDetection", true, mode));
            //
            this.checkBox_Offset_IsAddToDetection.DataBindings.Add(new Binding("Checked", _productManager.OffsetParam, "IsAddToDetection", true, mode));
            //
            this.checkBox_Tip_IsAddToDetection.DataBindings.Add(new Binding("Checked", _productManager.TipParam, "IsAddToDetection", true, mode));

            return;
        }
    }
}
