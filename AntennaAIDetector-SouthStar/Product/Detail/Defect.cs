﻿using System.Collections.Generic;
using Aqrose.Framework.Utility.MessageManager;
using SimpleGroup.Core.Struct;

namespace AntennaAIDetector_SouthStar.Product.Detail
{
    public class Defect:IEvaluateAIDI
    {
        public bool IsAddToDetection { get; set; } = true;
        public bool IsResultOK
        {
            get
            {
                return 0 == Region.XldPointsNums.Count;
            }
        }

        public double TinyAreaFilter { get; set; } = 0.0;
        public int TinyNumFilter { get; set; } = 0;
        public double ObvAreaFilter { get; set; } = 0.0;
        public int ObvNumFilter { get; set; } = 0;
        //
        public double CurrTinyArea { get; set; } = 0.0;
        public double CurrObvArea { get; set; } = 0.0;
        //
        public ResultOfAIDI ResultOfAIDI { get; set; } = new ResultOfAIDI(null);
        public ShapeOf2D Region { get; set; } = new ShapeOf2D();

        public Defect()
        {
        }

        #region IEvaluateAIDI

        public void Reset()
        {
            ResultOfAIDI = new ResultOfAIDI(null);
            Region = new ShapeOf2D();

            return;
        }

        public void CalculateRegion()
        {
            int numOfTiny = 0;
            int numOfObv = 0;
            ShapeOf2D regionOfTiny = new ShapeOf2D();
            ShapeOf2D regionOfObv = new ShapeOf2D();

            // clear region
            Region = new ShapeOf2D();
            // filter
            CurrTinyArea = double.MaxValue;
            CurrObvArea = double.MinValue;

            if (null != ResultOfAIDI.ResultDetailOfAIDI && 0 != ResultOfAIDI.ResultDetailOfAIDI.Count)
            {
                // reverse ResultOfAIDI.ResultDetailOfAIDI maybe better
                ResultOfAIDI.ResultDetailOfAIDI.Reverse();
                // filter
                foreach (var aidiResult in ResultOfAIDI.ResultDetailOfAIDI)
                {
                    CurrTinyArea = aidiResult.Area < CurrTinyArea ? aidiResult.Area : CurrTinyArea;
                    CurrObvArea = aidiResult.Area > CurrObvArea ? aidiResult.Area : CurrObvArea;

                    if (aidiResult.Area >= TinyAreaFilter)
                    {
                        ++numOfTiny;
                        regionOfTiny += aidiResult.Region;

                        if (aidiResult.Area >= ObvAreaFilter)
                        {
                            ++numOfObv;
                            regionOfObv += aidiResult.Region;
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                // judge
                if (numOfTiny >= TinyNumFilter)
                {
                    Region += regionOfTiny;
                }
                if (numOfObv >= ObvNumFilter)
                {
                    Region += regionOfObv;
                }
            }
            else
            {
                MessageManager.Instance().Info("Defect.CalculateRegion(): received no data.");
            }

            return;
        }
        
        #endregion
    }
}
