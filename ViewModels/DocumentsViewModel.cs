using CommunityToolkit.Mvvm.ComponentModel;
using NugetMVVP.Models;
using System.Collections.ObjectModel;

namespace NugetMVVP.ViewModels
{
    public partial class DocumentsViewModel : ObservableObject
    {
        [ObservableProperty]
        private string filterText;

        [ObservableProperty]
        private ObservableCollection<DocumentItems> documentSourceCollection;

        private readonly ObservableCollection<DocumentItems> _allItems;

        public DocumentsViewModel()
        {
            _allItems = new ObservableCollection<DocumentItems>
            {
                new DocumentItems { DocumentName = "Books", DocumentImage = "/Assets/book_icon.png" },
                new DocumentItems { DocumentName = "Studio", DocumentImage = "/Assets/studio_icon.png" },
                new DocumentItems { DocumentName = "Export", DocumentImage = "/Assets/export_icon.png" },
                new DocumentItems { DocumentName = "Print", DocumentImage = "/Assets/print_icon.png" },
                new DocumentItems { DocumentName = "Orders", DocumentImage = "/Assets/order_icon.png" },
                new DocumentItems { DocumentName = "Stocks", DocumentImage = "/Assets/stock_icon.png" },
                new DocumentItems { DocumentName = "Invoice", DocumentImage = "/Assets/invoice_icon.png" }
            };

            DocumentSourceCollection = new ObservableCollection<DocumentItems>(_allItems);
        }

        partial void OnFilterTextChanged(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                DocumentSourceCollection = new ObservableCollection<DocumentItems>(_allItems);
                return;
            }

            var filtered = _allItems
                .Where(x => x.DocumentName.Contains(value, System.StringComparison.OrdinalIgnoreCase))
                .ToList();

            DocumentSourceCollection = new ObservableCollection<DocumentItems>(filtered);
        }
    }
}