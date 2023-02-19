using System.Windows;
using System.Windows.Controls;

namespace SportComplex
{
    /// <summary>
    /// Interaction logic for PlacePage.xaml
    /// </summary>
    public partial class PlacePage : Page
    {
        public PlacePage()
        {
            InitializeComponent();
        }

        private void ButtonExpand_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new ExpandPlacePage();
        }

        private void ButtonLogout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new AuthorizationPage();
        }
    }
}
