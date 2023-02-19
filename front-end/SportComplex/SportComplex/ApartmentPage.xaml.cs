using System.Windows;
using System.Windows.Controls;

namespace SportComplex
{
    /// <summary>
    /// Interaction logic for ApartmentPage.xaml
    /// </summary>
    public partial class ApartmentPage : Page
    {
        public ApartmentPage()
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
