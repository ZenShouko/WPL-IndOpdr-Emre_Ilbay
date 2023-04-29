using ClassLib.Business;
using ClassLib.Business.Entities;

namespace ClassLib.Data
{
    public class CardData
    {
        /// <summary>
        /// Returns a list of cards based on the name.
        /// Giving an empty string will return all cards.
        /// </summary>
        /// <param name="name">Pokemon Name</param>
        /// <returns>List with Card objects.</returns>
        public List<Card> GetCards(string name)
        {
            return Cards.GetCards(name);
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
