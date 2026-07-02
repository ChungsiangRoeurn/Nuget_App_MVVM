using NugetMVVP.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace NugetMVVP.Views
{
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();

            var main = new MainViewModel();

            DataContext = new LoginViewModel(main);
        }
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginViewModel vm)
            {
                vm.Password = PasswordBox.Password;
            }
        }

    }
}