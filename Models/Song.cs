using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicAppWPF.Models;

public class Song
{
    [Key]
    public Guid SongId { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public string Duration { get; set; }
    public string FileUrl { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    [ForeignKey("AlbumId")]
    public Album Album { get; set; }
    [ForeignKey("ArtistId")]
    public Artist Artist { get; set; }
}