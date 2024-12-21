using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicAppWPF.Models;

public class UserSongActivity
{
    [Key]
    public Guid ActivityId { get; set; }
    [ForeignKey("UserId")]
    public User User { get; set; }
    [ForeignKey("SongId")]
    public Song Song { get; set; }
    public DateTime LastPlayedAt { get; set; }
    public int PlayCount { get; set; }
    public bool IsFavorite { get; set; }
}