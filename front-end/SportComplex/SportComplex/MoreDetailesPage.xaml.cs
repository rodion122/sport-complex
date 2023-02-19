using SportComplex.Services;
using System.Windows;
using System.Windows.Controls;

namespace SportComplex
{
    /// <summary>
    /// Interaction logic for MoreDetailesPage.xaml
    /// </summary>
    public partial class MoreDetailesPage : Page
    {
        public MoreDetailesPage()
        {
            InitializeComponent();
        }

        private void ButtonLogout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new AuthorizationPage();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new SchedulePage();
        }
    }
}
