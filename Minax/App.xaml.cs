using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using TasksManager.DataModel;
using TasksManager;

namespace Minax
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            ExecConfigurationsModel execConfig = ExecConfigReader.GetInstance().GetExecModelByConfig();

            #region Need tobe refined.

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
