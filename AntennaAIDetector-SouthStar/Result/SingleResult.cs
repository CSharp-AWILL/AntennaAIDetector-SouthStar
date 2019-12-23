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

        public void SetDisplayChar(int heightOfImage)
        {
            DisplayChar.Text = DefectInfo;
            DisplayChar.Position = new Point(10, heightOfImage * Index + 10);
            DisplayChar.Size = new Size(200, 200);
            DisplayChar.Color = Color.Red;
        }
    }
}
