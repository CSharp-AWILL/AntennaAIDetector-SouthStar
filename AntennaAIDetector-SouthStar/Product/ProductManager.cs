using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using AntennaAIDetector_SouthStar.Product.Detail;
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

        public Defect DefectParam { get; set; } = new Defect();
        public Overage OverageParam { get; set; } = new Overage();
        public Offset OffsetParam { get; set; } = new Offset();
        public Tip TipParam { get; set; } = new Tip();
        public BadConnection BadConnectionParam { get; set; } = new BadConnection();

        public ProductManager()
        {
            // LABEL: do nothing
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
                strParamInfo = xmlParameter.GetParamData("OverageParam.AreaOfLeftFilter");
                if (strParamInfo != "")
                {
                    OverageParam.AreaOfLeftFilter = Convert.ToDouble(strParamInfo);
                }
                strParamInfo = xmlParameter.GetParamData("OverageParam.AreaOfRightFilter");
                if (strParamInfo != "")
                {
                    OverageParam.AreaOfRightFilter = Convert.ToDouble(strParamInfo);
                }
                // Offset
                strParamInfo = xmlParameter.GetParamData("OffsetParam.IsAddToDetection");
                if (strParamInfo != "")
                {
                    OffsetParam.IsAddToDetection = Convert.ToBoolean(strParamInfo);
                }
                strParamInfo = xmlParameter.GetParamData("OffsetParam.StandardXFilter");
                if (strParamInfo != "")
                {
                    OffsetParam.StandardXFilter = Convert.ToDouble(strParamInfo);
                }
                strParamInfo = xmlParameter.GetParamData("OffsetParam.StandardYFilter");
                if (strParamInfo != "")
                {
                    OffsetParam.StandardYFilter = Convert.ToDouble(strParamInfo);
                }
                strParamInfo = xmlParameter.GetParamData("OffsetParam.UpFilter");
                if (strParamInfo != "")
                {
                    OffsetParam.UpFilter = Convert.ToDouble(strParamInfo);
                }
                strParamInfo = xmlParameter.GetParamData("OffsetParam.DownFilter");
                if (strParamInfo != "")
                {
                    OffsetParam.DownFilter = Convert.ToDouble(strParamInfo);
                }
                strParamInfo = xmlParameter.GetParamData("OffsetParam.LeftFilter");
                if (strParamInfo != "")
                {
                    OffsetParam.LeftFilter = Convert.ToDouble(strParamInfo);
                }
                strParamInfo = xmlParameter.GetParamData("OffsetParam.RightFilter");
                if (strParamInfo != "")
                {
                    OffsetParam.RightFilter = Convert.ToDouble(strParamInfo);
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
            xmlParameter.Add("OverageParam.AreaOfLeftFilter", OverageParam.AreaOfLeftFilter);
            xmlParameter.Add("OverageParam.AreaOfRightFilter", OverageParam.AreaOfRightFilter);
            // Offset
            xmlParameter.Add("OffsetParam.IsAddToDetection", OffsetParam.IsAddToDetection);
            xmlParameter.Add("OffsetParam.StandardXFilter", OffsetParam.StandardXFilter);
            xmlParameter.Add("OffsetParam.StandardYFilter", OffsetParam.StandardYFilter);
            xmlParameter.Add("OffsetParam.UpFilter", OffsetParam.UpFilter);
            xmlParameter.Add("OffsetParam.DownFilter", OffsetParam.DownFilter);
            xmlParameter.Add("OffsetParam.LeftFilter", OffsetParam.LeftFilter);
            xmlParameter.Add("OffsetParam.RightFilter", OffsetParam.RightFilter);
            // Tip
            xmlParameter.Add("TipParam.IsAddToDetection", TipParam.IsAddToDetection);
            // BadConnection
            xmlParameter.Add("BadConnectionParam.IsAddToDetection", BadConnectionParam.IsAddToDetection);

            xmlParameter.WriteParameter(configFile);

            return;
        }

        public void AdjustOffsetAsCurrent()
        {
            OffsetParam.StandardXFilter = OffsetParam.CurrX;
            OffsetParam.StandardYFilter = OffsetParam.CurrY;

            return;
        }

        public void AdjustOverageAsCurrent()
        {
            OverageParam.AreaOfLeftFilter = OverageParam.CurrAreaOfLeft;
            OverageParam.AreaOfRightFilter = OverageParam.CurrAreaOfRight;

            return;
        }
        //
        public void ProcessResultOfAIDI()
        {
            Result.Clear();
            // TODO: analyze result
            if (DefectParam.IsAddToDetection)
            {
                DefectParam.CalculateRegion();
                if (!DefectParam.IsResultOK)
                {
                   Result.Add(ETypeOfNg.DEFECT);
                }
            }
            //
            if (OverageParam.IsAddToDetection)
            {
                OverageParam.CalculateRegion();
                if (!OverageParam.IsResultOK)
                {
                   Result.Add(ETypeOfNg.OVERAGE);
                }
            }
            //
            if (OffsetParam.IsAddToDetection)
            {
                OffsetParam.CalculateRegion();
                if (!OffsetParam.IsResultOK)
                {
                   Result.Add(ETypeOfNg.OFFSET);
                }
            }
            //
            if (TipParam.IsAddToDetection)
            {
                TipParam.CalculateRegion();
                if (!TipParam.IsResultOK)
                {
                   Result.Add(ETypeOfNg.TIP);
                }
            }
            //
            if (BadConnectionParam.IsAddToDetection)
            {
                BadConnectionParam.CalculateRegion();
                if (!BadConnectionParam.IsResultOK)
                {
                   Result.Add(ETypeOfNg.BADCONNECTION);
                }
            }

            //
            if (0 == Result.Count)
            {
                Result.Add(ETypeOfNg.OK);
            }

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
