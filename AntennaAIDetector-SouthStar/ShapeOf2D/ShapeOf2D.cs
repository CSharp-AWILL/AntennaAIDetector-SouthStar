using System.Collections.Generic;

namespace AntennaAIDetector_SouthStar.ShapeOf2D
{
    public class ShapeOf2D
    {
        public List<double> XldPointYs { get; private set; } = new List<double>();
        public List<double> XldPointXs { get; private set; } = new List<double>();
        public List<int> XldPointsNums { get; private set; } = new List<int>();

        public ShapeOf2D()
        {
            XldPointYs = new List<double>();
            XldPointXs = new List<double>();
            XldPointsNums = new List<int>();
        }

        public ShapeOf2D(ShapeOf2D shape):this()
        {
            if (null != shape)
            {
                XldPointYs = shape.XldPointYs;
                XldPointXs = shape.XldPointXs;
                XldPointsNums = shape.XldPointsNums;
            }
        }

        public ShapeOf2D(List<double> xldPointYs, List<double> xldPointXs, List<int> xldPointsNums)
        {
            XldPointYs = xldPointYs;
            XldPointXs = xldPointXs;
            XldPointsNums = xldPointsNums;
        }

        //
        public void Reset()
        {
            if (null != XldPointYs)
            {
                XldPointYs.Clear();
            }
            else
            {
                XldPointYs = new List<double>();
            }
            if (null != XldPointXs)
            {
                XldPointXs.Clear();
            }
            else
            {
                XldPointXs = new List<double>();
            }
            if (null != XldPointsNums)
            {
                XldPointsNums.Clear();
            }
            else
            {
                XldPointsNums = new List<int>();
            }

            return;
        }

        public static ShapeOf2D operator +(ShapeOf2D a, ShapeOf2D b)
        {
            ShapeOf2D res = new ShapeOf2D();
            if (null != a)
            {
                res.XldPointYs.AddRange(a.XldPointYs);
                res.XldPointXs.AddRange(a.XldPointXs);
                res.XldPointsNums.AddRange(a.XldPointsNums);
            }
            if(null!=b)
            {
                res.XldPointYs.AddRange(b.XldPointYs);
                res.XldPointXs.AddRange(b.XldPointXs);
                res.XldPointsNums.AddRange(b.XldPointsNums);
            }

            return res;
        }

    }
}
