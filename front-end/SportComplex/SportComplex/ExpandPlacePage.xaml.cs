using System.Windows;
using System.Windows.Controls;

namespace SportComplex
{
    /// <summary>
    /// Interaction logic for ExpandPlacePage.xaml
    /// </summary>
    public partial class ExpandPlacePage : Page
    {
        public ExpandPlacePage()
        {
            InitializeComponent();
        }

        private void ButtonExpand_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new PlacePage();
        }

        private void ButtonSelect_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new SelectedPlacePage();
        }

        private void ButtonLogout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new AuthorizationPage();
        }
    }
}
