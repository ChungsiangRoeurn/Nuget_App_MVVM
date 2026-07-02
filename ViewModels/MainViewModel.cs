using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;

namespace NugetMVVP.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private object currentView;

        public MainViewModel()
        {
            CurrentView = new LoginViewModel(this);
        }

        public void LoginSuccessful()
        {
            CurrentView = new NavigationViewModel();
        }


    }
}
