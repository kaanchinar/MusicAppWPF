using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicAppWPF
{
    public class User(string username, string password)
    {
        public string Username { get; private set; } = username;
        private string Password { get; set; } = password;

        public bool ValidatePassword(string password)
        {
            return Password == password;
        }
    }

    public class UserDataBase(string filePath) 
    {
        private readonly string _filePath = filePath;

        // Database file path validation
        public bool ValidatePath()
        {
            return File.Exists(_filePath);
        }

        public bool ValidateCred(string username, string password)
        {
            var user = new User(username, password);
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length == 2)
                {
                    var storedUsername = parts[0];
                    var storedPassword = parts[1];
                    
                    if (user.Username == storedUsername && user.ValidatePassword(storedPassword))
                    {
                        return true;
                    }

                }
            }

            return false;

        }

    }
}
