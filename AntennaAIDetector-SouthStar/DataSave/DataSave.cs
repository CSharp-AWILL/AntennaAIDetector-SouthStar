using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntennaAIDetector_SouthStar.Product;
using Aqrose.Framework.Utility.MessageManager;

namespace AntennaAIDetector_SouthStar.DataSave
{
    public class DataSave
    {
        private string TimeInfoOfLast = "";
        private string TimeInfoOfCurr = "";

        public string DirectoryPath { get; set; } = "";
        public int SpanOfTime { get; set; } = 10;
        public int QueueSize { get; set; } = 300;
        public Queue<ResultData> ResultDatas { get; private set; } = new Queue<ResultData>();

        public DataSave()
        {
        }

        private void WriteCsv()
        {
            var resultData = GetCurrResultData();

            if (null == resultData)
            {
                MessageManager.Instance().Info("DataSave.WriteCsv: null resultData.");

                return;
            }

            if (CanGenerateNewCsvFile())
            {
                MessageManager.Instance().Info("DataSave.WriteCsv: generate new csv file.");
                // TODO: generate new csv file

            }

            // TODO: write csv

            return;
        }

        private void EnqueueResultDatas()
        {
            // TODO: confused part--when?
            ResultData resultData = new ResultData();


            if (null != ResultDatas && QueueSize <= ResultDatas.Count)
            {
                ResultDatas.Dequeue();
            }
            ResultDatas.Enqueue(resultData);

            return;
        }

        private string GetTimeInfo()
        {
            string timeInfo = "";
            // TODO: get current time info

            return timeInfo;
        }

        private bool CanGenerateNewCsvFile()
        {
            // TODO: judge whether generate new csv file or not

            return false;
        }

        private ResultData GetCurrResultData()
        {
            if (null == ResultDatas || 0 > ResultDatas.Count)
            {
                MessageManager.Instance().Info("DataSave.GetCurrResultData: empty results queue.");

                return null;
            }

            return ResultDatas.Peek();
        }

        
    }
}
