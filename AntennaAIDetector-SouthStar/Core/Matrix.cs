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
        public double ModelX { get; private set; } = 0.0;
        public double ModelY { get; private set; } = 0.0;
        public double ModelA { get; private set; } = 0.0;
        public double ResultX { get; private set; } = 0.0;
        public double ResultY { get; private set; } = 0.0;
        public double ResultA { get; private set; } = 0.0;

        public Matrix() : base(0.0, 0.0, 0.0, 0.0, 0.0, 0.0)
        {
        }

        public Matrix(AffineMatrix affineMatrix):this()
        {
            affineMatrix.GetAffineMatrix(out var modelX, out var modelY, out var modelA, out var resultX, out var resultY, out var resultA);
            ModelX = modelX;
            ModelY = modelY;
            ModelA = modelA;
            ResultX = resultX;
            ResultY = resultY;
            ResultA = resultA;
        }

        public Matrix(double modelX, double modelY, double modelA, double resultX, double resultY, double resultA) : base(modelX, modelY, modelA, resultX, resultY, resultA)
        {
        }

    }
}
