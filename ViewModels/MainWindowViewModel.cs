using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;

namespace MusicAppWPF.ViewModels;

public class MainWindowViewModel:ViewModelBase
{
    public ICommand NavigateToAlbumsCommand => new RelayCommand(NavigateToAlbums);
    public ICommand NavigateToArtistsCommand => new RelayCommand(NavigateToArtists);
    public ICommand NavigateToAllTracksCommand => new RelayCommand(NavigateToAllTracks);

    public MainWindowViewModel()
    {
        NavigateToAllTracks();
        Console.WriteLine("Initial: Navigated to AllTracks");
    }

    private void NavigateToAlbums()
    {
        Navigate("Albums.xaml");
        Console.WriteLine("Navigated to Albums");
    }
    private void NavigateToArtists()
    {
        Navigate("Views/Artists.xaml");
        Console.WriteLine("Navigated to Artists");
    }
    private void NavigateToAllTracks()
    {
        Navigate("AllTracks.xaml");
        Console.WriteLine("Navigated to AllTracks");
    }
    private void Navigate(string page)
    {
        if (Application.Current.MainWindow != null && Application.Current.MainWindow.FindName("ContentFrame") is Frame frame)
        {
            //frame.Navigate(new Uri(page, UriKind.Relative));
             frame.Source = new Uri(page, UriKind.Relative);
        }
    }
}