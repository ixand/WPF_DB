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
using WPF_DB.MVVM;

namespace WPF_DB.Pages
{
    /// <summary>
    /// Interaction logic for Report2Page.xaml
    /// </summary>
    public partial class Report2Page
    {

        public ReportViewer _reportViewer;
        public Report2Page()
        {
            InitializeComponent();
            _reportViewer = new()
            {
                ProcessingMode = ProcessingMode.Local
            };
            winformsHost.Child = _reportViewer;

            _reportViewer.LocalReport.ReportEmbeddedResource = "WPF_DB.Reports.Report2.rdlc"; // get report from resources


            var viewmodel = DataContext as ReportViewModel;
            viewmodel.FiltersChanged += Viewmodel_FiltersChanged;

        }

        private void Viewmodel_FiltersChanged(object? sender, FilterArgs e)
        {
            if(e.Station is null || e.From is null || e.To is null)
            {
                return;
            }

            DataTable dataTable = DatabaseController.LoadReport2(e.Station,e.From,e.To); // get data from database
            ReportDataSource reportDataSource = new("DataSet1", dataTable); // create datasource for report

            _reportViewer.LocalReport.DataSources.Clear();
            _reportViewer.LocalReport.DataSources.Add(reportDataSource);
            _reportViewer.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("from",e.From));
            _reportViewer.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("to", e.To));
            _reportViewer.RefreshReport();


        }
    }
}
