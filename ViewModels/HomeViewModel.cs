using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NugetMVVP.Models;
using System.Collections.ObjectModel;

namespace NugetMVVP.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        public ObservableCollection<HomeItems> HomeSourceCollection { get; }

        public IRelayCommand<string> ThisPCCommand { get; }
        public HomeViewModel()
        {
            HomeSourceCollection = new ObservableCollection<HomeItems>
           {
               new HomeItems { HomeName = "This PC", HomeImage = "/Assets/pc_icon.png" },
           };

            ThisPCCommand = new RelayCommand<string>((name) =>
            {
                System.Diagnostics.Debug.WriteLine($"Clicked: {name}");
            });
        }

        private void OpenItem(string? obj)
        {
            throw new NotImplementedException();
        }
    }
}