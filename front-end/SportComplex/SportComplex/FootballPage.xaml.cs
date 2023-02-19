using SportComplex.Models;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Windows;
using System.Windows.Controls;

namespace SportComplex
{
    /// <summary>
    /// Interaction logic for FootballPage.xaml
    /// </summary>
    public partial class FootballPage : Page
    {
        public FootballPage()
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new MainWindow().Content;
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
    }
}
