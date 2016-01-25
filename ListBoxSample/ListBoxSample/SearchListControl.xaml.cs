using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ListBoxSample
{
    /// <summary>
    /// Interaction logic for SearchListControl.xaml
    /// </summary>
    public partial class SearchListControl : UserControl 
    {
        public SearchListControl()
        {
            InitializeComponent();
        }

        public readonly static DependencyProperty SearchListControlItemSourceProperty =
   DependencyProperty.Register("SearchListControlItemSource", typeof(ObservableCollection<IndicatorModelBase>), typeof(SearchListControl));

        public ObservableCollection<IndicatorModelBase> SearchListControlItemSource
        {
            get { return (ObservableCollection<IndicatorModelBase>)GetValue(SearchListControlItemSourceProperty); }
            set { SetValue(SearchListControlItemSourceProperty, value); }
        }
    }
}
