using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntennaAIDetector_SouthStar.View;
using Aqrose.Framework.Utility.MessageManager;
using Aqrose.Framework.Utility.Tools;

namespace AntennaAIDetector_SouthStar.Result
{
    // Singleton
    public class ResultDevice
    {
        private static ResultDevice _instance = null;
        private Queue<SingleResult> _singleResults = new Queue<SingleResult>();

        public static Object PAD_LOCK = new object();
        public int TaskSize { get; private set; } = 0;
        public int TotalSize { get; private set; } = 0;

        private ResultDevice()
        {
            LoadConfiguration();
        }

        public static ResultDevice GetInstance()
        {
            if (null == _instance)
            {
                lock (PAD_LOCK)
                {
                    if (null == _instance)
                    {
                        _instance = new ResultDevice();
                    }
                }
            }

            return _instance;
        }

        public void LoadConfiguration()
        {
            TaskModeForm.LoadConfiguration(out var taskSize, out var totalSize);
            TaskSize = taskSize;
            TotalSize = totalSize;

            return;
        }

        public void Clear()
        {
            _singleResults = new Queue<SingleResult>();

            return;
        }

        public void Enqueue(SingleResult singleResult)
        {
            if (null == singleResult)
            {
                MessageManager.Instance().Warn("Result.Enqueue: null singleResult.");

                return;
            }

            _singleResults.Enqueue(singleResult);

            return;
        }

        public string GenerateHeaderString()
        {
            string res = "";

            for (int i = 0; i < TotalSize / TaskSize; ++i)
            {
                for (int j = 0; j < TaskSize; ++j)
                {
                    res += (TotalSize.ToString() + "-" + (i * TaskSize + j).ToString() + ",");
                }
            }

            return res;
        }

        public string GenerateDstMessage()
        {
            string res = "";
            string[] resultArray = new string[20] 
            {
                "", "", "", "", "",
                "", "", "", "", "",
                "", "", "", "", "",
                "", "", "", "", ""
            };

            for (int i = 0; i < TotalSize / TaskSize; ++i)
            {
                for (int j = 0; j < TaskSize; ++j)
                {
                    var singleResult = _singleResults.Dequeue();
                    if (null != singleResult)
                    {
                        resultArray[singleResult.Index + TaskSize * i] = singleResult.DefectInfo;
                    }
                }
            }
            for (int i = 0; i < TotalSize; ++i)
            {
                res += (resultArray[i] + ",");
            }

            return res;
        }

    }
}
