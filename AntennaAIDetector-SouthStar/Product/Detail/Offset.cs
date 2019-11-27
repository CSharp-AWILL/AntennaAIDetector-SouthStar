using System.Collections.Generic;
using AntennaAIDetector_SouthStar.Core;

namespace AntennaAIDetector_SouthStar.Product.Detail
{
    public class Offset
    {
        public bool IsAddToDetection { get; set; } = true;
        //
        public ShapeOf2D Region { get; set; } = new ShapeOf2D();
        public bool IsResultOKOfAIDI { get; set; } = true;
        public List<ShapeOfAIDI> ResultDetailOfAIDI { get; set; } = new List<ShapeOfAIDI>();
    }

}
