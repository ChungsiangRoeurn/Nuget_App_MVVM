using CommunityToolkit.Mvvm.ComponentModel;
using NugetMVVP.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace NugetMVVP.ViewModels
{
    public partial class MoviesViewModel : ObservableObject
    {
        [ObservableProperty]
        private string filterText;

        [ObservableProperty]
        private ObservableCollection<MovieItems> movieSourceCollection;

        private readonly ObservableCollection<MovieItems> _allMovies;

        public MoviesViewModel()
        {
            _allMovies = new ObservableCollection<MovieItems>
            {
                new MovieItems { MovieName = "Action", MovieImage = "/Assets/clap_icon.png" },
                new MovieItems { MovieName = "Thriller", MovieImage = "/Assets/clap_icon.png" },
                new MovieItems { MovieName = "Adventure", MovieImage = "/Assets/clap_icon.png" },
                new MovieItems { MovieName = "Drama", MovieImage = "/Assets/clap_icon.png" },
                new MovieItems { MovieName = "Fantasy", MovieImage = "/Assets/clap_icon.png" },
                new MovieItems { MovieName = "Mystery", MovieImage = "/Assets/clap_icon.png" }
            };

            MovieSourceCollection = new ObservableCollection<MovieItems>(_allMovies);
        }

        partial void OnFilterTextChanged(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                MovieSourceCollection = new ObservableCollection<MovieItems>(_allMovies);
                return;
            }

            var filtered = _allMovies.Where(m =>
                m.MovieName.Contains(value, System.StringComparison.OrdinalIgnoreCase));

            MovieSourceCollection = new ObservableCollection<MovieItems>(filtered);
        }
    }
}