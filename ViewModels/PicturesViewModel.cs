using CommunityToolkit.Mvvm.ComponentModel;
using NugetMVVP.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace NugetMVVP.ViewModels
{
    public partial class PicturesViewModel : ObservableObject
    {
        [ObservableProperty]
        private string filterText;

        [ObservableProperty]
        private ObservableCollection<PictureItems> pictureSourceCollection;

        private readonly ObservableCollection<PictureItems> _allPictures;

        public PicturesViewModel()
        {
            _allPictures = new ObservableCollection<PictureItems>
            {
                 new PictureItems { PictureName = "Logo", PictureImage = "/Assets/channel_icon.png" }
            };

            PictureSourceCollection = new ObservableCollection<PictureItems>(_allPictures);
        }

        partial void OnFilterTextChanged(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                PictureSourceCollection = new ObservableCollection<PictureItems>(_allPictures);
                return;
            }

            var filtered = _allPictures
                .Where(x => x.PictureName.Contains(value, System.StringComparison.OrdinalIgnoreCase))
                .ToList();

            PictureSourceCollection = new ObservableCollection<PictureItems>(filtered);
        }
    }
}