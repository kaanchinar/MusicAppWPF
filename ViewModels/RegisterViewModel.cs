using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MusicAppWPF.Data;
using MusicAppWPF.Models;
using MusicAppWPF.Views;

namespace MusicAppWPF.ViewModels;

public class RegisterViewModel : ViewModelBase
{
    private  string _username;
    private  string _password;
    private  string _email;

    public required string Email
    {
        get => _email;
        set
        {
            _email = value;
            OnPropertyChanged();
        }
    }
    public required string Username
    {
        get => _username;
        set
        {
            _username = value;
            OnPropertyChanged();
        }
    }
    public required string Password
    {
        private get => _password;
        set
        {
            _password = value;
            OnPropertyChanged();
        }
    }
    
    public ICommand RegisterCommand => new RelayCommand(Register);
    
    private void Register()
    {
        using (var context = new MusicAppDbContext())
        {
            // Hash the password before saving it to the database
            var hashedPassword = PasswordHelper.HashPassword(Password);
            var user = context.Users.Add(new User{Username = Username, PasswordHash = hashedPassword, Email = Email});
            if (user?.Entity != null){
                context.SaveChanges();
                
                // Navigate to the main page
                var welcomePage = new Welcome();
                if (Application.Current.MainWindow != null)
                {
                    var mainFrame = Application.Current.MainWindow.FindName("MainFrame") as Frame;
                    mainFrame?.Navigate(welcomePage);
                }
            }
        }
    }

    public new event PropertyChangedEventHandler? PropertyChanged;

    protected new void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    
}