using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoolsGame
{
    class Program
    {
        static public string charOfTrump;
        static public Card trumpCard;
        static public Dictionary<string, Card> defaultPack = Arbiter.FormInitialPack();
        static public Player[] players = new Player[4]; //массив игроков, один на всю программу
        static public int turn; //ход НА КОГО ходят, один на всю программу
        static public Table table = new Table(); // стол один на всю игру
        static void Main(string[] args)
        {
            var pack = new List<Card>();
            trumpCard = pack[0];
            charOfTrump = trumpCard.suit.ToString()[0].ToString();
            var arbiter = new Arbiter();
            Console.ReadKey();
            
        }
    }
}
