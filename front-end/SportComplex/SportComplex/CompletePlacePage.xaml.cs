using System.Windows;
using System.Windows.Controls;

namespace SportComplex
{
    /// <summary>
    /// Interaction logic for CompletePlacePage.xaml
    /// </summary>
    public partial class CompletePlacePage : Page
    {
        public CompletePlacePage()
        {
            InitializeComponent();
        }

        private void ButtonLogout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new AuthorizationPage();
        }
    }
}
