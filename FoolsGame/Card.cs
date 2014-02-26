using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoolsGame
{
    public enum Suit { Spades, Hearts, Diamonds, Clubs };
    public enum Nominal { Ace, King, Queen, Jack, Ten, Nine, Eight, Seven, Six };

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
