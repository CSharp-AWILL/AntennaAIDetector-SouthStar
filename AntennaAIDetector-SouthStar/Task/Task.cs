using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Aqrose.Framework.Utility.MessageManager;
using Aqrose.Framework.Utility.Tools;

namespace AntennaAIDetector_SouthStar.Task
{
    public class Task
    {
        //public static readonly object PAD_LOCK = new object();

        public List<Queue<Bitmap>> ImageQueues { get; set; } = new List<Queue<Bitmap>>();

        public Task()
        {
            //
        }

        private int GetTaskAmount()
        {
            int amount = 0;
            foreach (var queue in ImageQueues)
            {
                amount += queue.Count;
            }

            return amount;
        }

        public int GetTaskSize()
        {
            /*
             * return -1: error
             * return n: the list of queue count
             */
            if (null == ImageQueues)
            {
                return -1;
            }

            return ImageQueues.Count;
        }

        public Bitmap PopBitmap(int index)
        {
            Bitmap temp = null;
            if (null != ImageQueues && index < ImageQueues.Count && 0 < ImageQueues[index].Count)
            {
                var image = ImageQueues[index].Dequeue();
                temp = image.Clone(new Rectangle(0, 0, image.Width, image.Height), System.Drawing.Imaging.PixelFormat.DontCare);
                //temp = ImageOperateTools.ImageCopy(ImageQueues[index].Dequeue());
                //return Images[index].Dequeue().Clone() as Bitmap;
            }
            MessageManager.Instance().Info("Task.Pop: " + index);

            return temp;
        }

        public Bitmap GetBitmap(int index)
        {
            if (null != ImageQueues && index < ImageQueues.Count && 0 < ImageQueues[index].Count)
            {
                return ImageOperateTools.ImageCopy(ImageQueues[index].Peek());
                //return Images[index].Peek().Clone() as Bitmap;
            }
            else
            {
                return null;
            }
        }

        public bool TryPushImages(List<Bitmap> source)
        {
            if (null == source)
            {
                return false;
            }

            //
            if (source.Count != GetTaskSize())
            {
                MessageManager.Instance().Alarm("Task: unexcepted case!");
            }

            //
            for (int index = 0; index < source.Count; ++index)
            {
                //var temp = ImageOperateTools.ImageCopy(source[index]);
                var image = source[index];
                var temp = image.Clone(new Rectangle(0, 0, image.Width, image.Height), System.Drawing.Imaging.PixelFormat.DontCare);
                ImageQueues[index].Enqueue(temp);
                //Images[index].Enqueue(source[index].Clone() as Bitmap);

                MessageManager.Instance().Info("Task.Push: " + index);
            }

            return true;
        }

        public void SetTaskSize(int number)
        {
            ImageQueues = new List<Queue<Bitmap>>();
            if (number > 0)
            {
                for (int index = 0; index < number; ++index)
                {
                    ImageQueues.Add(new Queue<Bitmap>());
                }
            }

            return;
        }

        public void GetStatusOfQueue(int index, out int status)
        {
            /*
             * >index -1: all queue
             * >index n: queue at index n of the list
             * >status -1: error
             * >status 0: empty
             * >status n: number of image
             */

            status = 0;

            if (/*-1 == GetTaskSize() || */index >= GetTaskSize())
            {
                status = -1;

                return;
            }

            switch (index)
            {
                case -1:
                    status += GetTaskAmount();
                    break;
                default:
                    status += ImageQueues[index].Count;
                    break;
            }

            return;
        }

    }
}
