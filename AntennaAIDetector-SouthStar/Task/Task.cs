using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Aqrose.Framework.Utility.MessageManager;

namespace AntennaAIDetector_SouthStar.Task
{
    public class Task
    {
        private static object _padLock = new object();

        public List<Queue<Bitmap>> Images { get; set; } = new List<Queue<Bitmap>>();

        public Task()
        {
            //Counters.Add(0);
            //Counters.Add(0);
            //Counters.Add(0);
        }

        private bool IsTaskOK(int index)
        {
            //if (null != Counters && null != Images && Counters.Count == Images.Count && index < Counters.Count)
            {
                //foreach (var temp in Counters)
                {
                    //if (Math.Abs(temp - Counters[index]) > 1)
                    {
                        //MessageManager.Instance().Alarm("Task.IsTaskOK: 计数器不同步！");

                        //return false;
                    }
                }

                return true;
            }
            //else
            {
                //MessageManager.Instance().Alarm("Task.IsTaskOK: 计数器异常！");

                //return false;
            }
        }

        private void IncreaseCount(int index)
        {
            //if (null == Counters || index >= Counters.Count)
            //{
            //    MessageManager.Instance().Alarm("Task.Counters: 计数异常！");

            //    return;
            //}
            //Counters[index] = (Counters[index] + 1) % int.MaxValue;

            return;
        }

        public Bitmap GetBitmap(int index)
        {
            lock (_padLock)
            {
                if (IsTaskOK(index))
                {
                    if (null != Images && index < Images.Count && 0 < Images[index].Count)
                    {
                        return Images[index].Dequeue().Clone() as Bitmap;
                    }

                    IncreaseCount(index);
                }

                return null;
            }
        }

        public bool TryRefreshImages(List<Bitmap> source)
        {
            lock (_padLock)
            {
                if (null == source)
                {
                    
                    return false;
                }

                //
                for (int index = 0; index < source.Count; ++index)
                {
                    if (Images[index].Count > 0)
                    {
                        return false;
                    }
                }

                //
                for (int index = 0; index < source.Count; ++index)
                {
                    Images[index].Enqueue(source[index].Clone() as Bitmap);
                }

                return true;
            }
        }

        public void SetType(int number)
        {
            Images = new List<Queue<Bitmap>>();
            if (number > 0)
            {
                for (int index = 0; index < number; ++index)
                {
                    Images.Add(new Queue<Bitmap>());
                }
            }

            return;
        }

    }
}
