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
        public double CurrAreaOfLeft { get; private set; } = 0.0;
        public double CurrAreaOfRight { get; private set; } = 0.0;
        //
        public ResultOfAIDI ResultOfAIDI { get; set; } = new ResultOfAIDI(null);
        public ShapeOf2D Region { get; set; } = new ShapeOf2D();

        public Overage()
        {
        }

        private bool TryGetXOfAIDIResult()
        {
            List<double> tempX = new List<double>();
            foreach (var aidiResult in ResultOfAIDI.ResultDetailOfAIDI)
            {
                tempX.Add(aidiResult.CenterX);
            }
            // assert
            if (2 != tempX.Count || tempX[0] != tempX[1])
            {
                _xOfAIDIResult = tempX;
                return false;
            }
            // sort
            if (tempX[0] > tempX[1])
            {
                _xOfAIDIResult.Add(tempX[1]);
                _xOfAIDIResult.Add(tempX[0]);
            }
            else
            {
                _xOfAIDIResult.Add(tempX[0]);
                _xOfAIDIResult.Add(tempX[1]);
            }

            return true;
        }

        #region IEvaluateAIDI
        public void CalculateRegion()
        {
            if (!TryGetXOfAIDIResult())
            {
                foreach (var aidiResult in ResultOfAIDI.ResultDetailOfAIDI)
                {
                    Region += aidiResult.Region;
                }
                return;
            }
            foreach (var aidiResult in ResultOfAIDI.ResultDetailOfAIDI)
            {
                if (_xOfAIDIResult[0] == aidiResult.CenterX)
                {
                    // left
                    CurrAreaOfLeft = aidiResult.Area;
                    if (aidiResult.Area  >= AreaOfLeftFilter)
                    {
                        Region += aidiResult.Region;
                    }
                }
                else
                {
                    // right
                    CurrAreaOfRight = aidiResult.Area;
                    if (aidiResult.Area  >= AreaOfRightFilter)
                    {
                        Region += aidiResult.Region;
                    }
                }
            }
        }
        #endregion
    }
}
