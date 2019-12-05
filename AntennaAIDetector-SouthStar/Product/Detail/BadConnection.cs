using System.Collections.Generic;
using SimpleGroup.Core.Struct;

namespace AntennaAIDetector_SouthStar.Product.Detail
{
    public class BadConnection:IEvaluateAIDI
    {
        public bool IsAddToDetection { get; set; } = true;
        public bool IsResultOK
        {
            get
            {
                return 0 == Region.XldPointsNums.Count;
            }
        }

        public ResultOfAIDI ResultOfAIDI { get; set; } = new ResultOfAIDI(null);
        public ShapeOf2D Region { get; set; } = new ShapeOf2D();

        public BadConnection()
        {
        }

        #region IEvaluateAIDI
        public void CalculateRegion()
        {
            // LABEL: do nothing
            Region = new ShapeOf2D();
            Region = ResultOfAIDI.RawRegion;
        }
        #endregion
    }
}
