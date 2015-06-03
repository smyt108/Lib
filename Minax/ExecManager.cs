using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TasksManager;
using TasksManager.DataModel;

namespace Minax
{
    public class ExecManager
    {
        private static ExecManager _instance;

        private ExecManager()
        {
            initialize();
        }

        public static ExecManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ExecManager();
            }

            return _instance;
        }

        private void initialize()
        {
            ExecConfigurationsModel execConfig = ExecConfigReader.GetInstance().GetExecModelByConfig();

            #region Need to be refined.

            foreach (var item in execConfig.ExecCollection)
            {
                TimerManager.GetInstance().AddTask(item);
            }

            foreach (var item in execConfig.DailyExecCollection)
            {
                TimerManager.GetInstance().AddTask(item);
            }

            foreach (var item in execConfig.IntervalExecCollection)
            {
                TimerManager.GetInstance().AddTask(item);
            }

            #endregion
        }
    }
}
