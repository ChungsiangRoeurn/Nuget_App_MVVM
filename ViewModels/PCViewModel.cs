using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NugetMVVP.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace NugetMVVP.ViewModels
{
    public partial class PCViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<PCItems> pCSourceCollection;

        private readonly ObservableCollection<PCItems> _allItems;

        private readonly NavigationViewModel _nav;

        public PCViewModel(NavigationViewModel nav)
        {
            _nav = nav;

            _allItems = new ObservableCollection<PCItems>
            {
                new PCItems { PCName = "Local Disk (C:)", PCImage = "/Assets/drive_icon.png" },
                new PCItems { PCName = "Local Disk (D:)", PCImage = "/Assets/drive_icon.png" },
                new PCItems { PCName = "Local Disk (E:)", PCImage = "/Assets/drive_icon.png" },
                new PCItems { PCName = "Local Disk (F:)", PCImage = "/Assets/drive_icon.png" }
            };

            PCSourceCollection = new ObservableCollection<PCItems>(_allItems);
        }

        [RelayCommand]
        private void BackHome()
        {
            Console.WriteLine("Back to Home clicked");
        }
    }
}