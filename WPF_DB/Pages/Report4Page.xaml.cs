using Microsoft.Reporting.WinForms;
using System.Data;
using WPF_DB.MVVM;

namespace WPF_DB.Pages
{
    /// <summary>
    /// Interaction logic for Report4Page.xaml
    /// </summary>
    public partial class Report4Page
    {
        public ReportViewer _reportViewer;
        public Report4Page()
        {
            InitializeComponent();
            _reportViewer = new()
            {
                ProcessingMode = ProcessingMode.Local
            };
            winformsHost.Child = _reportViewer;

            _reportViewer.LocalReport.ReportEmbeddedResource = "WPF_DB.Reports.Report4.rdlc"; // get report from resources
            DataTable dataTable = DatabaseController.LoadReport4(); // get data from database
            ReportDataSource reportDataSource = new("DataSet1", dataTable); // create datasource for report

            _reportViewer.LocalReport.DataSources.Clear();
            _reportViewer.LocalReport.DataSources.Add(reportDataSource);

            _reportViewer.RefreshReport();

        }
       
    }
}
