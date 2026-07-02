using CommunityToolkit.Mvvm.ComponentModel;
using NugetMVVP.Models;
using System.Collections.ObjectModel;

namespace NugetMVVP.ViewModels
{
    public partial class MusicViewModel : ObservableObject
    {
        [ObservableProperty]
        private string filterText;

        [ObservableProperty]
        private ObservableCollection<MusicItems> musicSourceCollection;

        private readonly ObservableCollection<MusicItems> _allItems;


        public MusicViewModel()
        {
            _allItems = new ObservableCollection<MusicItems>
            {
                new MusicItems { MusicName = "Bass", MusicImage = "/Assets/note_icon.png" },
                new MusicItems { MusicName = "Beats", MusicImage = "/Assets/note_icon.png" },
                new MusicItems { MusicName = "Electronic", MusicImage = "/Assets/note_icon.png" },
                new MusicItems { MusicName = "Hip hop", MusicImage = "/Assets/note_icon.png" },
                new MusicItems { MusicName = "Deep House", MusicImage = "/Assets/note_icon.png" },
                new MusicItems { MusicName = "Instrumental", MusicImage = "/Assets/note_icon.png" }
            };
            MusicSourceCollection = new ObservableCollection<MusicItems>(_allItems);
        }

        partial void OnFilterTextChanged(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                MusicSourceCollection = new ObservableCollection<MusicItems>(_allItems);
                return;
            }

            var filtered = _allItems.Where(x =>
                x.MusicName.Contains(value, System.StringComparison.OrdinalIgnoreCase));

            MusicSourceCollection = new ObservableCollection<MusicItems>(filtered);
        }

    }
}