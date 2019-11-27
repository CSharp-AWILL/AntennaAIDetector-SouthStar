using System.Collections.Generic;
using AntennaAIDetector_SouthStar.Core;

namespace AntennaAIDetector_SouthStar.Product.Detail
{
    public class Defect:IEvaluateAIDI
    {
        public bool IsAddToDetection { get; set; } = true;
        public bool IsResultOKOfAIDI { get; set; } = true;

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
            throw new System.NotImplementedException();
        }
        #endregion
    }
}
