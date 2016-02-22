using System.Collections.ObjectModel;

namespace DevExpress.Model
{
    public class ComboModel : CustomerModel<string>
    {
        public ComboModel()
        {
            selectionValues = new ObservableCollection<string>();
            this.TitleWidth = 85.0d;
            this.IndicatorWidth = 100.0d;
        }

        public ObservableCollection<string> selectionValues;
        public ObservableCollection<string> SelectionValues
        {
            get
            {
                return selectionValues;
            }
            set
            {
                if (value != selectionValues)
                {
                    selectionValues = value;
                    RaisePropertyChanged(() => SelectionValues);
                }
            }
        }
    }
}
