using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NugetMVVP.Models;
using System.Collections.ObjectModel;

namespace NugetMVVP.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        [ObservableProperty]
        private string pageTitle = "Home";

        public ObservableCollection<HomeItems> HomeSourceCollection { get; }
        
        private readonly NavigationViewModel _nav;

        public IRelayCommand<string> ThisPCCommand { get; }
        public HomeViewModel(NavigationViewModel nav)
        {
            _nav = nav;

            HomeSourceCollection = new ObservableCollection<HomeItems>
            {
               new HomeItems { HomeName = "This PC", HomeImage = "/Assets/pc_icon.png" },
            };

            ThisPCCommand = new RelayCommand<string>((name) =>
            {
                System.Diagnostics.Debug.WriteLine($"Clicked: {name}");
            });
        }

        [RelayCommand]
        private void OpenThisPC()
        {
            _nav.SelectedViewModel = new PCViewModel(_nav);
        }
    }
}