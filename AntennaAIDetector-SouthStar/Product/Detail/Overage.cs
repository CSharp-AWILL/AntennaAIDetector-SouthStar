using System.Collections.Generic;
using AntennaAIDetector_SouthStar.Core;

namespace AntennaAIDetector_SouthStar.Product.Detail
{
    public class Overage
    {
        public bool IsAddToDetection { get; set; } = true;
        public double StandardAreaFilter { get; set; } = 0.0;
        public double TinyAreaFilter { get; set; } = 0.0;
        public int TinyNumFilter { get; set; } = 0;
        public double ObvAreaFilter { get; set; } = 0.0;
        public int ObvNumFilter { get; set; } = 0;
        //
        public ShapeOf2D Region { get; set; } = new ShapeOf2D();
        public bool IsResultOKOfAIDI { get; set; } = true;
        public List<ShapeOfAIDI> ResultDetailOfAIDI { get; set; } = new List<ShapeOfAIDI>();
    }
}
