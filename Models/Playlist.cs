using Npgsql;
using System.Configuration;
using System.Collections.Generic;

namespace MusicAppWPF.Models;

public class PlaylistModel
{
    

    public void SaveToDatabase(Playlist playlist)
    {
        var connnectionUri = ConfigurationManager.ConnectionStrings["MusicApp"].ConnectionString;
        using (var connection = new NpgsqlConnection(connnectionUri))
        {
            connection.Open();
            var query = @"INSERT INTO playlists (name, description) VALUES (@name, @description)";
            var command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", playlist.Name);
            command.Parameters.AddWithValue("@description", playlist.Description);
            command.ExecuteNonQuery();
        }
    }

    public IEnumerable<Playlist> GetAllPlaylists()
    {
        var playlists = new List<Playlist>();
        var connnectionUri = ConfigurationManager.ConnectionStrings["MusicApp"].ConnectionString;
        using (var connection = new NpgsqlConnection(connnectionUri))
        {
            connection.Open();
            var query = @"SELECT name, description FROM playlists";
            var command = new NpgsqlCommand(query, connection);
            var reader = command.ExecuteReader();

            while (reader.Read())   
            {
                playlists.Add(new Playlist
                {
                    Name = reader.GetString(0),
                    Description = reader.GetString(1)
                });
            }
        }

        return playlists;
    }
    
}

public class Playlist
{
    public required string Name
    {
        get;
        set;
    } 

    public string Description
    {
        get;
        set;
    } 
}