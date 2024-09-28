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
    /// Interaction logic for Report5Page.xaml
    /// </summary>
    public partial class Report5Page
    {
        public ReportViewer _reportViewer;
        public Report5Page()
        {
            InitializeComponent();
            _reportViewer = new()
            {
                ProcessingMode = ProcessingMode.Local
            };
            winformsHost.Child = _reportViewer;

            _reportViewer.LocalReport.ReportEmbeddedResource = "WPF_DB.Reports.Report5.rdlc"; // get report from resources
            DataTable dataTable = DatabaseController.LoadReport5(); // get data from database
            ReportDataSource reportDataSource = new("DataSet1", dataTable); // create datasource for report

            _reportViewer.LocalReport.DataSources.Clear();
            _reportViewer.LocalReport.DataSources.Add(reportDataSource);

            _reportViewer.RefreshReport();
        }
    }
}
