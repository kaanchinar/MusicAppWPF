using System.Configuration;
using Npgsql;
namespace MusicAppWPF.Models;

public class User(string username, string password, string? email)
{
    public required string Username { get; set; } = username;
    public required string Password { get; set; } = password;
    public string? Email { get; set; } = email;

    public void SaveToDatabase()
    {
        var connectionUri = ConfigurationManager.ConnectionStrings["MusicApp"].ConnectionString;
        using (var connection = new NpgsqlConnection(connectionUri))
        {
            connection.Open();
            var query = @"INSERT INTO users (username, password_hash, email) VALUES (@username, @password_hash, @email)";
            var command = new NpgsqlCommand( query, connection);
            command.Parameters.AddWithValue("@username", Username);
            command.Parameters.AddWithValue("@password_hash", Password);
            command.Parameters.AddWithValue("@email", Email);
            command.ExecuteNonQuery();
        }
    }

    public bool VerifyCredentials()
    {
        var connectionUri = ConfigurationManager.ConnectionStrings["MusicApp"].ConnectionString;
        using (var connection = new NpgsqlConnection(connectionUri))
        {
            connection.Open();
            var query = @"SELECT COUNT(*) FROM users WHERE username = @username AND password_hash = @password_hash";
            var command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@username", Username);
            command.Parameters.AddWithValue("@password_hash", Password);

            return (long)(command.ExecuteScalar() ?? throw new InvalidOperationException()) == 1;
        }
    }
    
    
}