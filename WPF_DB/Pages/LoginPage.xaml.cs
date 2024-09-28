using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using WPF_DB.MVVM;

namespace WPF_DB.Pages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage
    {
        public LoginPage()
        {
            InitializeComponent();
            
        }
        LoginViewModel viewModel = new LoginViewModel();
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            
        }
    }
}
