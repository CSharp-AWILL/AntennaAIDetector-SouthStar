using System;
using System.IO;
using System.Threading;
using Aqrose.Framework.Core.Attributes;
using Aqrose.Framework.Core.DataType;
using Aqrose.Framework.Core.Interface;
using Aqrose.Framework.Utility.MessageManager;
using Aqrose.Framework.Utility.Tools;

namespace AntennaAIDetector_SouthStar.Task.Spy
{
    [Module("Spy", "AntennaAIDetector", "")]
    public class Spy : ModuleData, IModule
    {
        private Task _device = null;

        [OutputData]
        public string IsEmpty { get; set; } = "";

        public int Index { get; set; } = -1;

        public Spy()
        {
            _device = TaskPool.GetInstance();
        }

        #region IModule

        public void CloseModule()
        {
            //throw new NotImplementedException();
        }

        public void InitModule(string projectDirectory, string nodeName)
        {
            string configFile = projectDirectory + @"\Spy-" + nodeName + ".xml";
            string strParamInfo = "";
            XmlParameter xmlParameter = null;
            if (!File.Exists(configFile))
            {
                return;
            }

            xmlParameter = new XmlParameter();
            xmlParameter.ReadParameter(configFile);

            //
            strParamInfo = xmlParameter.GetParamData("Index");
            if (strParamInfo != "")
            {
                Index = Convert.ToInt32(strParamInfo);
            }

            return;
        }

        public void Run()
        {
            lock (TaskPool.PAD_LOCK)
            {
                IsEmpty = IsTaskQueueEmpty() ? "OK" : "NG";
            }

            return;
        }

        public void SaveModule(string projectDirectory, string nodeName)
        {
            string configFile = projectDirectory + @"\Spy-" + nodeName + ".xml";
            XmlParameter xmlParameter = new XmlParameter();

            //
            xmlParameter.Add("Index", Index);

            xmlParameter.WriteParameter(configFile);

            return;
        }

        public bool StartSetForm()
        {
            SpyForm form = null;
            if (null == this)
            {
                return false;
            }

            form = new SpyForm(this);
            form.ShowDialog();
            form.Close();

            return true;
        }

        #endregion

        public bool IsTaskQueueEmpty()
        {
            _device.GetStatusOfQueue(Index, out var status);
            switch (status)
            {
                case -1:
                    MessageManager.Instance().Alarm("Spy.GetStatus: error");
                    break;
                case 0:
                    return true;
                default:
                    return false;
            }

            return false;
        }

        public int GetTaskSize()
        {
            if (null == _device)
            {
                MessageManager.Instance().Warn("Spy: _device is null.");

                return 0;
            }

            return _device.GetTaskSize();
        }
    }
}
