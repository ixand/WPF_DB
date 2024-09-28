using FloxelLib;
using FloxelLib.MVVM;
using Microsoft.ReportingServices.Diagnostics.Internal;
using Npgsql;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Data;
using System.Globalization;

namespace WPF_DB.MVVM
{   
    public sealed record FilterArgs(string Station,string From, string To);
    public sealed record FilterArgs2(string From, string To);


    public partial class ReportViewModel : BaseViewModel
    {
        

        [UpdateProperty("OnFiltersChanged();OnFiltersChanged2();")]
        
        private DateTime from, to; 
        public ReportViewModel() 
        {
            Stations = new();
            Stations.AddRange(DatabaseController.GetStationsName());
        }
        public ObservableCollection<string> Stations { get; set; }

        public event EventHandler<FilterArgs> FiltersChanged;

        public event EventHandler<FilterArgs2> FiltersChanged2;

        private void OnFiltersChanged()
        {
            FiltersChanged?.Invoke(this, new FilterArgs(selectedStation,from.ToString("yyyy-MM-dd HH:mm:ss"), to.ToString("yyyy-MM-dd HH:mm:ss")));
        }

        private void OnFiltersChanged2()
        {
            FiltersChanged2?.Invoke(this, new FilterArgs2(from.ToString("yyyy-MM-dd HH:mm:ss"), to.ToString("yyyy-MM-dd HH:mm:ss")));
        }


        [UpdateProperty("OnFiltersChanged();OnFiltersChanged2();")]
        
        private string selectedStation;
        
        

        [RelayCommand]

        static void Return()
        {
            App.ChangePage("../Pages/DatabasePage.xaml", "База даних");
        }


        [RelayCommand]

        static void Menu()
        {
            App.ChangePage("../Pages/ReportMenuPage.xaml", "Список звітів");
        }

        [RelayCommand]
        static void Report1()
        {
            App.ChangePage("../Pages/ReportPage.xaml", "Звіт 1");
        }

        [RelayCommand]
        static void Report2()
        {
            App.ChangePage("../Pages/Report2Page.xaml", "Звіт 2");
        }

        [RelayCommand]
        static void Report3()
        {
            App.ChangePage("../Pages/Report3Page.xaml", "Звіт 3");
        }

        [RelayCommand]
        static void Report4()
        {
            App.ChangePage("../Pages/Report4Page.xaml", "Звіт 4");
        }
        [RelayCommand]
        static void Report5()
        {
            App.ChangePage("../Pages/Report5Page.xaml", "Звіт 5");
        }
        [RelayCommand]
        static void Report6()
        {
            App.ChangePage("../Pages/Report6Page.xaml", "Звіт 6");
        }
    }

}
