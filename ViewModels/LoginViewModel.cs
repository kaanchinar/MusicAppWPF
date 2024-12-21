using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MusicAppWPF.Data;
using MusicAppWPF.Views;

namespace MusicAppWPF.ViewModels;

public class LoginViewModel : ViewModelBase
{
    private string _username;
    private string _password;
    private string _errorMessage;

    public string Username
    {
        get => _username;
        set => SetProperty(ref _username, value);
        
    }
    
    public string Password
    {
        get => _password;
        set => SetProperty(ref _password, value);
    }
    
    public string ErrorMessage
    {
        get => _errorMessage;
        set => SetProperty(ref _errorMessage, value);
    }

    public ICommand LoginCommand => new RelayCommand(Login);
    
    private void Login()
    {
        using (var context = new MusicAppDbContext())
        {
            var hashedPassword = PasswordHelper.HashPassword(Password);
            var user = context.Users
                .FirstOrDefault(u => u.Username == Username && u.PasswordHash == hashedPassword);

            if (user != null)
            {
                var welcomePage = new Welcome();
                if (Application.Current.MainWindow != null)
                {
                    var mainFrame = Application.Current.MainWindow.FindName("MainFrame") as Frame;
                    mainFrame?.Navigate(welcomePage);
                }
            }
            else
            {
                ErrorMessage = "Invalid username or password";
            }
        }
    }


}