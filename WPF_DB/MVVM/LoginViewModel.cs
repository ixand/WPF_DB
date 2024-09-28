using FloxelLib.Common;
using FloxelLib.MVVM;
using System;
using System.ComponentModel;
using System.Windows.Data;
using WPF_DB.Pages;

namespace WPF_DB.MVVM
{
    public partial class LoginViewModel : BaseViewModel
    {

        [UpdateProperty]
        private string username, password;


        [RelayCommand]
        private void Login()
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password)) return;
            try
            {
                DatabaseController.Connect(username, password);
                App.ChangePage("../Pages/DatabasePage.xaml", "База даних");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Помилка", System.Windows.MessageBoxImage.Error);
            }
        }

        

    }
}
