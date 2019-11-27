using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using AntennaAIDetector_SouthStar.ShapeOf2D;
using Aqrose.Framework.Utility.DataStructure;
using Aqrose.Framework.Utility.Tools;

namespace AntennaAIDetector_SouthStar.Product
{
    public class ProductManager
    {
        #region TypeOfNg

        public enum ETypeOfNg
        {
            [Description("未处理")]
            UNPROCESSED=0,
            [Description("OK")]
            OK,
            [Description("漏焊")]
            DEFECT,
            [Description("溢出")]
            OVERAGE,
            [Description("偏位")]
            OFFSET,
            [Description("拉尖")]
            TIP,
            [Description("虚焊")]
            BADCONNECTION
        }

        public class Defect
        {
            public bool IsAddToDetection { get; set; } = true;
            public double TinyAreaFilter { get; set; } = 0.0;
            public int TinyNumFilter { get; set; } = 0;
            public double ObvAreaFilter { get; set; } = 0.0;
            public int ObvNumFilter { get; set; } = 0;
            //
            public ShapeOf2D.ShapeOf2D Region { get; set; } = new ShapeOf2D.ShapeOf2D();
            public bool IsResultOKOfAIDI { get; set; } = true;
            public List<ShapeOfAIDI> ResultDetailOfAIDI { get; set; } = new List<ShapeOfAIDI>();
        }

        public class Overage
        {
            public bool IsAddToDetection { get; set; } = true;
            public double StandardAreaFilter { get; set; } = 0.0;
            public double TinyAreaFilter { get; set; } = 0.0;
            public int TinyNumFilter { get; set; } = 0;
            public double ObvAreaFilter { get; set; } = 0.0;
            public int ObvNumFilter { get; set; } = 0;
            //
            public ShapeOf2D.ShapeOf2D Region { get; set; } = new ShapeOf2D.ShapeOf2D();
            public bool IsResultOKOfAIDI { get; set; } = true;
            public List<ShapeOfAIDI> ResultDetailOfAIDI { get; set; } = new List<ShapeOfAIDI>();
        }

        public class Offset
        {
            public bool IsAddToDetection { get; set; } = true;
            //
            public ShapeOf2D.ShapeOf2D Region { get; set; } = new ShapeOf2D.ShapeOf2D();
            public bool IsResultOKOfAIDI { get; set; } = true;
            public List<ShapeOfAIDI> ResultDetailOfAIDI { get; set; } = new List<ShapeOfAIDI>();
        }

        public class Tip
        {
            public bool IsAddToDetection { get; set; } = true;
            //
            public ShapeOf2D.ShapeOf2D Region { get; set; } = new ShapeOf2D.ShapeOf2D();
            public bool IsResultOKOfAIDI { get; set; } = true;
            public List<ShapeOfAIDI> ResultDetailOfAIDI { get; set; } = new List<ShapeOfAIDI>();
        }

        public class BadConnection
        {
            public bool IsAddToDetection { get; set; } = true;
            //
            public ShapeOf2D.ShapeOf2D Region { get; set; } = new ShapeOf2D.ShapeOf2D();
            public bool IsResultOKOfAIDI { get; set; } = true;
            public List<ShapeOfAIDI> ResultDetailOfAIDI { get; set; } = new List<ShapeOfAIDI>();
        }

        #endregion
        public List<ETypeOfNg> Result { get; private set; } = new List<ETypeOfNg>() { ETypeOfNg.UNPROCESSED };
        public bool IsResultOK
        {
            get
            {
                if (1 == Result.Count && ETypeOfNg.OK == Result[0])
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public ShapeOf2D.ShapeOf2D RegionOfNg { get; private set; } = null;

        public Defect DefectParam { get; set; } = new Defect();
        public Overage OverageParam { get; set; } = new Overage();
        public Offset OffsetParam { get; set; } = new Offset();
        public Tip TipParam { get; set; } = new Tip();
        public BadConnection BadConnectionParam { get; set; } = new BadConnection();

        public ProductManager()
        {
            // LABEL: do nothing
        }

        private void UnionRegionOfAIDI()
        {
            RegionOfNg = DefectParam.Region + OverageParam.Region;
            RegionOfNg = RegionOfNg + OffsetParam.Region;
            RegionOfNg = RegionOfNg + TipParam.Region;
            RegionOfNg = RegionOfNg + BadConnectionParam.Region;

            return;
        }

        //
        public void LoadParam(string configFile)
        {
            // TODO: load parameters
            XmlParameter xmlParameter = null;
            string strParamInfo = "";
            if (File.Exists(configFile))
            {
                xmlParameter = new XmlParameter();
                xmlParameter.ReadParameter(configFile);
                // Defect
                strParamInfo = xmlParameter.GetParamData("DefectParam.IsAddToDetection");
                if (strParamInfo != "")
                {
                    DefectParam.IsAddToDetection = Convert.ToBoolean(strParamInfo);
                }
                strParamInfo = xmlParameter.GetParamData("DefectParam.TinyAreaFilter");
                if (strParamInfo != "")
                {
                    DefectParam.TinyAreaFilter = Convert.ToDouble(strParamInfo);
                }
                strParamInfo = xmlParameter.GetParamData("DefectParam.TinyNumFilter");
                if (strParamInfo != "")
                {
                    DefectParam.TinyNumFilter = Convert.ToInt32(strParamInfo);
                }
                strParamInfo = xmlParameter.GetParamData("DefectParam.ObvAreaFilter");
                if (strParamInfo != "")
                {
                    DefectParam.ObvAreaFilter = Convert.ToDouble(strParamInfo);
                }
                strParamInfo = xmlParameter.GetParamData("DefectParam.ObvNumFilter");
                if (strParamInfo != "")
                {
                    DefectParam.ObvNumFilter = Convert.ToInt32(strParamInfo);
                }
                // Overage
                strParamInfo = xmlParameter.GetParamData("OverageParam.IsAddToDetection");
                if (strParamInfo != "")
                {
                    OverageParam.IsAddToDetection = Convert.ToBoolean(strParamInfo);
                }
                strParamInfo = xmlParameter.GetParamData("OverageParam.StandardAreaFilter");
                if (strParamInfo != "")
                {
                    OverageParam.StandardAreaFilter = Convert.ToDouble(strParamInfo);
                }
                strParamInfo = xmlParameter.GetParamData("OverageParam.TinyAreaFilter");
                if (strParamInfo != "")
                {
                    OverageParam.TinyAreaFilter = Convert.ToDouble(strParamInfo);
                }
                strParamInfo = xmlParameter.GetParamData("OverageParam.TinyNumFilter");
                if (strParamInfo != "")
                {
                    OverageParam.TinyNumFilter = Convert.ToInt32(strParamInfo);
                }
                strParamInfo = xmlParameter.GetParamData("OverageParam.ObvAreaFilter");
                if (strParamInfo != "")
                {
                    OverageParam.ObvAreaFilter = Convert.ToDouble(strParamInfo);
                }
                strParamInfo = xmlParameter.GetParamData("OverageParam.ObvNumFilter");
                if (strParamInfo != "")
                {
                    OverageParam.ObvNumFilter = Convert.ToInt32(strParamInfo);
                }
                // Offset
                strParamInfo = xmlParameter.GetParamData("OffsetParam.IsAddToDetection");
                if (strParamInfo != "")
                {
                    OffsetParam.IsAddToDetection = Convert.ToBoolean(strParamInfo);
                }
                // Tip
                strParamInfo = xmlParameter.GetParamData("TipParam.IsAddToDetection");
                if (strParamInfo != "")
                {
                    TipParam.IsAddToDetection = Convert.ToBoolean(strParamInfo);
                }
                // BadConnection
                strParamInfo = xmlParameter.GetParamData("BadConnectionParam.IsAddToDetection");
                if (strParamInfo != "")
                {
                    BadConnectionParam.IsAddToDetection = Convert.ToBoolean(strParamInfo);
                }
            }

            return;
        }

        public void SaveParam(string configFile)
        {
            // TODO: save parameters
            XmlParameter xmlParameter = new XmlParameter();
            // Defect
            xmlParameter.Add("DefectParam.IsAddToDetection", DefectParam.IsAddToDetection);
            xmlParameter.Add("DefectParam.TinyAreaFilter", DefectParam.TinyAreaFilter);
            xmlParameter.Add("DefectParam.TinyNumFilter", DefectParam.TinyNumFilter);
            xmlParameter.Add("DefectParam.ObvAreaFilter", DefectParam.ObvAreaFilter);
            xmlParameter.Add("DefectParam.ObvNumFilter", DefectParam.ObvNumFilter);
            // Overage
            xmlParameter.Add("OverageParam.IsAddToDetection", OverageParam.IsAddToDetection);
            xmlParameter.Add("OverageParam.StandardAreaFilter", OverageParam.StandardAreaFilter);
            xmlParameter.Add("OverageParam.TinyAreaFilter", OverageParam.TinyAreaFilter);
            xmlParameter.Add("OverageParam.TinyNumFilter", OverageParam.TinyNumFilter);
            xmlParameter.Add("OverageParam.ObvAreaFilter", OverageParam.ObvAreaFilter);
            xmlParameter.Add("OverageParam.ObvNumFilter", OverageParam.ObvNumFilter);
            // Offset
            xmlParameter.Add("OffsetParam.IsAddToDetection", OffsetParam.IsAddToDetection);
            // Tip
            xmlParameter.Add("TipParam.IsAddToDetection", TipParam.IsAddToDetection);
            // BadConnection
            xmlParameter.Add("BadConnectionParam.IsAddToDetection", BadConnectionParam.IsAddToDetection);

            xmlParameter.WriteParameter(configFile);

            return;
        }

        //
        public void ProcessResultOfAIDI()
        {
            Result.Clear();
            // TODO: analyze result
            if (DefectParam.IsAddToDetection && (!DefectParam.IsResultOKOfAIDI))
            {
                Result.Add(ETypeOfNg.DEFECT);
            }
            if (OverageParam.IsAddToDetection && (!OverageParam.IsResultOKOfAIDI))
            {
                Result.Add(ETypeOfNg.OVERAGE);
            }
            if (OffsetParam.IsAddToDetection && (!OffsetParam.IsResultOKOfAIDI))
            {
                Result.Add(ETypeOfNg.OFFSET);
            }
            //
            if (TipParam.IsAddToDetection &&(!TipParam.IsResultOKOfAIDI))
            {
                foreach (var temp in TipParam.ResultDetailOfAIDI)
                {
                    TipParam.Region += temp.ShapeOf2D;
                }
                Result.Add(ETypeOfNg.TIP);
            }
            //
            if (BadConnectionParam.IsAddToDetection &&(!BadConnectionParam.IsResultOKOfAIDI))
            {
                foreach (var temp in BadConnectionParam.ResultDetailOfAIDI)
                {
                    BadConnectionParam.Region += temp.ShapeOf2D;
                }
                Result.Add(ETypeOfNg.BADCONNECTION);
            }

            //
            if (0 == Result.Count)
            {
                Result.Add(ETypeOfNg.OK);
            }
            UnionRegionOfAIDI();

            return;
        }

        public void SetResultAsUnprocessed()
        {
            Result.Clear();
            Result.Add(ETypeOfNg.UNPROCESSED);

            return;
        }
        
    }
}
