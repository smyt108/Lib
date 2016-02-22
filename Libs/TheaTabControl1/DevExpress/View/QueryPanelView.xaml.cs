using DevExpress.ViewModel;
using System.Windows.Controls;

namespace DevExpress.View
{
    /// <summary>
    /// Interaction logic for QueryPanelView.xaml
    /// </summary>
    public partial class QueryPanelView
    {
        public QueryPanelView()
        {
            InitializeComponent();
            QueryPanelViewModel viewModel = new QueryPanelViewModel();
            this.DataContext = viewModel;
        }    
    }
}
