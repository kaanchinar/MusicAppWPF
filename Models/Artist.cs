
using System.ComponentModel.DataAnnotations;
namespace MusicAppWPF.Models;

public class Artist
{
    [Key]
    public Guid ArtistId { get; set; }
    public string Name { get; set; }
    public string Bio { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}