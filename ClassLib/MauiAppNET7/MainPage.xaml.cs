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

        private async Task LoadCards()
        {
            List<Card> cards = null;

            // Fase4 (lol rip 1-2-3): We deserialize the json string into List<Card>.
            try
            {
                cards = await RestService.GetAll();
            }
            catch (Exception ex)
            {
                AppendLog(ex.Message);
            }

            // Fase5: We set the ItemsSource.
            LstCards.ItemsSource = cards;

            // Counting the number of cards.
            LblCount.Text = $"Number of cards: {cards.Count}";
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