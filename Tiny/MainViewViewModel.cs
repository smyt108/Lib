using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism;
using Microsoft.Practices.Prism.ViewModel;
using System.Collections.ObjectModel;
using TasksManager;
using TasksManager.DataModel;
using System.Threading;
using System.Windows.Threading;

namespace Tiny
{
    public class MainViewViewModel : NotificationObject
    {
        private Dispatcher _uiDispatcher;

        public MainViewViewModel(Dispatcher uiDispacher)
        {
            _uiDispatcher = uiDispacher;
            _messages = new ObservableCollection<ExecMessageViewModel>();

            MessageDispatcher.GetInstance().MessageReceived += addMessage;

            ExecManager.GetInstance();
        }

        private ObservableCollection<ExecMessageViewModel> _messages;
        public ObservableCollection<ExecMessageViewModel> Messages
        {
            get { return _messages; }
            set
            {
                if (value != _messages)
                {
                    _messages = value;
                    RaisePropertyChanged(() => this.Messages);
                }
            }
        }

        private void addMessage(TaskMessageDataModel message)
        {
            _uiDispatcher.BeginInvoke(new Action(() =>
            {
                Messages.Add(new ExecMessageViewModel { TimeStamp = message.Time, SummaryInfo = message.Summary, Status = message.Status,Title=message.Title });
            }));
        }
    }
}
