using ClassLib.Business;
using ClassLib.Business.Entities;
using ClassLib.Data.Framework;
using ClassLibTeam05.Data.Framework;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ClassLib.Data
{
    internal class CardData : SqlServer
    {
        /// <summary>
        /// Returns a list of cards based on the name.
        /// Giving an empty string will return all cards.
        /// </summary>
        /// <param name="name">Pokemon Name</param>
        /// <returns>List with Card objects.</returns>
        public List<Card> GetCards(string name)
        {
            string query = "SELECT * FROM PokeTable where Name like @CardName;";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@CardName", $"%{name}%");
            SelectResult result = Select(cmd);
            List<Card> listCards = new List<Card>();

            if (result.Succeeded)
            {
                foreach (DataRow row in result.DataTable.Rows)
                {
                    listCards.Add(new Card()
                    {
                        Name = row[0].ToString(),
                        HP = (int)row[1],
                        Element = row[2].ToString(),
                        Weakness = row[3].ToString(),
                        Resistance = row[4].ToString(),
                        Stage = (int)row[5]
                    }) ;
                }
            }

            return listCards;
        }

        /// <summary>
        /// Adds a card to the database.
        /// </summary>
        /// <param name="newCard">Expects a Card object.</param>
        public void AddCard(Card newCard)
        {
            string query = "Insert into PokeTable " +
                    $"(Name, HP, Element, Weakness, Resistance, Stage) " +
                    $"values(@Name, @HP, @Element, @Weakness, @Resistance, @Stage);";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@Name", newCard.Name);
            cmd.Parameters.AddWithValue("@HP", newCard.HP);
            cmd.Parameters.AddWithValue("@Element", newCard.Element);
            cmd.Parameters.AddWithValue("@Weakness", newCard.Weakness);
            cmd.Parameters.AddWithValue("@Resistance", newCard.Resistance);
            cmd.Parameters.AddWithValue("@Stage", newCard.Stage);

            InsertResult result = new InsertResult();
            result = Insert(cmd);
        }
    }
}
