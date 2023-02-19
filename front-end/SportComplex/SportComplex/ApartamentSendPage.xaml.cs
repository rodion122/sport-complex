using SportComplex.Models;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Windows;
using System.Windows.Controls;

namespace SportComplex
{
    /// <summary>
    /// Interaction logic for ApartamentSendPage.xaml
    /// </summary>
    public partial class ApartamentSendPage : Page
    {
        public ApartamentSendPage()
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

        private async void ButtonSend_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new ApartamentSentPage();

            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://localhost:7009/api/Competitions");
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
            var result = await response.Content.ReadFromJsonAsync<Competition[]>(options);
            var item = result.FirstOrDefault(i => i.Name.Contains("Гродно93 - Олимпия"));

            item.ApartamentId = "APRT-23423948320k485";
            var json = JsonSerializer.Serialize(item, options);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await client.PutAsync("https://localhost:7009/api/Competitions", content);
        }
    }
}
