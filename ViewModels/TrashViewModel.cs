using CommunityToolkit.Mvvm.ComponentModel;
using NugetMVVP.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace NugetMVVP.ViewModels
{
    public partial class TrashViewModel : ObservableObject
    {
        [ObservableProperty]
        private string filterText;

        [ObservableProperty]
        private ObservableCollection<TrashItems> trashSourceCollection;

        private readonly ObservableCollection<TrashItems> _allItems;

        public TrashViewModel()
        {
            _allItems = new ObservableCollection<TrashItems>
            {
                new TrashItems
                {
                    TrashName = "Data.txt",
                    TrashImage = "/Assets/notepad_icon.png"
                }
            };

            TrashSourceCollection = new ObservableCollection<TrashItems>(_allItems);
        }

        partial void OnFilterTextChanged(string value)
        {
            IEnumerable<TrashItems> items = _allItems;

            if (!string.IsNullOrWhiteSpace(value))
            {
                items = items.Where(x =>
                    x.TrashName.Contains(value, StringComparison.OrdinalIgnoreCase));
            }

            TrashSourceCollection = new ObservableCollection<TrashItems>(items);
        }
    }
}