using FloxelLib.Common;
using FloxelLib.MVVM;
using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http.Headers;
using System.Windows.Controls;

namespace WPF_DB.MVVM
{
    public partial class DatabaseViewModel : BaseViewModel
    {


        private string _sqlQuery1 = "SELECT * FROM Category";
        private string _sqlQuery2 = "SELECT Coordinates.station_id,Coordinates.coordinates::TEXT FROM Coordinates";
        private string _sqlQuery3 = "SELECT * FROM Favorite";
        private string _sqlQuery4 = "SELECT * FROM Measurement_Unit";
        private string _sqlQuery5 = "SELECT * FROM MQTT_Server";
        private string _sqlQuery6 = "SELECT * FROM MQTT_Unit";
        private string _sqlQuery7 = "SELECT * FROM Optimal_Value";
        private string _sqlQuery8 = "SELECT * FROM Station";
        private string _sqlQuery9 = "SELECT * FROM Measurment limit 100";

        [RelayCommand]
        private void Back()
        {
            App.ChangePage("../Pages/LoginPage.xaml", "Вхід");

        }
        [RelayCommand]
        private void QueryPage()
        {
            App.ChangePage("../Pages/UserQueryPage.xaml", "Запит");
        }

        [RelayCommand]
        private void CheckTable(object? t)
        {
            string sql = (string)t!;
            
                  

            CollectedInfoViewModel.GlobalItems.Clear();
            try
            {


                foreach (var item in DatabaseController.SelectQuery(sql))
                {
                    string json = JsonConvert.SerializeObject(item);
                    object obj = JsonConvert.DeserializeObject<object>(json);
                    CollectedInfoViewModel.GlobalItems.Add(obj);
                }
                App.ChangePage("../Pages/CollectedInfoPage.xaml", "Інформація з Бази даних");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        [RelayCommand]
        private void Report()
        {
            App.ChangePage("../Pages/ReportMenuPage.xaml", "Звіти");
        }


    }

}
    


