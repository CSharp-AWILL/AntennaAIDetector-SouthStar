using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Aqrose.Framework.Utility.MessageManager;
using Aqrose.Framework.Utility.Tools;

namespace AntennaAIDetector_SouthStar.Task
{
    public class Task
    {
        public int TaskSize { get; set; } = 1;
        public int TotalSize { get; set; } = 1;
        public Queue<Bitmap> OriginImages { get; set; } = new Queue<Bitmap>();
        public RectangleF[] Roi { get; set; } = new RectangleF[6]
        {
            RectangleF.Empty, RectangleF.Empty, RectangleF.Empty,
            RectangleF.Empty, RectangleF.Empty, RectangleF.Empty
        };
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

        public void LoadConfiguration()
        {
            string param = "";
            string info = "";
            RectangleF roi = new RectangleF();

            XmlParameter xmlParameter = new XmlParameter();

            xmlParameter.ReadParameter(Application.StartupPath + @"\TaskParamFile.xml");

            info = xmlParameter.GetParamData("TaskSize");
            if (!string.IsNullOrWhiteSpace(info))
            {
                TaskSize = Convert.ToInt32(info);
            }

            info = xmlParameter.GetParamData("TotalSize");
            if (!string.IsNullOrWhiteSpace(info))
            {
                TotalSize = Convert.ToInt32(info);
            }

            //
            for (int index = 0; index < TaskSize; ++index)
            {
                roi = new RectangleF();
                param = "Roi-" + index;
                info = xmlParameter.GetParamData(param + "-X");
                if (info != "")
                {
                    Roi[index].X = (float)Convert.ToDouble(info);
                }
                info = xmlParameter.GetParamData(param + "-Y");
                if (info != "")
                {
                    Roi[index].Y = (float)Convert.ToDouble(info);
                }
                info = xmlParameter.GetParamData(param + "-Width");
                if (info != "")
                {
                    Roi[index].Width = (float)Convert.ToDouble(info);
                }
                info = xmlParameter.GetParamData(param + "-Height");
                if (info != "")
                {
                    Roi[index].Height = (float)Convert.ToDouble(info);
                }

                ImageQueues.Add(new Queue<Bitmap>());
            }

            return;
        }

        public void SaveConfiguration()
        {
            string param = "";
            XmlParameter xmlParameter = new XmlParameter();

            xmlParameter.Add("TaskSize", TaskSize);
            xmlParameter.Add("TotalSize", TotalSize);

            //
            for (int index = 0; index < TaskSize; ++index)
            {
                param = "Roi-" + index;
                xmlParameter.Add(param + "-X", Roi[index].X);
                xmlParameter.Add(param + "-Y", Roi[index].Y);
                xmlParameter.Add(param + "-Width", Roi[index].Width);
                xmlParameter.Add(param + "-Height", Roi[index].Height);
            }

            xmlParameter.WriteParameter(Application.StartupPath + @"\TaskParamFile.xml");

            return;
        }

        public bool TryAddRoi(RectangleF rectangle)
        {
            ++TaskSize;
            if (TaskSize > Roi.Length)
            {
                --TaskSize;
                return false;
            }

            Roi[TaskSize - 1] = rectangle;
            ImageQueues.Add(new Queue<Bitmap>());

            return true;
        }

        public bool TryRemoveRoi()
        {
            --TaskSize;
            if (0 > TaskSize)
            {
                ++TaskSize;
                return false;
            }

            Roi[TaskSize] = RectangleF.Empty;
            ImageQueues.RemoveAt(TaskSize);

            return true;
        }

        public Bitmap PopBitmap(int index)
        {
            Bitmap temp = null;
            if (null != ImageQueues && index < ImageQueues.Count && 0 < ImageQueues[index].Count)
            {
                temp = ImageOperateTools.ImageCopy(ImageQueues[index].Dequeue());
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
            if (source.Count != TaskSize)
            {
                MessageManager.Instance().Alarm("Task: unexcepted case!");
            }

            //
            for (int index = 0; index < source.Count; ++index)
            {
                var temp = ImageOperateTools.ImageCopy(source[index]);
                ImageQueues[index].Enqueue(temp);

                MessageManager.Instance().Info("Task.Push: " + index);
            }

            return true;
        }

        public bool TryPushImages(Bitmap originImage)
        {
            if (null == originImage)
            {
                return false;
            }

            //
            if (TotalSize <= OriginImages.Count)
            {
                OriginImages.Dequeue();
            }

            while (OriginImages.Count >= TotalSize)
            {
                OriginImages.Dequeue();
            }
            OriginImages.Enqueue(originImage);

            for (int index = 0; index < TaskSize; ++index)
            {
                var roi = Roi[index];
                //
                roi.X = Math.Max(roi.X, 0);
                roi.Y = Math.Max(roi.Y, 0);
                roi.Width = Math.Max(roi.Width, 0);
                roi.Height = Math.Max(roi.Height, 0);
                //
                roi.X = Math.Min(roi.X, originImage.Width);
                roi.Y = Math.Min(roi.Y, originImage.Height);
                roi.Width = Math.Min(roi.Width, originImage.Width - roi.X);
                roi.Height = Math.Min(roi.Height, originImage.Height - roi.Y);
                ImageOperateTools.BitmapCropImage(originImage, Rectangle.Truncate(roi), out var res);
                ImageQueues[index].Enqueue(res);
                MessageManager.Instance().Info("Task.Push: " + index);
            }
            
            return true;
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

            if (index >= TaskSize)
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
