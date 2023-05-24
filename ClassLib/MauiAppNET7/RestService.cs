using ClassLib.Business.Entities;
using Newtonsoft.Json;

namespace MauiAppNET7
{
    internal static class RestService
    {
        private static bool isAndroid() => DeviceInfo.Current.Platform == DevicePlatform.Android;

        private static string REST_URL { get; set; }

        public static async Task<List<Card>> GetAll()
        {
            HttpResponseMessage response = new HttpResponseMessage();

            if (isAndroid())
                REST_URL = "http://10.0.2.2:5000/api/PokeCard/";
            else
                REST_URL = "http://localhost:5000/api/PokeCard/";

            using (HttpClient client = new HttpClient())
            {
                //Passing client base url
                client.BaseAddress = new Uri(REST_URL);

                //Passing request headers
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Send a request asynchronously and continue when complete
                response = await client.GetAsync(REST_URL + "All");

                //Check if the response is successful or not which is sent using HttpClient
                response.EnsureSuccessStatusCode();

                //Reading the response recieved in Json format
                string json = await response.Content.ReadAsStringAsync();

                //Deserializing into a list<Card>
                List<Card> cards = null;
                try
                {
                    cards = JsonConvert.DeserializeObject<List<Card>>(json);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                //Returning the list of cards
                return cards;
            }
        }
    }
}
