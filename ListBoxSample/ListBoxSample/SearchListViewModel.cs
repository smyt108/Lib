using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListBoxSample
{
    public class SearchListViewModel : NotifyPropertyChanged
    {
        public SearchListViewModel()
        {
            _searchCriteria = new ObservableCollection<IndicatorModelBase>();
        }

        ObservableCollection<IndicatorModelBase> _searchCriteria;
        public  ObservableCollection<IndicatorModelBase> SearchCriteria
        {
            get
            {
                return _searchCriteria;
            }
            set
            {
                if (value != _searchCriteria)
                {
                    _searchCriteria = value;
                    RaisePropertyChanged("SearchCriteria");
                }
            }
        }
    }
}
