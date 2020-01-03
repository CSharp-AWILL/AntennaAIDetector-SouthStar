using System;
using System.Collections.Generic;
using System.IO;
using AntennaAIDetector_SouthStar.Result;
using Aqrose.Framework.Core.Attributes;
using Aqrose.Framework.Core.DataType;
using Aqrose.Framework.Core.Interface;
using Aqrose.Framework.Utility.MessageManager;
using Aqrose.Framework.Utility.Tools;

namespace AntennaAIDetector_SouthStar.DataSave
{
    [Module("DataSave", "AntennaAIDetector", "")]
    public class DataSave : ModuleData, IModule
    {
        private string _timeInfoOfLast = "";
        private string _timeInfoOfCurr = "";
        private string _directoryPath = "";
        private string _codeOfProduct = "";
        private ResultDevice _device = null;

        [OutputData]
        public string IsOKString
        {
            get
            {
                return IsResultOK ? "OK" : "NG";
            }
        }

        public string DirectoryPath
        {
            get
            {
                return _directoryPath;
            }
            set
            {
                _directoryPath = string.IsNullOrWhiteSpace(value) ? @"D:\AqCsv\" : value;
            }
        }
        public string CodeOfProduct
        {
            get
            {
                return _codeOfProduct;
            }
            set
            {
                _codeOfProduct = string.IsNullOrWhiteSpace(value) ? @"default" : value;
            }
        }
        public int SpanOfTime { get; set; } = 10;
        public int QueueSize { get; set; } = 300;
        public int IndexOfQueue { get; private set; } = 0;
        public Queue<string> ResultDatas { get; private set; } = new Queue<string>();

        public DataSave()
        {
            _device = ResultDevice.GetInstance();
            DirectoryPath = "";
            CodeOfProduct = "";
        }

        public string GetHeader()
        {
            if (null == _device)
            {
                return "";
            }

            return "序号,时间," + _device.GenerateHeaderString();
        }

        public string GetResultData()
        {
            if (null == _device)
            {
                return "";
            }

            return ((IndexOfQueue++) % Int32.MaxValue).ToString() + "," + GetTimeInfo() + "," + _device.GenerateDstMessage();
        }

        private void EnqueueResultDatas(string resultData)
        {
            if (string.IsNullOrWhiteSpace(resultData))
            {
                MessageManager.Instance().Info("DataSave.EnqueueResultDatas: null resultData.");

                return;
            }

            while (null != ResultDatas && QueueSize <= ResultDatas.Count)
            {
                ResultDatas.Dequeue();
            }
            ResultDatas.Enqueue(resultData);

            return;
        }

        #region File Operation

        private string GetTimeInfo()
        {
            return DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss"); ;
        }

        private bool CanGenerateNewCsvFile()
        {
            bool result = false;

            if ("" == _timeInfoOfCurr)
            {
                _timeInfoOfCurr = GetTimeInfo();
            }
            if ("" == _timeInfoOfLast)
            {
                _timeInfoOfLast = _timeInfoOfCurr;

                // attention
                return true;
            }

            TryParseTimeInfo(_timeInfoOfLast, out DateTime dateTimeOfLast);
            // only update current time info
            _timeInfoOfCurr = GetTimeInfo();
            TryParseTimeInfo(_timeInfoOfCurr, out DateTime dateTimeOfCurr);
            TimeSpan timeSpan = dateTimeOfCurr - dateTimeOfLast;
            var timeSpanOfStandard = TimeSpan.FromHours(SpanOfTime);
            var isBigger = TimeSpan.Compare(timeSpan, timeSpanOfStandard);

            result = 1 == isBigger;
            if (result)
            {
                _timeInfoOfLast = _timeInfoOfCurr;
                MessageManager.Instance().Info("DataSave.CanGenerateNewCsvFile: need generate a new csv file.");
            }

            return result;
        }

        private string GetDirPath()
        {
            string dirPath = DirectoryPath + @"\";
            // dirPath
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            return dirPath;
        }

        private string GetFilePath()
        {
            string dirPath = GetDirPath();
            string filePath = dirPath + CodeOfProduct;
            string timeInfo = "";
            string[] time = null;

            File.SetAttributes(dirPath, FileAttributes.Normal);

            if (CanGenerateNewCsvFile())
            {
                time = _timeInfoOfCurr.Split('-');
            }
            else
            {
                time = _timeInfoOfLast.Split('-');
            }
            timeInfo = time[0] + time[1] + time[2] + time[3];
            filePath += ("_d_" + timeInfo + @".csv");

            return filePath;
        }

        private void WriteCsv(string content)
        {
            string filePath = "";
            string header = "";
            System.IO.FileStream fs = null;
            System.IO.StreamWriter sw = null;

            if (null == content)
            {
                MessageManager.Instance().Info("DataSave.WriteCsv: null resultData.");

                return;
            }

            // 
            filePath = GetFilePath();
            try
            {
                if (!File.Exists(filePath))
                {
                    //
                    IndexOfQueue = 0;

                    fs = new System.IO.FileStream(filePath, System.IO.FileMode.Create,
                            System.IO.FileAccess.Write);
                    sw = new System.IO.StreamWriter(fs, System.Text.Encoding.UTF8);
                    header = GetHeader();
                    sw.WriteLine(header);
                    sw.WriteLine(content);
                    sw.Close();
                    fs.Close();
                }
                else
                {
                    fs = new System.IO.FileStream(filePath, System.IO.FileMode.Append,
                            System.IO.FileAccess.Write);
                    sw = new System.IO.StreamWriter(fs, System.Text.Encoding.UTF8);
                    header = GetHeader();
                    sw.WriteLine(content);
                    sw.Close();
                    fs.Close();
                }
            }
            catch (Exception e)
            {
                MessageManager.Instance().Alarm("DataSave: 保存数据失败," + e.Message);
            }

            return;
        }

        private bool TryParseTimeInfo(string timeInfo, out DateTime dateTime)
        {
            dateTime = new DateTime();
            if ("" != timeInfo)
            {
                var info = timeInfo.Split('-');
                if (6 != info.Length)
                {
                    MessageManager.Instance().Warn("DataSave.ParseTimeInfo: unexpected time info string!");

                    return false;
                }

                dateTime = new DateTime(Convert.ToInt32(info[0]), Convert.ToInt32(info[1]), Convert.ToInt32(info[2]), Convert.ToInt32(info[3]), Convert.ToInt32(info[4]), Convert.ToInt32(info[5]));
            }

            return true;
        }

        #endregion

        #region IModule

        public void InitModule(string projectDirectory, string nodeName)
        {
            string configFile = projectDirectory + @"\DataSave-" + nodeName + ".xml";
            string strParamInfo = "";
            XmlParameter xmlParameter = null;
            if (File.Exists(configFile))
            {
                xmlParameter = new XmlParameter();
                xmlParameter.ReadParameter(configFile);

                strParamInfo = xmlParameter.GetParamData("DirectoryPath");
                if (strParamInfo != "")
                {
                    DirectoryPath = strParamInfo;
                }
                strParamInfo = xmlParameter.GetParamData("CodeOfProduct");
                if (strParamInfo != "")
                {
                    CodeOfProduct = strParamInfo;
                }
                strParamInfo = xmlParameter.GetParamData("SpanOfTime");
                if (strParamInfo != "")
                {
                    SpanOfTime = Convert.ToInt32(strParamInfo);
                }
                strParamInfo = xmlParameter.GetParamData("QueueSize");
                if (strParamInfo != "")
                {
                    QueueSize = Convert.ToInt32(strParamInfo);
                }
            }

            return;
        }

        public void SaveModule(string projectDirectory, string nodeName)
        {
            string configFile = projectDirectory + @"\DataSave-" + nodeName + ".xml";
            XmlParameter xmlParameter = new XmlParameter();
            xmlParameter.Add("DirectoryPath", DirectoryPath);
            xmlParameter.Add("CodeOfProduct", CodeOfProduct);
            xmlParameter.Add("SpanOfTime", SpanOfTime);
            xmlParameter.Add("QueueSize", QueueSize);

            xmlParameter.WriteParameter(configFile);

            return;
        }

        public void CloseModule()
        {
            //throw new System.NotImplementedException();
        }

        public void Run()
        {
            string content = "";

            //
            lock (ResultDevice.PAD_LOCK)
            {
                if (_device.IsQueueFull())
                {
                    content = GetResultData();
                    IsResultOK = true;
                }
                else
                {
                    IsResultOK = false;
                }
            }

            if (!string.IsNullOrWhiteSpace(content))
            {
                WriteCsv(content);
                EnqueueResultDatas(content);
            }

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
