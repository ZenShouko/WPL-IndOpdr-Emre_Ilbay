using ClassLib.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.Business
{
    public class Cards
    {
        public Card PokemonCard()
        {
            return new Card
            {
                Name = "Pikachu",
                HP = 60,
                Type = "Electric",
                Attack1 = "Thundershock",
                Attack2 = "Thunderbolt",
                Weakness = "Fighting",
                Resistance = "Metal",
                Generation = 1
            };
        }
    }
}
