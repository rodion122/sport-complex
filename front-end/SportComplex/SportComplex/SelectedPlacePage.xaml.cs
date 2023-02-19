using SportComplex.Models;
using SportComplex.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SportComplex
{
    /// <summary>
    /// Interaction logic for SelectedPlacePage.xaml
    /// </summary>
    public partial class SelectedPlacePage : Page
    {
        public SelectedPlacePage()
        {
            InitializeComponent();
        }

        private async void ButtonApprove_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new CompletePlacePage();

            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://localhost:7009/api/Competitions");
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
            var result = await response.Content.ReadFromJsonAsync<Competition[]>(options);
            var item = result.FirstOrDefault(i => i.Name.Contains("Гродно93 - Олимпия"));

            item.ApartamentId = "APRT-23423948320k484";
            var json = JsonSerializer.Serialize(item, options);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await client.PutAsync("https://localhost:7009/api/Competitions", content);
        }

        private void ButtonLogout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new AuthorizationPage();
        }
    }
}
