using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListBoxSample
{
    public class IndicatorModelBase: NotifyPropertyChanged
    {
        private string _indicatorValue;
        public string IndicatorValue
        {
            get
            {
                return _indicatorValue;
            }
            set
            {
                if (value != _indicatorValue)
                {
                    _indicatorValue = value;
                    RaisePropertyChanged("IndicatorValue");
                }
            }
        }
    }
}
