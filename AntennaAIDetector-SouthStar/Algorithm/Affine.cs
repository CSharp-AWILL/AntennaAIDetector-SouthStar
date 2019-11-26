using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aqrose.Framework.Utility.DataStructure;
using HalconDotNet;

namespace AntennaAIDetector_SouthStar.Algorithm
{
    public static class Affine
    {
        public static void AffineTransPoint2D(AffineMatrix matrix, PointShape org, out PointShape dst)
        {
            dst = null;
            if (null == matrix || null == org)
            {
                return;
            }
            matrix.GetAffineMatrix(out var modelX, out var modelY, out var modelA, out var resultX, out var resultY, out var resultA);
            HOperatorSet.VectorAngleToRigid(modelY, modelX, modelA, resultY, resultX, resultA, out var hv_HomMat2D);
            org.GetPoint(out var orgX, out var orgY);
            HOperatorSet.AffineTransPoint2d(hv_HomMat2D, orgX, orgY, out var hv_DstX, out var hv_DstY);
            if (null != hv_DstX && null != hv_DstY)
            {
                dst = new PointShape(hv_DstX.D, hv_DstY.D);
            }

            return;
        }

    }
}
