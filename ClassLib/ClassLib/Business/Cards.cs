using ClassLib.Business.Entities;
using ClassLib.Data.Framework;
using System.Data.SqlClient;

namespace ClassLib.Business
{
    public static class Cards
    {
        private static string ConnectionString = Settings.GetConnectionString();
        public static List<Card> CardList;

        /// <summary>
        /// Returns all cards from the database as a list of Card object.
        /// </summary>
        internal static List<Card> GetCards(string name)
        {
            List<Card> list = new List<Card>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                //Query& Command
                string query = "SELECT * FROM PokemonTable where Name like @CardName;";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@CardName", $"%{name}%");
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Card()
                    {
                        Name = reader.GetString(0),
                        HP = reader.GetInt32(1),
                        Element = reader.GetString(2),
                        Weakness = reader.IsDBNull(3) ? null : reader.GetString(3),
                        Resistance = reader.IsDBNull(4) ? null : reader.GetString(4),
                        //Weakness = reader.GetString(3),
                        //Resistance = reader.GetString(4),
                        Stage = reader.GetInt32(5)
                    });
                }
                reader.Close();

                //Return lijst
                return list;
            }
        }

        public static void AddCard(Card newCard)
        {
            ///Name, HP, Element and stage are required.
            ///Weakness and resistance are optional.
            using (SqlConnection connection = new SqlConnection(Settings.GetConnectionString()))
            {
                connection.Open();

                //Query& Command
                string weakness = newCard.Weakness != null ? "@Weakness, " : "";
                string resistance = newCard.Resistance != null ? "@Resistance, " : "";

                string query = "Insert into PokemonTable " +
                    $"(Name, HP, Element, {weakness.Replace("@", "")}{resistance.Replace("@", "")}Stage) " +
                    $"values(@Name, @HP, @Element, {weakness}{resistance}@Stage);";

                //Parameters
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Name", newCard.Name);
                cmd.Parameters.AddWithValue("@HP", newCard.HP);
                cmd.Parameters.AddWithValue("@Element", newCard.Element);
                cmd.Parameters.AddWithValue("@Weakness", newCard.Weakness ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Resistance", newCard.Resistance ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Stage", newCard.Stage);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
