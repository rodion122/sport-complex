using SportComplex.Models;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Windows;

namespace SportComplex
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Application.Current.MainWindow.Content = new AuthorizationPage();
        }

        private void ButtonCreateEvent_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new CreateEventPage();
        }

        private async void ButtonApartment_Click(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://localhost:7009/api/Competitions");
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
            var result = await response.Content.ReadFromJsonAsync<Competition[]>(options);
            var item = result.FirstOrDefault(i => i.Name.Contains("Гродно93 - Олимпия"));

            if (item != null && item.ApartamentId == "APRT-23423948320k484")
            {
                Application.Current.MainWindow.Content = new ApartamentSendPage();
            }
            else if (item != null && item.ApartamentId == "APRT-23423948320k485")
            {
                Application.Current.MainWindow.Content = new ApartamentSentPage();
            }
            else if (result.Length == 5)
            {
                Application.Current.MainWindow.Content = new ApartmentPage();
            }
            else
            {
                Application.Current.MainWindow.Content = new DefaultApartamentPage();
            }
        }

        private void ButtonLogout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new AuthorizationPage();
        }

        private void ButtonFootball_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new FootballPage();
        }
    }
}
