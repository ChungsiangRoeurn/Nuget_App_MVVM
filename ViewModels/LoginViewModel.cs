using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;

namespace NugetMVVP.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly MainViewModel _mainViewModel;

        public LoginViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        [ObservableProperty]
        private string username = string.Empty;

        [ObservableProperty]
        private string password = string.Empty;

        [RelayCommand]
        private void Login()
        {
            if (Username == "admin" && Password == "123")
            {
                MessageBox.Show("Logged In Successful");

            } else
            {
                MessageBox.Show("Incorrect Credentials");
            }
        }
    }
}