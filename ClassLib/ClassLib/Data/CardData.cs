using ClassLib.Business;
using ClassLib.Business.Entities;
using ClassLib.Data.Framework;

namespace ClassLib.Data
{
    public class CardData : SqlServer
    {
        /// <summary>
        /// Returns a list of cards based on the name.
        /// Checks if the name of the card contains the given name.
        /// </summary>
        /// <param name="name">Pokemon Name</param>
        /// <returns>List with Card objects.</returns>
        public List<Card> GetCards(string name)
        {
            var cards = Cards.GetCards(name);

            if (cards.Count == 0)
            {
                throw new Exception("No cards found.");
            }
            else
            {
                return cards;
            }
        }

        /// <summary>
        /// Adds a card to the database.
        /// </summary>
        /// <param name="newCard">Expects a Card object.</param>
        public void AddCard(Card newCard)
        {
            Cards.AddCard(newCard);
        }
    }
}
