using System.Drawing;
using Aqrose.Framework.Utility.DataStructure;
using HalconDotNet;
using SimpleGroup.Core.Struct;

namespace AntennaAIDetector_SouthStar.Algorithm
{
    public static class Affine
    {
        public static void AffineTransPoint2D(MatrixD matrix, PointF org, out PointF dst)
        {
            dst = PointF.Empty;
            if (null == matrix || null == org)
            {
                return;
            }
            HOperatorSet.VectorAngleToRigid(matrix.ModelY, matrix.ModelX, matrix.ModelA, matrix.ResultY, matrix.ResultX, matrix.ResultA, out var hv_HomMat2D);
            HOperatorSet.AffineTransPoint2d(hv_HomMat2D, org.X, org.Y, out var hv_DstX, out var hv_DstY);
            if (null != hv_DstX && null != hv_DstY)
            {
                dst = new PointF((float)hv_DstX.D, (float)hv_DstY.D);
            }

            return;
        }

    }
}
