using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using TasksManager.DataModel;

namespace TasksManager
{
    public class ExecTimer : CustomTimerBase
    {
        private Timer _timer;

        public ExecTimer(ExecInfoModel execInfo)
            : base(execInfo)
        {
            _timer = new Timer(CreateExecution, execInfo, 0, 60000);
        }

        private void CreateExecution(object execInfo)
        {
            ExecInfoModel obj = execInfo as ExecInfoModel;

            string timeLine = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

            if (timeLine == obj.TimeLine)
            {
                ReportTask(new TaskMessageDataModel(obj.Name, DateTime.Now, TaskBehaviorEnum.Start));

                ExecuteCommand(obj);

                ReportTask(new TaskMessageDataModel(obj.Name, DateTime.Now, TaskBehaviorEnum.End));
            }
        }

        private void ExecuteCommand(ExecInfoModel execInfo)
        {
            int exitCode;
            ProcessStartInfo processInfo;
            Process process;

            processInfo = new ProcessStartInfo(execInfo.Path, execInfo.Arguments);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;

            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;

            process = Process.Start(processInfo);
            process.WaitForExit();

            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            exitCode = process.ExitCode;
            process.Close();
        }
    }
}
