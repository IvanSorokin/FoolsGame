using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoolsGame
{
    public enum Suit { spades, hearts, diamonds, clubs };
    public enum Nominal { AAce = 8, KKing = 7, QQueen = 6, JJack = 5, TTen = 4, N9ine = 3, E8ight = 2, S7even = 1, S6hest = 0};
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
