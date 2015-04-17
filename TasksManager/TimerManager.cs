using System.Threading;
using System.Collections.Generic;
using System;
using TasksManager.DataModel;
using TasksManager.Factory;

namespace TasksManager
{
    public class TimerManager
    {
        private List<CustomTimerBase> _timerCollection;

        private static TimerManager _instance;
        private TimerManager()
        {
            _timerCollection = new List<CustomTimerBase>();
        }

        public static TimerManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new TimerManager();
            }

            return _instance;
        }

        public void AddTask(ExecInfoModelBase execInfo)
        {
            if (_timerCollection == null)
            {
                _timerCollection = new List<CustomTimerBase>();
            }

            _timerCollection.Add(TimerLoadingFactory.CreateTimerType(execInfo));
        }
    }
}
