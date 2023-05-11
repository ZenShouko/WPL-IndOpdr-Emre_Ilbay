using ClassLib.Business.Entities;
using ClassLib.Data;
using ClassLib.Data.Framework;
using System.Data.SqlClient;

namespace ClassLib.Business
{
    public static class Cards
    {
        /// <summary>
        /// Returns all cards from the database as a list of Card object.
        /// </summary>
        public static List<Card> GetCards(string name)
        {
            CardData cardData = new CardData();
            return cardData.GetCards(name);
        }

        /// <summary>
        /// Adds a card to the database.
        /// </summary>
        /// <param name="newCard"></param>
        public static void AddCard(Card newCard)
        {
            ///Name, HP, Element, Weakness, resistance and stage.
            CardData cardData = new CardData();
            cardData.AddCard(newCard);
        }
    }
}
