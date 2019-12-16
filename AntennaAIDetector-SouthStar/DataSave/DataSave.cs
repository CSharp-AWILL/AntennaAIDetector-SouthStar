using System.Collections.Generic;
using AntennaAIDetector_SouthStar.Result;
using Aqrose.Framework.Core.Attributes;
using Aqrose.Framework.Core.DataType;
using Aqrose.Framework.Core.Interface;
using Aqrose.Framework.Utility.MessageManager;

namespace AntennaAIDetector_SouthStar.DataSave
{
    [Module("DataSave", "AntennaAIDetector", "")]
    public class DataSave : ModuleData, IModule
    {
        private string _timeInfoOfLast = "";
        private string _timeInfoOfCurr = "";
        private ResultDevice _device = null;

        public string DirectoryPath { get; set; } = "";
        public int SpanOfTime { get; set; } = 10;
        public int QueueSize { get; set; } = 300;
        public Queue<string> ResultDatas { get; private set; } = new Queue<string>();

        public DataSave()
        {
            _device = ResultDevice.GetInstance();
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
            string resultData = "";


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

        private string GetCurrResultData()
        {
            if (null == ResultDatas || 0 > ResultDatas.Count)
            {
                MessageManager.Instance().Info("DataSave.GetCurrResultData: empty results queue.");

                return null;
            }

            return ResultDatas.Peek();
        }

        public string GetHeader()
        {
            if (null == _device)
            {
                return "";
            }

            return _device.GenerateHeaderString();
        }

        #region IModule

        public void InitModule(string projectDirectory, string nodeName)
        {
            //throw new System.NotImplementedException();
        }

        public void SaveModule(string projectDirectory, string nodeName)
        {
            //throw new System.NotImplementedException();
        }

        public void CloseModule()
        {
            //throw new System.NotImplementedException();
        }

        public void Run()
        {
            if (null == _device)
            {
                MessageManager.Instance().Alarm("DataSave.Run: null _device!");

                return;
            }

            ResultDatas.Enqueue(_device.GenerateDstMessage());

            return;
        }

        public bool StartSetForm()
        {
            DataSaveForm form = null;
            if (null == this)
            {
                return false;
            }

            form = new DataSaveForm(this);
            form.ShowDialog();
            form.Close();

            return true;
        }

        #endregion
    }
}
