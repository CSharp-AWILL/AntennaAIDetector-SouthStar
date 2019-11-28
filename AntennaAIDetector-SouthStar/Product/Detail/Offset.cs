using System.Collections.Generic;
using AntennaAIDetector_SouthStar.Core;
using Aqrose.Framework.Utility.DataStructure;

namespace AntennaAIDetector_SouthStar.Product.Detail
{
    public class Offset:IEvaluateAIDI
    {
        public bool IsAddToDetection { get; set; } = true;
        public bool IsResultOK
        {
            get
            {
                return 0 == Region.XldPointsNums.Count;
            }
        }

        public double StandardXFilter { get; set; } = 0.0;
        public double StandardYFilter { get; set; } = 0.0;
        public double UpFilter { get; set; } = 0.0;
        public double DownFilter { get; set; } = 0.0;
        public double LeftFilter { get; set; } = 0.0;
        public double RightFilter { get; set; } = 0.0;
        //
        public double CurrX { get; set; } = 0.0;
        public double CurrY { get; set; } = 0.0;
        //
        public ResultOfAIDI ResultOfAIDI { get; set; } = new ResultOfAIDI(null);
        public ShapeOf2D Region { get; set; } = new ShapeOf2D();

        public Offset()
        {
        }

        private bool IsInRange(PointShape point)
        {
            if (null == point)
            {
                return false;
            }

            point.GetPoint(out var x, out var y);
            if (StandardXFilter - LeftFilter >= x || StandardXFilter + RightFilter <= x || StandardYFilter - UpFilter >= y || StandardYFilter + DownFilter <= y)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        #region IEvaluateAIDI
        public void CalculateRegion()
        {
            if (null != ResultOfAIDI.ResultDetailOfAIDI && 0 != ResultOfAIDI.ResultDetailOfAIDI.Count)
            {
                foreach (var aidiResult in ResultOfAIDI.ResultDetailOfAIDI.GetRange(ResultOfAIDI.ResultDetailOfAIDI.Count - 1, 1))
                {
                    if (!IsInRange(new PointShape(aidiResult.CenterX, aidiResult.CenterY)))
                    {
                        Region += aidiResult.Region;
                    }
                }
            }

            return;
        }
        #endregion
    }

}
