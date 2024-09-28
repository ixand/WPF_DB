using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace WPF_DB.Pages
{
    /// <summary>
    /// Interaction logic for ReportPage.xaml
    /// </summary>
    public partial class ReportPage
    {
        public ReportViewer _reportViewer;

        public ReportPage()
        {
            InitializeComponent();
            _reportViewer = new()
            {
                ProcessingMode = ProcessingMode.Local
            };
            winformsHost.Child = _reportViewer;

            _reportViewer.LocalReport.ReportEmbeddedResource = "WPF_DB.Reports.Report1.rdlc"; // get report from resources
            DataTable dataTable = DatabaseController.LoadReport1(); // get data from database
            ReportDataSource reportDataSource = new("DataSet1", dataTable); // create datasource for report

            _reportViewer.LocalReport.DataSources.Clear();
            _reportViewer.LocalReport.DataSources.Add(reportDataSource);

            _reportViewer.RefreshReport();
        }

        
    }
}
