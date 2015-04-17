using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using Microsoft.Reporting.WinForms;

namespace SSRSReportViewSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            loadRV();
            
        }

        private void loadRV()
        {
            try
            {
                this._reportViewer.ProcessingMode = ProcessingMode.Remote;
                this._reportViewer.ServerReport.ReportServerUrl = new Uri(@"http://vm-7750-7ad6/ReportServer");
                this._reportViewer.ServerReport.ReportPath = "/MR SSRS/SSAS-ARRCube";

                this._reportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
