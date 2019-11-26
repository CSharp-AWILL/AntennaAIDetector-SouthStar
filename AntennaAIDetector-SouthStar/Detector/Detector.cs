﻿using System;
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
        [InputData]
        public bool IsResultOKOfDefectAIDI { get; set; } = false;
        [InputData]
        public bool IsResultOKOfBadConnectionAIDI { get; set; } = false;
        [InputData]
        public bool IsResultOKOfOverageAIDI { get; set; } = false;
        [InputData]
        public bool IsResultOKOfOffsetAIDI { get; set; } = false;
        [InputData]
        public bool IsResultOKOfTipAIDI { get; set; } = false;
        
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

        public bool IsDisplayOfDefect { get; set; } = true;
        public bool IsDisplayOfBadConnection { get; set; } = true;
        public bool IsDisplayOfOverage { get; set; } = true;
        public bool IsDisplayOfOffset { get; set; } = true;
        public bool IsDisplayOfTip { get; set; } = true;

        public Detector()
        {
        }

        
        #region IModule

        public void CloseModule()
        {
            //throw new NotImplementedException();
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
                //
                strParamInfo = xmlParameter.GetParamData("IsDisplayOfDefect");
                if (strParamInfo != "")
                {
                    IsDisplayOfDefect = Convert.ToBoolean(strParamInfo);
                }
                strParamInfo = xmlParameter.GetParamData("IsDisplayOfBadConnection");
                if (strParamInfo != "")
                {
                    IsDisplayOfBadConnection = Convert.ToBoolean(strParamInfo);
                }
                strParamInfo = xmlParameter.GetParamData("IsDisplayOfOverage");
                if (strParamInfo != "")
                {
                    IsDisplayOfOverage = Convert.ToBoolean(strParamInfo);
                }
                strParamInfo = xmlParameter.GetParamData("IsDisplayOfOffset");
                if (strParamInfo != "")
                {
                    IsDisplayOfOffset = Convert.ToBoolean(strParamInfo);
                }
                strParamInfo = xmlParameter.GetParamData("IsDisplayOfTip");
                if (strParamInfo != "")
                {
                    IsDisplayOfTip = Convert.ToBoolean(strParamInfo);
                }
            }
            //
            ProductManager.LoadParam(configFileOfDefectManager);

            return;
        }

        public void Run()
        {
            if (null != ImageIn)
            {
                Process();
                IsResultOK = ProductManager.IsResultOK;
            }

            //throw new NotImplementedException();
        }

        public void SaveModule(string projectDirectory, string nodeName)
        {
            string configFile = projectDirectory + @"\Detector-" + nodeName + ".xml";
            string configFileOfDefectManager = projectDirectory + @"\DefectManager-" + nodeName + ".xml";
            XmlParameter xmlParameter = new XmlParameter();

            #region IDisplay

            xmlParameter.Add("DisplayWindowName", DisplayWindowName);
            xmlParameter.Add("IsDisplay", IsDisplay);

            #endregion
            //
            xmlParameter.Add("IsDisplayOfDefect", IsDisplayOfDefect);
            xmlParameter.Add("IsDisplayOfBadConnection", IsDisplayOfBadConnection);
            xmlParameter.Add("IsDisplayOfOverage", IsDisplayOfOverage);
            xmlParameter.Add("IsDisplayOfOffset", IsDisplayOfOffset);
            xmlParameter.Add("IsDisplayOfTip", IsDisplayOfTip);

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

        public void Process()
        {
            ProductManager.SetResultAsUnprocessed();

            ProductManager.DefectParam.IsResultOKOfAIDI = IsResultOKOfDefectAIDI;
            ProductManager.BadConnectionParam.IsResultOKOfAIDI = IsResultOKOfBadConnectionAIDI;
            ProductManager.OverageParam.IsResultOKOfAIDI = IsResultOKOfOverageAIDI;
            ProductManager.OffsetParam.IsResultOKOfAIDI = IsResultOKOfOffsetAIDI;
            ProductManager.TipParam.IsResultOKOfAIDI = IsResultOKOfTipAIDI;
            ProductManager.AnalyzeResult();

            return;
        }


    }
}