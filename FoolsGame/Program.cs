using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoolsGame
{
    class Program
    {
        static public Card trumpCard;
        static public Player[] players = new Player[4]; //массив игроков, один на всю программу
        static public int turn; //ход НА КОГО ходят, один на всю программу
        static public Table table = new Table(); // стол один на всю игру
        static void Main(string[] args)
        {
            var hand = new List<Card>() { new Card(Suit.Clubs, Nominal.Ten) };
            var attack = new Card(Suit.Clubs, Nominal.Eight);
            var defense = new Card(Suit.Clubs, Nominal.Ten);
            var desirableTable = new Table();
            desirableTable.AddOffCard(attack);
            desirableTable.AddDefCard(defense, 0);
            var ans = Arbiter.TryToMove(hand, desirableTable, desirableTable, 1);
            //rollback
        }
    }
}
