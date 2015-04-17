using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TasksManager.DataModel;
using System.Threading;
using System.Diagnostics;

namespace TasksManager
{
    public abstract class CustomTimerBase
    {
        public CustomTimerBase(ExecInfoModelBase execInfo)
        {
            this.ReportTask += TaskMessageQueue.GetInstance().AddToQueue;
        }

        public delegate void ReportTaskHandle(TaskMessageDataModel message);

        public ReportTaskHandle ReportTask;
    }
}
