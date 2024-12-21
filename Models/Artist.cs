
using System.ComponentModel.DataAnnotations;
namespace MusicAppWPF.Models;

public class Artist:TimeStamp
{
    [Key]
    public Guid ArtistId { get; set; }
    public string Name { get; set; }
    public string Bio { get; set; }

}