using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TasksManager.DataModel
{
    public class TaskMessageDataModel
    {
        public TaskMessageDataModel(string title, DateTime time,TaskBehaviorEnum status, string summary)
        {
            Title = title;
            Time = time;
            Status = status;
            Summary = summary;
        }

        public string Title { get; set; }
        public DateTime Time { get; set; }
        public TaskBehaviorEnum Status { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
    }

    public enum TaskBehaviorEnum
    {
        Null=0,
        Start=1,
        Processing=2,
        End=3,
    }
}
