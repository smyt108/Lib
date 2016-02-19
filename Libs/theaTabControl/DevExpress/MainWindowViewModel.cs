using DevExpress.Model;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DevExpress
{
    public class MainWindowViewModel : NotificationObject
    {

        private CustomTabControlModel listTab;
        public CustomTabControlModel ListTab
        {
            get { return listTab; }
            set
            {
                if (value != null)
                {
                    listTab = value;
                    RaisePropertyChanged(() => ListTab);
                }
            }
        }

        private DelegateCommand<object> _newCommand;
        public DelegateCommand<object> NewCommand
        {
            get
            {
                if (_newCommand == null)
                {
                    _newCommand = new DelegateCommand<object>(New_Execute);
                }

                return _newCommand;
            }
        }

        private void New_Execute(object parameter)
        {
            ListTab.ListTabItem.Add(new TabModel());
        }
    }
}
