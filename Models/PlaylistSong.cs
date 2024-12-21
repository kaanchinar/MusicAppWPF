using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicAppWPF.Models;

public class PlaylistSong
{
    [Key]
    public Guid PlaylistSongId { get; set; }
    [ForeignKey("PlaylistId")]
    public Playlist Playlist { get; set; }
    [ForeignKey("SongId")]
    public Song Song { get; set; }
    public DateTime AddedAt { get; set; }
    
}