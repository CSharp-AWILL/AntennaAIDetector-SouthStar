using System;
using System.Collections.Generic;
using AntennaAIDetector_SouthStar.Core;

namespace AntennaAIDetector_SouthStar.Product.Detail
{
    public class Overage:IEvaluateAIDI
    {
        private List<double> _xOfAIDIResult = new List<double>();

        public bool IsAddToDetection { get; set; } = true;
        public bool IsResultOK
        {
            get
            {
                return 0 == Region.XldPointsNums.Count;
            }
        }

        public double AreaOfLeftFilter { get; set; } = 0.0;
        public double AreaOfRightFilter { get; set; } = 0.0;
        //
        public double CurrAreaOfLeft { get; /*private*/ set; } = 0.0;
        public double CurrAreaOfRight { get; /*private*/ set; } = 0.0;
        //
        public ResultOfAIDI ResultOfAIDI { get; set; } = new ResultOfAIDI(null);
        public ShapeOf2D Region { get; set; } = new ShapeOf2D();

        public Overage()
        {
        }

        private bool TryGetXOfAIDIResult()
        {
            List<double> tempX = new List<double>();
            if (2 > ResultOfAIDI.ResultDetailOfAIDI.Count)
            {
                return false;
            }
            foreach (var aidiResult in ResultOfAIDI.ResultDetailOfAIDI.GetRange(ResultOfAIDI.ResultDetailOfAIDI.Count-2, 2))
            {
                tempX.Add(aidiResult.CenterX);
            }
            // assert
            if (2 != tempX.Count || tempX[0] == tempX[1])
            {
                return false;
            }
            // sort
            tempX.Sort();
            _xOfAIDIResult = tempX;

            return true;
        }

        #region IEvaluateAIDI

        public void CalculateRegion()
        {
            Region = new ShapeOf2D();
            if (null != ResultOfAIDI.ResultDetailOfAIDI && 2 <= ResultOfAIDI.ResultDetailOfAIDI.Count && TryGetXOfAIDIResult())
            {
                foreach (var aidiResult in ResultOfAIDI.ResultDetailOfAIDI.GetRange(ResultOfAIDI.ResultDetailOfAIDI.Count - 2, 2))
                {
                    if (_xOfAIDIResult[0] == aidiResult.CenterX)
                    {
                        // left
                        CurrAreaOfLeft = aidiResult.Area;
                        if (aidiResult.Area >= AreaOfLeftFilter)
                        {
                            Region += aidiResult.Region;
                        }
                    }
                    else
                    {
                        // right
                        CurrAreaOfRight = aidiResult.Area;
                        if (aidiResult.Area >= AreaOfRightFilter)
                        {
                            Region += aidiResult.Region;
                        }
                    }
                }
            }
            else
            {
                foreach (var aidiResult in ResultOfAIDI.ResultDetailOfAIDI)
                {
                    Region += aidiResult.Region;
                }
            }

            return;
        }

        #endregion
    }
}
