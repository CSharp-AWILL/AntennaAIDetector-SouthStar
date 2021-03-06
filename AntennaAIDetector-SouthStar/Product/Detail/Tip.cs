﻿using System.Collections.Generic;
using SimpleGroup.Core.Struct;

namespace AntennaAIDetector_SouthStar.Product.Detail
{
    public class Tip:IEvaluateAIDI
    {
        public bool IsAddToDetection { get; set; } = true;
        public bool IsResultOK { get; set; } = true;

        public ResultOfAIDI ResultOfAIDI { get; set; } = new ResultOfAIDI(null);
        public ShapeOf2D Region { get; set; } = new ShapeOf2D();

        public Tip()
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
            // LABEL: do nothing
            //Region = new ShapeOf2D();
            //Region = ResultOfAIDI.RawRegion;
        }

        #endregion
    }
}
