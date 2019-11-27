﻿using System.Collections.Generic;
using AntennaAIDetector_SouthStar.Core;

namespace AntennaAIDetector_SouthStar.Product.Detail
{
    public class BadConnection:IEvaluateAIDI
    {
        public bool IsAddToDetection { get; set; } = true;
        public bool IsResultOKOfAIDI { get; set; } = true;

        public ResultOfAIDI ResultOfAIDI { get; set; } = new ResultOfAIDI(null);
        public ShapeOf2D Region { get; set; } = new ShapeOf2D();

        public BadConnection()
        {
        }

        #region IEvaluateAIDI
        public new void CalculateRegion()
        {
            Region = ResultOfAIDI.RawRegion;
        }
        #endregion
    }
}
