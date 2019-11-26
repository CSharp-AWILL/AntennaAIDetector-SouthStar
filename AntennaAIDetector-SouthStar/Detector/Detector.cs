using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using AntennaAIDetector_SouthStar.Product;
using Aqrose.Framework.Core.Attributes;
using Aqrose.Framework.Core.DataType;
using Aqrose.Framework.Core.Interface;
using Aqrose.Framework.Utility.Tools;
using AqVision.Graphic.AqVision.shape;

namespace AntennaAIDetector_SouthStar.Detector
{

    [Module("AntennaAIDetector", "Detector", "")]
    public class Detector : ModuleData, IModule, IDisplay
    {
        
        private List<AqShap> _displayShapes = new List<AqShap>();

        [InputData]
        public Bitmap ImageIn { get; set; } = null;

        public ProductManager ProductManager { get; set; } = new ProductManager();

        #region IDisplay

        public Bitmap DisplayBitmap { get; set; } = null;
        public List<AqShap> DisplayShapes
        {
            get { return _displayShapes; }
            set { _displayShapes = value; }
        }
        public string DisplayWindowName { get; set; } = "Image0";
        public bool IsDisplay { get; set; } = true;
        public bool IsUpdate { get; set; } = false;

        #endregion

        #region IModule

        public void CloseModule()
        {
            throw new NotImplementedException();
        }

        public void InitModule(string projectDirectory, string nodeName)
        {
            string configFile = projectDirectory + @"\Detector-" + nodeName + ".xml";
            string configFileOfDefectManager= projectDirectory + @"\DefectManager-" + nodeName + ".xml";
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
            }
            //
            ProductManager.LoadParam(configFileOfDefectManager);

            return;
        }

        public void Run()
        {
            throw new NotImplementedException();
        }

        public void SaveModule(string projectDirectory, string nodeName)
        {
            string configFile = projectDirectory + @"\DefectInspector-" + nodeName + ".xml";
            string configFileOfDefectManager = projectDirectory + @"\DefectManager-" + nodeName + ".xml";
            XmlParameter xmlParameter = new XmlParameter();

            #region IDisplay

            xmlParameter.Add("DisplayWindowName", DisplayWindowName);
            xmlParameter.Add("IsDisplay", IsDisplay);

            #endregion

            xmlParameter.WriteParameter(configFile);
            //
            ProductManager.SaveParam(configFileOfDefectManager);

            return;
        }

        public bool StartSetForm()
        {
            var form = new DetectorForm(this);
            form.ShowDialog();
            form.Close();

            return true;
        }

        #endregion

    }
}
