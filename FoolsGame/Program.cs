using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoolsGame
{
    public enum Suit { Spades, Hearts, Diamonds, Clubs };
    public enum Nominal { Ace, King, Queen, Jack, Ten, Nine, Eight, Seven, Six };

    interface IPlayer
    {
        void FirstMove();
        void AdditionalMove();
        void Defend();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let's begin!");
            var pack = new List<Card>(); //try to make a pack

            foreach (Suit suit in (Suit[])Enum.GetValues(typeof(Suit)))
                foreach (Nominal nominal in (Nominal[])Enum.GetValues(typeof(Nominal)))
                {
                    Card card = new Card(suit, nominal);
                    pack.Add(card);
                }
        }
    }

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

        public Card (Suit _suit, Nominal _nominal)
        {
            suit = _suit;
            nominal = _nominal;
        }
    }

    class Arbiter
    {
        void IsPossibleTurn(); //etc
        void FormInitialPack();
    }
}
