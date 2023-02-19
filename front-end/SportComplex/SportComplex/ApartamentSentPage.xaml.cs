using System.Windows;
using System.Windows.Controls;

namespace SportComplex
{
    /// <summary>
    /// Interaction logic for ApartamentSentPage.xaml
    /// </summary>
    public partial class ApartamentSentPage : Page
    {
        public ApartamentSentPage()
        {
            InitializeComponent();
        }

        private void ButtonEvents_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new FootballPage();
        }

        private void ButtonLogout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new AuthorizationPage();
        }
    }
}
