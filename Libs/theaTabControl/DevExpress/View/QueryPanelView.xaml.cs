using DevExpress.ViewModel;
using System.Windows.Controls;

namespace DevExpress
{
    /// <summary>
    /// Interaction logic for QueryPanelView.xaml
    /// </summary>
    public partial class QueryPanelView : UserControl
    {
        public QueryPanelView()
        {
            InitializeComponent();
            QueryPanelViewModel viewModel = new QueryPanelViewModel();
            this.DataContext = viewModel;
        }    
    }
}
