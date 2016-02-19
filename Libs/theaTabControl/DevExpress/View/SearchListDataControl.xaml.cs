using DevExpress.Model;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace DevExpress
{
    /// <summary>
    /// Interaction logic for SearchListDataControl.xaml
    /// </summary>
    public partial class SearchListDataControl : UserControl
    {
        public SearchListDataControl()
        {
            InitializeComponent();
        }


        public ObservableCollection<BaseModel> ListBoxItemSource
        {
            get { return (ObservableCollection<BaseModel>)GetValue(ListBoxItemSourceProperty); }
            set { SetValue(ListBoxItemSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ListBoxItemSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ListBoxItemSourceProperty =
            DependencyProperty.Register("ListBoxItemSource", typeof(ObservableCollection<BaseModel>), typeof(SearchListDataControl));



        public int ColumnNum
        {
            get { return (int)GetValue(ColumnNumProperty); }
            set { SetValue(ColumnNumProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ColumnNum.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ColumnNumProperty =
            DependencyProperty.Register("ColumnNum", typeof(int), typeof(SearchListDataControl));

        
    }

}
