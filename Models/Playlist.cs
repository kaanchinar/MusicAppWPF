using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicAppWPF.Models;


public class Playlist
{
    [Key]
    public Guid PlaylistId { get; set; }
    [ForeignKey("UserId")]
    public   User User { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}