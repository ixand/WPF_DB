using FloxelLib.Common;
using FloxelLib.MVVM;
using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;


namespace WPF_DB.MVVM
{
    public partial class UserQueryViewModel : BaseViewModel
    {
        [UpdateProperty]
        private string _sqlQuery = "SELECT * FROM Category";

        [RelayCommand]
        public void Open()
        {
            CollectedInfoViewModel.GlobalItems.Clear();
            try
            {


                foreach (var item in DatabaseController.SelectQuery(_sqlQuery))
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
        private void Back()
        {
            App.ChangePage("../Pages/DatabasePage.xaml", "База даних");
        }
    }
}
