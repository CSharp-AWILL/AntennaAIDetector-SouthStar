using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntennaAIDetector_SouthStar.Core;
using Aqrose.Framework.Utility.DataStructure;

namespace AntennaAIDetector_SouthStar.Product
{
    public class ResultOfAIDI
    {
        //public bool IsResultOKOfAIDI { get; set; } = true;
        public List<ShapeOfAIDI> ResultDetailOfAIDI { get; set; } = new List<ShapeOfAIDI>();
        public ShapeOf2D RawRegion { get; set; } = new ShapeOf2D();

        private void InitializeRawRegion()
        {
            RawRegion = new ShapeOf2D();
            foreach (var temp in ResultDetailOfAIDI)
            {
                RawRegion += temp.Region;
            }

            return;
        }

        private ResultOfAIDI()
        {
            ResultDetailOfAIDI = new List<ShapeOfAIDI>();
            RawRegion = new ShapeOf2D();
        }

        public ResultOfAIDI(List<AIDIShape> badInputData):this()
        {
            if (null != badInputData)
            {
                foreach (var badAIDIShape in badInputData)
                {
                    ResultDetailOfAIDI.Add(new ShapeOfAIDI(badAIDIShape));
                }
                ResultDetailOfAIDI.Sort();
                InitializeRawRegion();
            }
        }
        
    }
}
