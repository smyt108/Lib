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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = initialzeData();
        }

        private ObservableCollection<IndicatorModelBase> initialzeData()
        {
            ObservableCollection<IndicatorModelBase> source = new ObservableCollection<IndicatorModelBase>();

            source.Add(new IndicatorModelBase() { IndicatorValue = "Value1" });

            source.Add(new IndicatorTextModel() { Title="SearchTitle1:",IndicatorValue = "TitleValue1" });
            source.Add(new IndicatorTextModel() { Title = "SearchTitle2:", IndicatorValue = "TitleValue2" });
            source.Add(new IndicatorTextModel() { Title = "SearchTitle3:", IndicatorValue = "TitleValue3" });

            ObservableCollection<string>  SelectionValues = new ObservableCollection<string>();
            SelectionValues.Add("Selection1");
            SelectionValues.Add("Selection2");
            SelectionValues.Add("Selection3");
            SelectionValues.Add("Selection4");
            source.Add(new IndictorSelectionModel() { Title = "SelectionTitle1", IndicatorValue = "SelectionValue1", SelectionValues = SelectionValues });
            source.Add(new IndictorSelectionModel() { Title = "SelectionTitle2", IndicatorValue = "SelectionValue2", SelectionValues = SelectionValues });

            source.Add(new IndicatorModelBase() { IndicatorValue = "Value1" });

            source.Add(new IndicatorTextModel() { Title = "SearchTitle1:", IndicatorValue = "TitleValue1" });
            source.Add(new IndicatorTextModel() { Title = "SearchTitle2:", IndicatorValue = "TitleValue2" });
            source.Add(new IndicatorTextModel() { Title = "SearchTitle3:", IndicatorValue = "TitleValue3" });

            source.Add(new IndictorSelectionModel() { Title = "SelectionTitle1", IndicatorValue = "SelectionValue1", SelectionValues = SelectionValues });
            source.Add(new IndictorSelectionModel() { Title = "SelectionTitle2", IndicatorValue = "SelectionValue2", SelectionValues = SelectionValues });

            return source;
        }
    }
}
