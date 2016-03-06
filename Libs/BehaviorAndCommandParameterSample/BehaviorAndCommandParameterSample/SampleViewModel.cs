using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BehaviorAndCommandParameterSample
{
    public class SampleViewModel : INotifyPropertyChanged
    {
        #region Constructer

        public SampleViewModel()
        {
            ButtonCommand = new DelegateCommand<object>(Commands.ChangeBackgroundCommand);
        }

        #endregion

        public ICommand ButtonCommand { get; set; }

        #region Implement INotify

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
