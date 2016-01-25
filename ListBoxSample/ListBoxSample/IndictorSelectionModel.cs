using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListBoxSample
{
    public class IndictorSelectionModel : IndicatorModelBase
    {
        public IndictorSelectionModel()
        {
            _selectionValues = new ObservableCollection<string>();
        }

        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (value != _title)
                {
                    _title = value;
                    RaisePropertyChanged("Title");
                }
            }
        }

        public ObservableCollection<string> _selectionValues;
        public ObservableCollection<string> SelectionValues
        {
            get
            {
                return _selectionValues;
            }
            set
            {
                if (value != _selectionValues)
                {
                    _selectionValues = value;
                    RaisePropertyChanged("SelectionValues");
                }
            }
        }
    }
}
