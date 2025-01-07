using MusicAppWPF.ViewModels;
using System.Windows.Controls;

namespace MusicAppWPF.Views;

public partial class Welcome : Page
{
    private readonly WelcomeViewModel _viewModel;
    public Welcome()
    {
        InitializeComponent();
        // Initialize ViewModel
        _viewModel = new WelcomeViewModel();

        // Set DataContext
        DataContext = _viewModel;

        // Subscribe to Navigation Event
        _viewModel.NavigateRequested += OnNavigateRequested;
    }
    private void OnNavigateRequested(string pageUri)
    {
        // Navigate the Frame
        ContentFrame.Navigate(new Uri(pageUri, UriKind.Relative));
    }
}