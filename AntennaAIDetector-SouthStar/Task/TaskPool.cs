using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntennaAIDetector_SouthStar.Task
{
    public class TaskPool
    {
        static private Task _instance = null;

        static public readonly object PadLock = new object();

        private TaskPool()
        {
        }

        static public Task GetInstance()
        {
            if (null == _instance)
            {
                lock (PadLock)
                {
                    if (null == _instance)
                    {
                        _instance = new Task();
                    }
                }
            }

            return _instance;
        }

    }
}
