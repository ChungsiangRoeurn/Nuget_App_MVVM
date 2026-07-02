using CommunityToolkit.Mvvm.Input;
using NugetMVVP.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace NugetMVVP.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new NavigationViewModel();

        }

    }
}