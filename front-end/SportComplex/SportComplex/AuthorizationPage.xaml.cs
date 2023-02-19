using System.Windows;
using System.Windows.Controls;

namespace SportComplex
{
    /// <summary>
    /// Interaction logic for AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void ButtonAuthorize_Click(object sender, RoutedEventArgs e)
        {
            InvalidTextBlock.Visibility = Visibility.Hidden;
            if (AuthorizationManager.GetRole(EmailTextBox.Text, PasswordTextBox.Password).ToLower() == "manager")
            {
                Application.Current.MainWindow.Content = new FootballPage();
            }
            else if (AuthorizationManager.GetRole(EmailTextBox.Text, PasswordTextBox.Password).ToLower() == "schedulemanager")
            {
                Application.Current.MainWindow.Content = new SchedulePage();
            }
            else if (AuthorizationManager.GetRole(EmailTextBox.Text, PasswordTextBox.Password).ToLower() == "placemanager")
            {
                Application.Current.MainWindow.Content = new PlacePage();
            }
            else
            {
                InvalidTextBlock.Visibility = Visibility.Visible;
            }
        }
    }
}
