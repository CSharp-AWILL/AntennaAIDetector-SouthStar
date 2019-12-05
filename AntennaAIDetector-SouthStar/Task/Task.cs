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
        public int Length
        {
            get
            {
                if (null == Images)
                {
                    return 0;
                }
                else
                {
                   return Images.Count;
                }
            }
        }

        public Task()
        {
            //Counters.Add(0);
            //Counters.Add(0);
            //Counters.Add(0);
        }

        public Bitmap PopBitmap(int index)
        {
            lock (_padLock)
            {
                if (null != Images && index < Images.Count && 0 < Images[index].Count)
                {
                    return Images[index].Dequeue().Clone() as Bitmap;
                }
                else
                {
                   return null;
                }
            }
        }

        public Bitmap GetBitmap(int index)
        {
            lock (_padLock)
            {
                if (null != Images && index < Images.Count && 0 < Images[index].Count)
                {
                    return Images[index].Peek().Clone() as Bitmap;
                }
                else
                {
                    return null;
                }
            }
        }

        public bool TryPushImages(List<Bitmap> source)
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
