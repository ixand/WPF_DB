using Microsoft.Reporting.WinForms;
using WPF_DB.MVVM;
using System.Data;

namespace WPF_DB.Pages
{
    /// <summary>
    /// Interaction logic for Report3Page.xaml
    /// </summary>
    public partial class Report3Page
    {
        public ReportViewer _reportViewer;
        public Report3Page()
        {
            InitializeComponent();
            _reportViewer = new()
            {
                ProcessingMode = ProcessingMode.Local
            };
            winformsHost.Child = _reportViewer;

            _reportViewer.LocalReport.ReportEmbeddedResource = "WPF_DB.Reports.Report3.rdlc"; // get report from resources


            var viewmodel = DataContext as ReportViewModel;
            viewmodel.FiltersChanged2 += Viewmodel_FiltersChanged2;

        }


        private void Viewmodel_FiltersChanged2(object? sender, FilterArgs2 e)
        {
            if (e.From is null || e.To is null || e.From == "0001-01-01 00:00:00" || e.To == "0001-01-01 00:00:00")
            {
                return;
            }

            DataTable dataTable = DatabaseController.LoadReport3(e.From, e.To); // get data from database
            ReportDataSource reportDataSource = new("DataSet1", dataTable); // create datasource for report

            _reportViewer.LocalReport.DataSources.Clear();
            _reportViewer.LocalReport.DataSources.Add(reportDataSource);
            _reportViewer.RefreshReport();


        }
    }
}
