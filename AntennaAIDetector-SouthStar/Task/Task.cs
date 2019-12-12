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

        public List<Queue<Bitmap>> Images { get; set; } = new List<Queue<Bitmap>>();

        public Task()
        {
            //
        }

        private int GetTaskAmount()
        {
            int amount = 0;
            foreach (var image in Images)
            {
                amount += image.Count;
            }

            return amount;
        }

        public int GetTaskSize()
        {
            /*
             * return -1: error
             * return n: the list of queue count
             */
            if (null == Images)
            {
                return -1;
            }

            return Images.Count;
        }

        public Bitmap PopBitmap(int index)
        {
            Bitmap temp = null;
            if (null != Images && index < Images.Count && 0 < Images[index].Count)
            {
                temp = ImageOperateTools.ImageCopy(Images[index].Dequeue());
                //return Images[index].Dequeue().Clone() as Bitmap;
            }

            return temp;
        }

        public Bitmap GetBitmap(int index)
        {
            if (null != Images && index < Images.Count && 0 < Images[index].Count)
            {
                return ImageOperateTools.ImageCopy(Images[index].Peek());
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
            if (0 > GetTaskSize())
            {
                MessageManager.Instance().Alarm("Task: unexcepted case!");
            }

            //
            for (int index = 0; index < source.Count; ++index)
            {
                Images[index].Enqueue(source[index]);
                //Images[index].Enqueue(source[index].Clone() as Bitmap);
            }

            return true;
        }

        public void SetTaskSize(int number)
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

            if (index >= GetTaskSize())
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
                    status += Images[index].Count;
                    break;
            }

            return;
        }

    }
}
