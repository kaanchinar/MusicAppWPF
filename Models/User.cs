using System.ComponentModel.DataAnnotations;

namespace MusicAppWPF.Models;

public class User:TimeStamp
{
    [Key]
    public Guid UserId { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }

     
}

public abstract class TimeStamp
{
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}