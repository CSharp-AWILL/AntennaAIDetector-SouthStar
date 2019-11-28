﻿using System.Collections.Generic;
using AntennaAIDetector_SouthStar.Core;

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
        public ResultOfAIDI ResultOfAIDI { get; set; } = new ResultOfAIDI(null);
        public ShapeOf2D Region { get; set; } = new ShapeOf2D();

        public Defect()
        {
        }

        #region IEvaluateAIDI
        public void CalculateRegion()
        {
            int numOfTiny = 0;
            int numOfObv = 0;
            ShapeOf2D regionOfTiny = new ShapeOf2D();
            ShapeOf2D regionOfObv = new ShapeOf2D();

            // filter
            foreach (var aidiResult in ResultOfAIDI.ResultDetailOfAIDI)
            {
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

            return;
        }
        #endregion
    }
}
