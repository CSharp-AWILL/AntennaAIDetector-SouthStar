using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aqrose.Framework.Utility.WindowConfig;

namespace AntennaAIDetector_SouthStar.Task.Customer
{
    public partial class CustomerForm : Form
    {
        private Customer _customer = null;
        public CustomerForm(Customer customer)
        {
            _customer = customer;
            InitializeComponent();
            InitializeComboxWndName(this.comboBoxDisplayWindowName, _customer.DisplayWindowName);
            DoDataBindings();
        }

        private void DoDataBindings()
        {
            var mode = DataSourceUpdateMode.OnPropertyChanged | DataSourceUpdateMode.OnValidation;

            this.numericUpDown1.DataBindings.Add(new Binding("Text", _customer, "Index", true, mode));
            //
            this.comboBoxDisplayWindowName.DataBindings.Add(new Binding("Text", _customer, "DisplayWindowName", true, mode));

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
            _customer.DisplayWindowName = windowNameList.Contains(windowName) ? windowName : windowNameList[0];

            return;
        }

    }
}
