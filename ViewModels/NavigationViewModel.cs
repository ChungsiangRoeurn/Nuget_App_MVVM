
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NugetMVVP.Models;
using System.Collections.ObjectModel;
using System.Windows;

namespace NugetMVVP.ViewModels
{
    public partial class NavigationViewModel : ObservableObject
    {
        public ObservableCollection<MenuItems> SourceCollection { get; set; }

        [ObservableProperty]
        private ObservableCollection<MenuItems> filteredSourceCollection;

        [ObservableProperty]
        private string filterText;

        private readonly HomeViewModel _homeVM;

        [ObservableProperty]
        private object selectedViewModel;

        public NavigationViewModel()
        {

            _homeVM = new HomeViewModel(this);

            SourceCollection = new ObservableCollection<MenuItems>
            {
                new MenuItems { MenuName = "Home", MenuImage = "/Assets/Home_Icon.png" },
                new MenuItems { MenuName = "Desktop", MenuImage = "/Assets/Desktop_Icon.png" },
                new MenuItems { MenuName = "Documents", MenuImage = "/Assets/Document_Icon.png" },
                new MenuItems { MenuName = "Downloads", MenuImage = "/Assets/Download_Icon.png" },
                new MenuItems { MenuName = "Pictures", MenuImage = "/Assets/Image_Icon.png" },
                new MenuItems { MenuName = "Music", MenuImage = "/Assets/Music_Icon.png" },
                new MenuItems { MenuName = "Movies", MenuImage = "/Assets/Movies_Icon.png" },
                new MenuItems { MenuName = "Trash", MenuImage = "/Assets/Trash_Icon.png" }
            };

            FilteredSourceCollection = new ObservableCollection<MenuItems>(SourceCollection);

            SelectedViewModel = _homeVM;
        }

        [RelayCommand]
        private void Menu(string menuName)
        {
            SelectedViewModel = menuName switch
            {
                "Home"          => new HomeViewModel(this),
                "Desktop"       => new DesktopViewModel(),
                "Documents"     => new DocumentsViewModel(),
                "Downloads"     => new DownloadsViewModel(),
                "Pictures"      => new PicturesViewModel(),
                "Music"         => new MusicViewModel(),
                "Movies"        => new MoviesViewModel(),
                "Trash"         => new TrashViewModel(),
                _               => new HomeViewModel(this)
            };
        }

        partial void OnFilterTextChanged(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                FilteredSourceCollection = new ObservableCollection<MenuItems>(SourceCollection);
                return;
            }

            var filtered = SourceCollection
                .Where(x => x.MenuName.Contains(value, StringComparison.OrdinalIgnoreCase))
                .ToList();

            FilteredSourceCollection = new ObservableCollection<MenuItems>(filtered);
        }

        [RelayCommand]
        private void BackHome()
        {
            SelectedViewModel = _homeVM;
        }

        [RelayCommand]
        private void Exit()
        {
            var result = MessageBox.Show(
                "Do you really want to close this app?",
                "Exit Infomation",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes) 
            Application.Current.Shutdown();
        }

        [RelayCommand]
        private void Minimize()
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }
    }
}
