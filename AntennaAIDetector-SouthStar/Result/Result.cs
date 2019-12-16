using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntennaAIDetector_SouthStar.View;
using Aqrose.Framework.Core.Attributes;
using Aqrose.Framework.Core.DataType;
using Aqrose.Framework.Core.Interface;
using Aqrose.Framework.Utility.MessageManager;

namespace AntennaAIDetector_SouthStar.Result
{
    [Module("Result", "AntennaAIDetector", "")]
    public class Result : ModuleData, IModule
    {
        private ResultDevice _device = null;

        [InputData]
        public SingleResult SingleResult { get; set; } = null;

        public int TaskSize
        {
            get
            {
                if (null == _device)
                {
                    return 0;
                }

                return _device.TaskSize;
            }
        }
        public int TotalSize
        {
            get
            {
                if (null == _device)
                {
                    return 0;
                }

                return _device.TotalSize;
            }
        }

        public Result()
        {
            _device = ResultDevice.GetInstance();
        }

        #region IModule

        public void CloseModule()
        {
            //throw new NotImplementedException();
        }

        public void InitModule(string projectDirectory, string nodeName)
        {
            //throw new NotImplementedException();
        }

        public void Run()
        {
            if (null == SingleResult)
            {
                MessageManager.Instance().Info("Result.Run: null SingleResult.");

                return;
            }
            lock (ResultDevice.PAD_LOCK)
            {
                _device.Enqueue(SingleResult);
                MessageManager.Instance().Info("SingleReult.Index:" + SingleResult.Index.ToString() + "\tSingleResult.DefectInfo" + SingleResult.DefectInfo);
            }

            return;
        }

        public void SaveModule(string projectDirectory, string nodeName)
        {
            //throw new NotImplementedException();
        }

        public bool StartSetForm()
        {
            ResultForm form = null;
            if (null == this)
            {
                return false;
            }

            form = new ResultForm(this);
            form.ShowDialog();
            form.Close();

            return true;
        }

        #endregion

        public void RetrieveTaskMode()
        {
            if (null == _device)
            {
                MessageManager.Instance().Warn("Result.RetrieveTaskMode: null _device!");

                return;
            }

            _device.LoadConfiguration();

            return;
        }
    }
}
