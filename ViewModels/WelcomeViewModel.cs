using System.Windows.Input;

namespace MusicAppWPF.ViewModels
{
    public class WelcomeViewModel
    {
        public ICommand NavigateToAlbumsCommand { get; }
        public ICommand NavigateToArtistsCommand { get; }
        public ICommand NavigateToAllTracksCommand { get; }

        public WelcomeViewModel()
        {
            NavigateToAlbumsCommand = new RelayCommand(OnNavigateToAlbums);
            NavigateToArtistsCommand = new RelayCommand(OnNavigateToArtists);
            NavigateToAllTracksCommand = new RelayCommand(OnNavigateToAllTracks);
        }

        public event Action<string> NavigateRequested;

        private void OnNavigateToAlbums()
        {
            NavigateRequested?.Invoke("Views/Albums.xaml");
        }

        private void OnNavigateToArtists()
        {
            NavigateRequested?.Invoke("Views/Artists.xaml");
        }

        private void OnNavigateToAllTracks()
        {
            NavigateRequested?.Invoke("Views/AllTracks.xaml");
        }
    }
}
