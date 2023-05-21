using ClassLib.Business.Entities;
using Newtonsoft.Json;

namespace MauiAppNET7
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async Task<bool> TestConnection()
        {
            // Testing the connection.
            HttpClient client = new HttpClient();
            string url = "http://localhost:5000/api/PokeCard/All";

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                AppendLog(response.ToString());
                return true;
            }
            catch (Exception ex)
            {
                AppendLog(ex.Message);
                return false;
            }
        }

        private async Task LoadCards()
        {
            using (HttpClient client1 = new HttpClient())
            {
                AppendLog("Loading Cards ..."); // Debugging purposes.

                string url = "http://localhost:5000/api/PokeCard/All";

                HttpResponseMessage response = await client1.GetAsync(url);
                response.EnsureSuccessStatusCode();
                AppendLog("Response: " + response.ToString());
                AppendLog("Client1: " + client1.ToString());

                string json = await response.Content.ReadAsStringAsync();

                // Fase4: We deserialize the json string.
                List<Card> cards = JsonConvert.DeserializeObject<List<Card>>(json);

                // Fase5: We set the ItemsSource property of the ListView.
                LstCards.ItemsSource = cards;
                LstCards.SelectedItem = null;
                LblCount.Text = $"Number of cards: {cards.Count}";
            }
        }

        private async void ContentPage_Loaded(object sender, EventArgs e)
        {
            AppendLog("[ContentPage Loaded! Testing connection ...]");
            if (await TestConnection())
            {
                AppendLog("[Connection success!]");
            }
            else
            {
                AppendLog("[Connection unsuccesful!]");
            }
        }

        private void AppendLog(string text)
        {
            LblLogs.Text += $"\n{text}";
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                await LoadCards();
            }
            catch (Exception ex)
            {
                AppendLog(ex.Message);
            }
        }
    }
}