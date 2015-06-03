using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TasksManager.DataModel;

namespace Minax
{
    public class ExecMessageViewModel : NotificationObject
    {
        public ExecMessageViewModel()
        {

        }

        private DateTime _timeStamp;
        public DateTime TimeStamp
        {
            get { return _timeStamp; }
            set
            {
                if (value != _timeStamp)
                {
                    _timeStamp = value;
                    RaisePropertyChanged(() => this.TimeStamp);
                }
            }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                if (value != _title)
                {
                    _title = value;
                    RaisePropertyChanged(() => this.Title);
                }
            }
        }

        private string _summaryInfo;
        public string SummaryInfo
        {
            get { return _summaryInfo; }
            set
            {
                if (value != _summaryInfo)
                {
                    _summaryInfo = value;
                    RaisePropertyChanged(() => this.SummaryInfo);
                }
            }
        }

        private string _detailInfo;
        public string DetailInfo
        {
            get { return _detailInfo; }
            set
            {
                if (value != _detailInfo)
                {
                    _detailInfo = value;
                    RaisePropertyChanged(() => this.DetailInfo);
                }
            }
        }

        private string _processId;
        public string ProcessId
        {
            get { return _processId; }
            set
            {
                if (value != _processId)
                {
                    _processId = value;
                    RaisePropertyChanged(() => this.ProcessId);
                }
            }
        }

        private TaskBehaviorEnum _status;
        public TaskBehaviorEnum Status
        {
            get { return _status; }
            set
            {
                if (value != _status)
                {
                    _status = value;
                    RaisePropertyChanged(() => this.Status);
                }
            }
        }
    }
}
