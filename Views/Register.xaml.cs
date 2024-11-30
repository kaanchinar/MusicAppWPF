using System.Windows;
using System.Windows.Controls;
using MusicAppWPF.ViewModels;

namespace MusicAppWPF.Views;

public partial class Register : Page
{
    public Register()
    {
        InitializeComponent();
    }

    private void PasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        if (sender is PasswordBox passwordBox)
        {
            var viewModel = (RegisterViewModel)this.DataContext;
            viewModel.Password = passwordBox.Password;
        }
    }
}