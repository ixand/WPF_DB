using FloxelLib.MVVM;

namespace WPF_DB.MVVM
{
    public partial class MainViewModel : BaseViewModel
    {
        [UpdateProperty]
        private string _windowTitle = "Вхід", _currentPage = "../Pages/LoginPage.xaml";

        public MainViewModel()
        {
            App.PageChanged += (sender, page) => CurrentPage = page;
            App.TitleChanged += (sender, title) => WindowTitle = title;
        }
    }
}
