using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aqrose.Framework.Utility.DataStructure;

namespace AntennaAIDetector_SouthStar.Core
{
    public class Matrix:AffineMatrix
    {
        public Matrix() : base(0.0, 0.0, 0.0, 0.0, 0.0, 0.0)
        {
        }

        public Matrix(double modelX, double modelY, double modelA, double resultX, double resultY, double resultA) : base(modelX, modelY, modelA, resultX, resultY, resultA)
        {
        }

    }
}
