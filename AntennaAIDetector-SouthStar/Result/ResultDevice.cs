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
        private Task.Task _taskDevice = null;
        private static ResultDevice _instance = null;
        private Queue<SingleResult> _singleResults = new Queue<SingleResult>();

        public static Object PAD_LOCK = new object();

        public string HeadString { get; private set; } = "";
        public string ResultString { get; private set; } = "";
        public int TaskSize
        {
            get
            {
                if (null == _taskDevice)
                {
                    return 0;
                }
                else
                {
                    return _taskDevice.TaskSize;
                }
            }
        }

        public int TotalSize
        {
            get
            {
                if (null == _taskDevice)
                {
                    return 0;
                }
                else
                {
                    return _taskDevice.TotalSize;
                }
            }
        }

        private ResultDevice()
        {
            _taskDevice = Task.TaskPool.GetInstance();
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
            int groupCount = TotalSize / TaskSize + Convert.ToInt32(0 != TotalSize / TaskSize);
            int index = 0;

            for (int i = 0; i < groupCount; ++i)
            {
                for (int j = 0; j < TaskSize; ++j)
                {
                    index = i * TaskSize + j;
                    if (TotalSize <= index)
                    {
                        break;
                    }
                    res += (TotalSize.ToString() + "_" + index.ToString() + ",");
                }
            }

            HeadString = res;

            return res;
        }

        public bool IsQueueFull()
        {
            MessageManager.Instance().Info("ResultDevice.IsQueueFull: _singleResults.Count is " + _singleResults.Count.ToString());
            return _taskDevice.TotalSize == _singleResults.Count;
        }

        public string GenerateDstMessage()
        {
            string res = "";
            int groupCount = TotalSize / TaskSize + Convert.ToInt32(0 != TotalSize / TaskSize);
            /*
             * first dim: channel
             * second dim: index
             */

            Queue<SingleResult>[] singleResultsOfSingleChannel = new Queue<SingleResult>[5]
            {
                    new Queue<SingleResult>(),
                    new Queue<SingleResult>(),
                    new Queue<SingleResult>(),
                    new Queue<SingleResult>(),
                    new Queue<SingleResult>()
            };

            string[][] resultArrayOfSingleChannel = new string[5][]
            {
                new string[10]
                {
                    "x", "x", "x", "x", "x",
                    "x", "x", "x", "x", "x"
                },
                new string[10]
                {
                    "x", "x", "x", "x", "x",
                    "x", "x", "x", "x", "x"
                },
                new string[10]
                {
                    "x", "x", "x", "x", "x",
                    "x", "x", "x", "x", "x"
                },
                new string[10]
                {
                    "x", "x", "x", "x", "x",
                    "x", "x", "x", "x", "x"
                },
                new string[10]
                {
                    "x", "x", "x", "x", "x",
                    "x", "x", "x", "x", "x"
                }
            };

            // translate queue
            var size = _singleResults.Count;
            for (int indexOfResultQueue = 0; indexOfResultQueue < Math.Max(TotalSize, size); ++indexOfResultQueue)
            {
                if (0 >= _singleResults.Count)
                {
                    break;
                }
                var singleResult = _singleResults.Dequeue();
                //int channel = singleResult.Index;
                //int index = indexOfResultQueue / Math.Max(1, TaskSize);
                //resultArrayOfSingleChannel[channel][index]= singleResult.DefectInfo;
                if (singleResult.Index >= singleResultsOfSingleChannel.Length)
                {
                    MessageManager.Instance().Alarm("ResultDevice.GenerateDstMessage: need to enlarge singleResultsOfSingleChannel.");
                    continue;
                }
                singleResultsOfSingleChannel[singleResult.Index].Enqueue(singleResult);
            }
            // pick out and fill in bucket
            foreach (var singleResults in singleResultsOfSingleChannel)
            {
                int channel = 0;
                int index = 0;
                for (; singleResults.Count > 0;)
                {
                    var singleResult = singleResults.Dequeue();
                    resultArrayOfSingleChannel[channel][index++] = singleResult.DefectInfo;
                }
                channel++;
            }
            // generate
            for (int i = 0; i < groupCount; ++i)
            {
                for (int j = 0; j < TaskSize; ++j)
                {
                    var index = i * TaskSize + j;
                    if (TotalSize <= index)
                    {
                        break;
                    }
                    res += (resultArrayOfSingleChannel[j][i] + ",");
                }
            }

            ResultString = res;

            return res;
        }

    }
}
