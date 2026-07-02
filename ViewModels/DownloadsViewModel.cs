using CommunityToolkit.Mvvm.ComponentModel;
using NugetMVVP.Models;
using System.Collections.ObjectModel;

namespace NugetMVVP.ViewModels
{
    public partial class DownloadsViewModel : ObservableObject
    {
        [ObservableProperty]
        private string filterText;

        [ObservableProperty]
        private ObservableCollection<DownloadItems> downloadSourceCollection;

        private readonly ObservableCollection<DownloadItems> _allItems;

        public DownloadsViewModel()
        {
            _allItems = new ObservableCollection<DownloadItems>
            {
                new DownloadItems { DownloadName = "Visual Studio 2019", DownloadImage = "/Assets/vs_icon.png" },
                new DownloadItems { DownloadName = "Android Studio", DownloadImage = "/Assets/android_icon.png" },
                new DownloadItems { DownloadName = "Python", DownloadImage = "/Assets/python_icon.png" },
                new DownloadItems { DownloadName = "Swift", DownloadImage = "/Assets/swift_icon.png" },
                new DownloadItems { DownloadName = "Visual Studio Code", DownloadImage = "/Assets/vsc_icon.png" },
                new DownloadItems { DownloadName = "JavaScript", DownloadImage = "/Assets/javascript_icon.png" },
                new DownloadItems { DownloadName = "HTML 5", DownloadImage = "/Assets/html_icon.png" },
                new DownloadItems { DownloadName = "Angular", DownloadImage = "/Assets/angular_icon.png" },
                new DownloadItems { DownloadName = "Flutter", DownloadImage = "/Assets/flutter_icon.png" }
            };

            DownloadSourceCollection = new ObservableCollection<DownloadItems>(_allItems);
        }

        partial void OnFilterTextChanged(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                DownloadSourceCollection = new ObservableCollection<DownloadItems>(_allItems);
                return;
            }

            var filtered = _allItems
                .Where(x => x.DownloadName.Contains(value, System.StringComparison.OrdinalIgnoreCase))
                .ToList();

            DownloadSourceCollection = new ObservableCollection<DownloadItems>(filtered);
        }

    }
}