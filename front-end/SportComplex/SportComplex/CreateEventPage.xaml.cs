using SportComplex.Models;
using SportComplex.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Windows;
using System.Windows.Controls;

namespace SportComplex
{
    /// <summary>
    /// Interaction logic for CreateEventPage.xaml
    /// </summary>
    public partial class CreateEventPage : Page
    {
        public CreateEventPage()
        {
            InitializeComponent();
        }

        private void ButtonCloseCreateEvent_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new MainWindow().Content;
        }

        private void ButtonAprtament_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new ApartmentPage();
        }

        private async void ButtonCreate_Click(object sender, RoutedEventArgs e)
        {
            var competition = new Competition
            {
                Id = "sdfsdf",
                Name = NameTextBox.Text,
                AtletId = new List<string> { "ATL-122222333333" },
                StartDate = new DateTime(Convert.ToDateTime(StartDateTextBox.Text).Ticks + Convert.ToDateTime(StartTimeTextBox.Text).Ticks),
                EndDate = new DateTime(Convert.ToDateTime(EndDateTextBox.Text).Ticks + Convert.ToDateTime(EndTimeTextBox.Text).Ticks),
                Photo = "C://photos/competition.png",
                ApartamentId = "APRT-23423948320k483",
                Description = DescriptionTextBox.Text,
            };

            Application.Current.MainWindow.Content = new ApartmentPage();

            HttpClient client = new HttpClient();
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            };
            var json = JsonSerializer.Serialize(competition, options);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await client.PostAsync("https://localhost:7009/api/Competitions", content);
        }

        private void ButtonLogout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new AuthorizationPage();
        }
    }
}
