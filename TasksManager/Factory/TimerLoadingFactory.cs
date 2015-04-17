using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TasksManager.DataModel;

namespace TasksManager.Factory
{
    public class TimerLoadingFactory
    {
        public static CustomTimerBase CreateTimerType(ExecInfoModelBase execType)
        {
            string prefix = "TasksManager.";
            string timerSuffix = "Timer";

            StringBuilder timerName = new StringBuilder(prefix);
            timerName.Append(GetTimerTypeName(execType));
            timerName.Append(timerSuffix);

            Type timerType = Type.GetType(timerName.ToString());
            object instance = Activator.CreateInstance(timerType, execType);

            return instance as CustomTimerBase;
        }

        private static string GetTimerTypeName(ExecInfoModelBase execType)
        {
            string removeSuffix = "InfoModel";

            StringBuilder execName = new StringBuilder( execType.GetType().Name);
            execName.Replace(removeSuffix,string.Empty);

            return execName.ToString();
        }
    }
}
