using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntennaAIDetector_SouthStar.Result
{
    public class SingleResult
    {
        public int Index { get; private set; } = 0;
        public string DefectInfo { get; private set; } = "";
        public DisplayChar DisplayChar { get; private set; } = new DisplayChar();

        private SingleResult()
        {
        }

        public SingleResult(int index, string defectInfo)
        {
            Index = index;
            DefectInfo = defectInfo;
        }

        
    }
}
