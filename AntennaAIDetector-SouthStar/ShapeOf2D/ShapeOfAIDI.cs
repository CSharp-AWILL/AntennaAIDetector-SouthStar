using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aqrose.Framework.Utility.DataStructure;

namespace AntennaAIDetector_SouthStar.ShapeOf2D
{
    public class ShapeOfAIDI
    {
        public double Area { get; private set; } = 0.0;
        public double CenterX { get; private set; } = 0.0;
        public double CenterY { get; private set; } = 0.0;
        public double Width { get; private set; } = 0.0;
        public double Height { get; private set; } = 0.0;
        public double Score { get; private set; } = 0.0;
        public string Type { get; private set; } = "";
        public List<PointShape> Contours { get; private set; } = new List<PointShape>();
        public ShapeOf2D ShapeOf2D { get; private set; } = new ShapeOf2D();

        public ShapeOfAIDI(AIDIShape badShape)
        {
            Area = Convert.ToDouble(badShape.area);
            CenterX = Convert.ToDouble(badShape.cx);
            CenterY = Convert.ToDouble(badShape.cy);
            Width = Convert.ToDouble(badShape.width);
            Height = Convert.ToDouble(badShape.height);
            Score = Convert.ToDouble(badShape.score);
            Type = badShape.type_name;
            //
            List<double> pointXs = new List<double>();
            List<double> pointYs = new List<double>();
            List<int> pointNums = new List<int>();
            foreach (var badPoint in badShape.contours)
            {
                var pointX = Convert.ToDouble(badPoint.x);
                var pointY = Convert.ToDouble(badPoint.y);
                var point = new PointShape(pointX, pointY);

                pointXs.Add(pointX);
                pointYs.Add(pointY);
                
                Contours.Add(point);
            }
            pointNums.Add(badShape.contours.Count);
            ShapeOf2D = new ShapeOf2D(pointYs, pointXs, pointNums);

        }
    }
}
