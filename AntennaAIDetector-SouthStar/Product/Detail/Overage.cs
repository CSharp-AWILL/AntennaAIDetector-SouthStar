using System;
using System.Collections.Generic;
using SimpleGroup.Core.Struct;

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


        public int Number { get; set; } = 2;
        public double AreaOfLeftFilter { get; set; } = 0.0;
        public double AreaOfRightFilter { get; set; } = 0.0;
        public double AreaOfRightFilter1 { get; set; } = 0.0;
        //
        public double CurrAreaOfLeft { get; /*private*/ set; } = 0.0;
        public double CurrAreaOfRight { get; /*private*/ set; } = 0.0;
        public double CurrAreaOfRight1 { get; /*private*/ set; } = 0.0;
        //
        public ResultOfAIDI ResultOfAIDI { get; set; } = new ResultOfAIDI(null);
        public ShapeOf2D Region { get; set; } = new ShapeOf2D();

        public Overage()
        {
        }

        private bool TryGetXOfAIDIResult()
        {
            List<double> tempX = new List<double>();
            if (Number > ResultOfAIDI.ResultDetailOfAIDI.Count)
            {
                return false;
            }
            foreach (var aidiResult in ResultOfAIDI.ResultDetailOfAIDI.GetRange(ResultOfAIDI.ResultDetailOfAIDI.Count- Number, Number))
            {
                tempX.Add(aidiResult.CenterX);
            }
            // assert
            if (Number != tempX.Count || tempX[0] == tempX[1])
            {
                return false;
            }
            for (int index = 0; index < Number - 1; ++index)
            {
                if (tempX[index] == tempX[index + 1])
                {
                    return false;
                }
            }

            // sort
            tempX.Sort();
            _xOfAIDIResult = tempX;

            return true;
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
            Region = new ShapeOf2D();
            if (null != ResultOfAIDI.ResultDetailOfAIDI && Number <= ResultOfAIDI.ResultDetailOfAIDI.Count && TryGetXOfAIDIResult())
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
                    else if (_xOfAIDIResult[1] == aidiResult.CenterX)
                    {
                        // right
                        CurrAreaOfRight = aidiResult.Area;
                        if (aidiResult.Area >= AreaOfRightFilter)
                        {
                            Region += aidiResult.Region;
                        }
                    }
                    else if (3 == Number && _xOfAIDIResult[2] == aidiResult.CenterX)
                    {
                        // right1
                        CurrAreaOfRight1 = aidiResult.Area;
                        if (aidiResult.Area >= AreaOfRightFilter1)
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
