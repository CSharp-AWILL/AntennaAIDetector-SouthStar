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
            InitializeComboxIndex(this.comboBox_Index, _customer);
            DoDataBindings();
            FormRefresh(true);
        }

        private void DoDataBindings()
        {
            var mode = DataSourceUpdateMode.OnPropertyChanged | DataSourceUpdateMode.OnValidation;

            this.comboBox_Index.DataBindings.Add(new Binding("Text", _customer, "Index", true, mode));

            //
            this.comboBoxDisplayWindowName.DataBindings.Add(new Binding("Text", _customer, "DisplayWindowName", true, mode));
            this.checkBoxShow.DataBindings.Add(new Binding("Checked", _customer, "IsDisplay", true, mode));

            return;
        }

        private void InitializeComboxIndex(ComboBox comboBox, Customer customer)
        {
            for (int index = 0; index < customer.Amount; ++index)
            {
                comboBox.Items.Add(index.ToString());
            }
            customer.Index = Math.Min(customer.Index, customer.Amount);

            return;
        }

        private void FormRefresh(bool isAutoFit)
        {
            this.aqDisplay1.InteractiveGraphics.Clear();
            if (null != _customer.Image)
            {
                this.aqDisplay1.Image = _customer.Image.Clone() as Bitmap;
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
            _customer.DisplayWindowName = windowNameList.Contains(windowName) ? windowName : windowNameList[0];

            return;
        }

        #region Event

        private void button_Test_Click(object sender, EventArgs e)
        {
            if (!_customer.Test())
            {
                MessageBox.Show("无图像！");

                return;
            }

            FormRefresh(true);

            return;
        }

        #endregion
    }
}
