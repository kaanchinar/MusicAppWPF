using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicAppWPF.Models;


public class Playlist:TimeStamp
{
    [Key]
    public Guid PlaylistId { get; set; }
    [ForeignKey("UserId")]
    public   User User { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

}