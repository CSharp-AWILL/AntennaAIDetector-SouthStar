using AntennaAIDetector_SouthStar.Algorithm;
using SimpleGroup.Core.Struct;
using Aqrose.Framework.Utility.DataStructure;
using System.Drawing;

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

        //
        public MatrixD Matrix { get; set; } = null;

        public double StandardXFilter { get; set; } = 0.0;
        public double StandardYFilter { get; set; } = 0.0;
        public double UpFilter { get; set; } = 0.0;
        public double DownFilter { get; set; } = 0.0;
        public double LeftFilter { get; set; } = 0.0;
        public double RightFilter { get; set; } = 0.0;
        //
        public double CurrX { get; /*private*/ set; } = 0.0;
        public double CurrY { get; /*private*/ set; } = 0.0;
        //
        public ResultOfAIDI ResultOfAIDI { get; set; } = new ResultOfAIDI(null);
        public ShapeOf2D Region { get; set; } = new ShapeOf2D();

        //
        public PointF StandardPoint
        {
            get
            {
                CorrectPos(new PointF((float)StandardXFilter, (float)StandardYFilter), out var res);
                return res;
            }
        }

        public PointF CurrPoint
        {
            get
            {
                CorrectPos(new PointF((float)CurrX, (float)CurrY), out var res);
                return res;
            }
        }

        public Offset()
        {
        }

        private void CorrectPos(PointF org, out PointF res)
        {
            res= org;
            return;


            res = PointF.Empty;
            if (null == org)
            {
                return;
            }
            if (null == Matrix)
            {
                Matrix = new MatrixD();
            }
            Affine.AffineTransPoint2D(Matrix/*.GetReverseMatrixD()*/, org, out res);

            return;
        }

        private bool IsInRange(PointF point)
        {
            if (null == point)
            {
                return false;
            }
            //CorrectPos(new PointShape(StandardXFilter, StandardYFilter), out var standardPoint);
            //standardPoint.GetPoint(out var standardX, out var standardY);
            if (StandardXFilter - LeftFilter >= point.X || StandardXFilter + RightFilter <= point.X || StandardYFilter - UpFilter >= point.Y || StandardYFilter + DownFilter <= point.Y)
            {
                return false;
            }
            else
            {
                return true;
            }
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
            if (null != ResultOfAIDI.ResultDetailOfAIDI && 0 != ResultOfAIDI.ResultDetailOfAIDI.Count)
            {
                foreach (var aidiResult in ResultOfAIDI.ResultDetailOfAIDI.GetRange(ResultOfAIDI.ResultDetailOfAIDI.Count - 1, 1))
                {
                    if (!IsInRange(new PointF((float)aidiResult.CenterX, (float)aidiResult.CenterY)))
                    {
                        Region += aidiResult.Region;
                    }
                    CurrX = aidiResult.CenterX;
                    CurrY = aidiResult.CenterY;
                }
            }

            return;
        }

        #endregion
    }

}
