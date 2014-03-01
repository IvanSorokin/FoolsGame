using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoolsGame
{
    public enum Suit { spades, hearts, diamonds, clubs };
    public enum Nominal { vA = 8, vK = 7, vQ = 6, vJ = 5, vT = 4, v9 = 3, v8 = 2, v7 = 1, v6 = 0};
	//digits for more comfortable comp-s!

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
