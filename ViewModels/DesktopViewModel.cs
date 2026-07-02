using CommunityToolkit.Mvvm.ComponentModel;
using NugetMVVP.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace NugetMVVP.ViewModels
{
    public partial class DesktopViewModel : ObservableObject
    {
        [ObservableProperty]
        private string filterText;

        private readonly ObservableCollection<DesktopItems> _allItems;

        [ObservableProperty]
        private ObservableCollection<DesktopItems> desktopSourceCollection;

        public DesktopViewModel()
        {
            _allItems = new ObservableCollection<DesktopItems>
             {
                new DesktopItems { DesktopName = "File", DesktopImage = "/Assets/file_icon.png" },
                new DesktopItems { DesktopName = "Music", DesktopImage = "/Assets/musical_icon.png" },
                new DesktopItems { DesktopName = "Pictures", DesktopImage = "/Assets/picture_icon.png" },
                new DesktopItems { DesktopName = "Analytics", DesktopImage = "/Assets/analytics_icon.png" },
                new DesktopItems { DesktopName = "Webcam", DesktopImage = "/Assets/webcam_icon.png" },
                new DesktopItems { DesktopName = "Printer", DesktopImage = "/Assets/printer_icon.png" },
                new DesktopItems { DesktopName = "Services", DesktopImage = "/Assets/services_icon.png" },
                new DesktopItems { DesktopName = "Chart", DesktopImage = "/Assets/chart_icon.png" },
                new DesktopItems { DesktopName = "Film", DesktopImage = "/Assets/film_icon.png" },
                new DesktopItems { DesktopName = "Alarm", DesktopImage = "/Assets/alarm_icon.png" },
                new DesktopItems { DesktopName = "Headphone", DesktopImage = "/Assets/headphone_icon.png" },
                new DesktopItems { DesktopName = "Password", DesktopImage = "/Assets/password_icon.png" },
                new DesktopItems { DesktopName = "Calendar", DesktopImage = "/Assets/calendar_icon.png" }
            };

            DesktopSourceCollection = new ObservableCollection<DesktopItems>(_allItems);
        }

        partial void OnFilterTextChanged(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                DesktopSourceCollection = new ObservableCollection<DesktopItems>(_allItems);
                return;
            }

            var filtered = _allItems
                .Where(x => x.DesktopName.Contains(value, System.StringComparison.OrdinalIgnoreCase))
                .ToList();

            DesktopSourceCollection = new ObservableCollection<DesktopItems>(filtered);
        }
    }
}