using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aqrose.Framework.Utility.DataStructure;
using HalconDotNet;
using SimpleGroup.Core.Struct;

namespace AntennaAIDetector_SouthStar.Algorithm
{
    public static class Affine
    {
        public static void AffineTransPoint2D(MatrixD matrix, PointShape org, out PointShape dst)
        {
            dst = null;
            if (null == matrix || null == org)
            {
                return;
            }
            HOperatorSet.VectorAngleToRigid(matrix.ModelY, matrix.ModelX, matrix.ModelA, matrix.ResultY, matrix.ResultX, matrix.ResultA, out var hv_HomMat2D);
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
