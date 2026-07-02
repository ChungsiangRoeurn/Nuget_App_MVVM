using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;

namespace NugetMVVP.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private object currentView;

        public NavigationViewModel NavigationVM { get;}

        public MainViewModel()
        {
        }


    }
}
