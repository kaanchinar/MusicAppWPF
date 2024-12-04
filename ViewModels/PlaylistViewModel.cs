using System.Collections.ObjectModel;
using System.Windows.Input;
using MusicAppWPF.Models;

namespace MusicAppWPF.ViewModels;

public class PlaylistViewModel: ViewModelBase
{
    private readonly PlaylistModel _model;
    public ObservableCollection<Playlist> Playlists { get; set; }

    // public ICommand AddPlaylistCommand => new RelayCommand(AddPlaylist);
    public ICommand AddPlaylistCommand { get; }
    public PlaylistViewModel()
    {
        _model = new PlaylistModel();
        Playlists = new ObservableCollection<Playlist>();

        AddPlaylistCommand = new RelayCommand(AddPlaylist);
        

        LoadPlaylists(); 
    }

    public void AddPlaylist()
    {
        // Playlists = new ObservableCollection<Playlist>(new PlaylistModel().GetAllPlaylists());
        var newPlaylist = new Playlist
        {
            Name = "Dummy Playlist",
            Description = "This is a dummy playlist"
        };
        _model.SaveToDatabase(newPlaylist);
        LoadPlaylists();
        
    }

    private void LoadPlaylists()
    {
        Playlists.Clear();
        // var currentPlaylists = new PlaylistModel().GetAllPlaylists();
        var playlistsFromDb = _model.GetAllPlaylists();

        foreach (var playlist in playlistsFromDb)
        {
            Playlists.Add(playlist);
        }
    }
}