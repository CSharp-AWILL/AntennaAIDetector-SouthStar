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
        }
    }
}
