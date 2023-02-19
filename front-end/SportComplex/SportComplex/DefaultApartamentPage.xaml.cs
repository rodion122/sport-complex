using System.Windows;
using System.Windows.Controls;

namespace SportComplex
{
    /// <summary>
    /// Interaction logic for DefaultApartamentPage.xaml
    /// </summary>
    public partial class DefaultApartamentPage : Page
    {
        public DefaultApartamentPage()
        {
            InitializeComponent();
        }

        private void ButtonEvents_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new MainWindow().Content;
        }

        private void ButtonLogout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new AuthorizationPage();
        }
    }
}
