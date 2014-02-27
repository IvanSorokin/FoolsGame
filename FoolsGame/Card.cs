using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoolsGame
{
    public enum Suit { Spades, Hearts, Diamonds, Clubs };
    public enum Nominal { Ace = 8, King = 7, Queen = 6, Jack = 5, Ten = 4, Nine = 3, Eight = 2, Seven = 1, Six = 0};
    //digits for more comfortable comp-s

    public class Card
    {
        public Suit suit
        {
            get;
            set;
        }

        public Nominal nominal
        {
            get;
            set;
        }

        public Card(Suit _suit, Nominal _nominal)
        {
            suit = _suit;
            nominal = _nominal;
        }
    }
}
