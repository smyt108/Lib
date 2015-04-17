using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using Microsoft.Reporting.WinForms;

namespace SSRSReportViewSample
{
    /// <summary>
    /// Interaction logic for TopTenReportView.xaml
    /// </summary>
    public partial class TopTenReportView : Window
    {
        public TopTenReportView()
        {
            InitializeComponent();
            loadRV();
        }

        private void loadRV()
        {
            try
            {
                this._reportViewer.ProcessingMode = ProcessingMode.Remote;
                this._reportViewer.ServerReport.ReportServerUrl = new Uri(@"I:\Documents\MyDoc\Tech\TasksManager\SSRSReportViewSample\bin\Debug");
                this._reportViewer.ServerReport.ReportPath = "/fn_PositionsSet2_20150305";

                this._reportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
