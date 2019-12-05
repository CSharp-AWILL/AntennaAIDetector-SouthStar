using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Aqrose.Framework.Core.Attributes;
using Aqrose.Framework.Core.DataType;
using Aqrose.Framework.Core.Interface;
using Aqrose.Framework.Utility.Tools;
using AqVision.Graphic.AqVision.shape;

namespace AntennaAIDetector_SouthStar.Task.Customer
{
    [Module("Customer", "AntennaAIDetector", "")]
    public class Customer : ModuleData, IModule, IDisplay
    {
        private Task _device = null;

        [OutputData]
        public Bitmap Image { get; set; } = null;

        public int Index { get; set; } = 0;

        #region IDisplay

        public Bitmap DisplayBitmap { get; set; } = null;
        public List<AqShap> DisplayShapes { get; set; } = new List<AqShap>();
        public string DisplayWindowName { get; set; } = "Image0";
        public bool IsDisplay { get; set; } = true;
        public bool IsUpdate { get; set; } = false;

        #endregion

        public Customer()
        {
            _device = TaskPool.GetInstance();
        }

        #region IModule

        public void CloseModule()
        {
            //throw new NotImplementedException();
        }

        public void InitModule(string projectDirectory, string nodeName)
        {
            string configFile = projectDirectory + @"\Customer-" + nodeName + ".xml";
            string strParamInfo = "";
            XmlParameter xmlParameter = null;
            if (File.Exists(configFile))
            {
                xmlParameter = new XmlParameter();
                xmlParameter.ReadParameter(configFile);

                #region IDisplay

                strParamInfo = xmlParameter.GetParamData("DisplayWindowName");
                if (strParamInfo != "")
                {
                    DisplayWindowName = strParamInfo;
                }
                strParamInfo = xmlParameter.GetParamData("IsDisplay");
                if (strParamInfo != "")
                {
                    IsDisplay = Convert.ToBoolean(strParamInfo);
                }

                #endregion

                //
                strParamInfo = xmlParameter.GetParamData("Index");
                if (strParamInfo != "")
                {
                    Index = Convert.ToInt32(strParamInfo);
                }
            }

            return;
        }

        public void Run()
        {
            IsResultOK = false;
            Image = _device.GetBitmap(Index);

            //
            if (null != Image)
            {
                IsResultOK = true;

                if (IsDisplay)
                {
                    DisplayBitmap = Image.Clone() as Bitmap;
                    IsUpdate = true;
                }
                else
                {
                    IsUpdate = false;
                }
            }
        }

        public void SaveModule(string projectDirectory, string nodeName)
        {
            string configFile = projectDirectory + @"\Customer-" + nodeName + ".xml";
            XmlParameter xmlParameter = new XmlParameter();

            #region IDisplay

            xmlParameter.Add("DisplayWindowName", DisplayWindowName);
            xmlParameter.Add("IsDisplay", IsDisplay);

            #endregion

            //
            xmlParameter.Add("Index", Index);

            xmlParameter.WriteParameter(configFile);

            return;
        }

        public bool StartSetForm()
        {
            var form = new CustomerForm(this);
            form.ShowDialog();
            form.Close();

            return true;
        }

        #endregion
    }
}
