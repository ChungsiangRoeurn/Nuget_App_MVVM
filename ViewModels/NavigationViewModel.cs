
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NugetMVVP.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Data;

namespace NugetMVVP.ViewModels
{
    public partial class NavigationViewModel : ObservableObject
    {
       public ObservableCollection<MenuItems> SourceCollection { get; set; }

        [ObservableProperty]
        private object selectedViewModel;

        public NavigationViewModel()
        {
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

            // optional default page
            SelectedViewModel = new HomeViewModel();
        }

        [RelayCommand]
        private void Menu(string menuName)
        {
            SelectedViewModel = menuName switch
            {
                "Home" => new HomeViewModel(),
                "Desktop" => new DesktopViewModel(),
                "Documents" => new DocumentsViewModel(),
                "Downloads" => new DownloadsViewModel(),
                "Pictures" => new PicturesViewModel(),
                "Music" => new MusicViewModel(),
                "Movies" => new MoviesViewModel(),
                "Trash" => new TrashViewModel(),
                _ => new HomeViewModel()
            };
        }

        [RelayCommand]
        private void Exit()
        {
            Application.Current.Shutdown();
        }
    }
}
