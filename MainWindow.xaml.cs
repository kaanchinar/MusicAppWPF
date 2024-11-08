using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MusicAppWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserDataBase userDataBase;
        public MainWindow()
        {
            InitializeComponent();
            userDataBase = new UserDataBase("C:\\database.txt");
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string username = UsernameTextBox.Text;
                string password = PasswordBox.Password;

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Please enter both username and password", "Error", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }

                if (!userDataBase.ValidatePath())
                {
                    MessageBox.Show("Error while reaching to database", "Error", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }

                if (userDataBase.ValidateCred(username, password))
                {
                    MessageBox.Show("Login Successful","Success", MessageBoxButton.OK);
                    
                }
                else
                {
                    MessageBox.Show("Wrong credentials", "Error", MessageBoxButton.OK);
                    
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"An error occurred: {exception.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }
    }
}