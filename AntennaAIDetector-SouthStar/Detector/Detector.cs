﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using SimpleGroup.Core.Struct;
using AntennaAIDetector_SouthStar.Product;
using Aqrose.Framework.Core.Attributes;
using Aqrose.Framework.Core.DataType;
using Aqrose.Framework.Core.Interface;
using Aqrose.Framework.Utility.DataStructure;
using Aqrose.Framework.Utility.Tools;
using AqVision.Graphic.AqVision.shape;
using AntennaAIDetector_SouthStar.Result;

namespace AntennaAIDetector_SouthStar.Detector
{
    [Module("Detector", "AntennaAIDetector", "")]
    public class Detector : ModuleData, IModule, IDisplay
    {
        [InputData]
        public int IndexOfChannel { get; set; } = 0;
        [InputData]
        public Bitmap ImageIn { get; set; } = null;
        [InputData]
        public AffineMatrix PosMatrix { get; set; } = null;
        //
        [InputData]
        public List<AIDIShape> OutputOfDefectAIDI { get; set; } = new List<AIDIShape>();
        [InputData]
        public List<AIDIShape> OutputOfBadConnectionAIDI { get; set; } = new List<AIDIShape>();
        [InputData]
        public List<AIDIShape> OutputOfOverageAIDI { get; set; } = new List<AIDIShape>();
        [InputData]
        public List<AIDIShape> OutputOfOffsetAIDI { get; set; } = new List<AIDIShape>();
        [InputData]
        public List<AIDIShape> OutputOfTipAIDI { get; set; } = new List<AIDIShape>();
        [InputData]
        public string IsResultOKOfTipAIDI { get; set; } = "";
        [InputData]
        public string IsResultOKOfBadConnectionAIDI { get; set; } = "";

        [OutputData]
        public string IsOkString
        {
            get
            {
                return IsResultOK ? "OK" : "NG";
            }
        }
        [OutputData]
        public List<string> ResultInfo { get; set; } = new List<string>();
        [OutputData]
        public SingleResult SingleResult { get; set; } = null;

        public ProductManager ProductManager { get; set; } = new ProductManager();

        #region IDisplay

        public Bitmap DisplayBitmap { get; set; } = null;
        public List<AqShap> DisplayShapes { get; set; } = new List<AqShap>();
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

        private void RefreshDisplayShape()
        {
            ShapeOf2D result = new ShapeOf2D();

            if (IsDisplayOfDefect)
            {
                result += ProductManager.DefectParam.Region;
            }
            if (IsDisplayOfBadConnection)
            {
                result += ProductManager.BadConnectionParam.Region;
            }
            if (IsDisplayOfOverage)
            {
                result += ProductManager.OverageParam.Region;
            }
            if (IsDisplayOfOffset)
            {
                result += ProductManager.OffsetParam.Region;
                //
                ShapeOf2D.ConverPoint2DToCross(ProductManager.OffsetParam.CurrPoint, 3, out var currPoint);
                result += currPoint;
                ShapeOf2D.ConverPoint2DToCross(ProductManager.OffsetParam.StandardPoint, 5, out var standardPoint);
                result += standardPoint;
            }
            if (IsDisplayOfTip)
            {
                result += ProductManager.TipParam.Region;
            }

            DisplayContour.GetContours(result.XldPointYs, result.XldPointXs, result.XldPointsNums, out var _displayShapes, AqVision.Graphic.AqColorEnum.Red, 2);
            DisplayShapes = _displayShapes;

            return;
        }

        private void InjectInputDataToProductManager()
        {
            ProductManager.DefectParam.ResultOfAIDI = new ResultOfAIDI(OutputOfDefectAIDI);
            //ProductManager.BadConnectionParam.ResultOfAIDI = new ResultOfAIDI(OutputOfBadConnectionAIDI);
            ProductManager.OverageParam.ResultOfAIDI = new ResultOfAIDI(OutputOfOverageAIDI);
            ProductManager.OffsetParam.ResultOfAIDI = new ResultOfAIDI(OutputOfOffsetAIDI);
            //ProductManager.TipParam.ResultOfAIDI = new ResultOfAIDI(OutputOfTipAIDI);
            //
            ProductManager.TipParam.IsResultOK = "OK" == IsResultOKOfTipAIDI ? true : false;
            ProductManager.BadConnectionParam.IsResultOK = "OK" == IsResultOKOfBadConnectionAIDI ? true : false;
            //
            ProductManager.OffsetParam.Matrix = null == PosMatrix ? new MatrixD() : new MatrixD(PosMatrix);

            return;
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
            ResultInfo = new List<string>();
            SingleResult = null;

            if (null != ImageIn)
            {
                Process();
                IsResultOK = ProductManager.IsResultOK;

                DisplayShapes = new List<AqShap>();
                if (IsDisplay)
                {
                    RefreshDisplayShape();
                    IsUpdate = true;
                }
                else
                {
                    IsUpdate = false;
                }
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
            InjectInputDataToProductManager();
            ProductManager.ProcessResultOfAIDI();

            //
            ResultInfo = new List<string>();
            if (null != ProductManager)
            {
                foreach (var temp in ProductManager.Result)
                {
                    ResultInfo.Add(EnumTools.GetDescription(temp));
                }
            }
            SingleResult = new SingleResult(IndexOfChannel, 0 < ResultInfo.Count ? ResultInfo[0] : "Undefined");

            return;
        }

        


    }
}
