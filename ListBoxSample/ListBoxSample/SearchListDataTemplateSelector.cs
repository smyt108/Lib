using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ListBoxSample
{
    public class SearchListDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            Window win = Application.Current.MainWindow;

            if (item != null && item is IndictorSelectionModel)
            {
                return win.FindResource("IndictorSelectionModelTemplate") as DataTemplate;
            }

            if (item != null && item is IndicatorTextModel)
            {
                return win.FindResource("IndicatorTextModelTemplate") as DataTemplate;
            }

            if (item != null && item is IndicatorModelBase)
            {
                return win.FindResource("IndicatorModelBaseTemplate") as DataTemplate;
            }

            return null;
        }
    }
}
