using FloxelLib.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace WPF_DB.MVVM
{
    public partial class CollectedInfoViewModel : BaseViewModel
    {
        public static ObservableCollection<object> GlobalItems = new ObservableCollection<object>();
        public ObservableCollection<object> Items { get => GlobalItems; }


        [RelayCommand]
        private void BacktoSQL()
        {
            App.ChangePage("../Pages/DatabasePage.xaml", "Вхід");
        }

    }
}
