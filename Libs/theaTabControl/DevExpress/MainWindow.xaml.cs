using DevExpress.Model;
using DevExpress.Xpf.Core;
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

namespace DevExpress
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<TabItem> _tabItems;
        private TabItem _tabAdd;
        private const string DEFAULT_TAB_DISPLAY_HEADER = "New Tab \r\n(please rename)";

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as MainWindowViewModel;
            if (vm != null)
            {
                vm.ListTab.ListTabItem.Add(new TabModel());
            }
        }


        //public QueryPanelViewModel ViewModel
        //{
        //    get { return (QueryPanelViewModel )GetValue(QueryPanelViewModelProperty); }
        //    set { SetValue(QueryPanelViewModelProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for QueryPanelViewModel.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty QueryPanelViewModelProperty =
        //    DependencyProperty.Register("QueryPanelViewModel", typeof(QueryPanelViewModel ), typeof(MainWindow));

        
    }
}
