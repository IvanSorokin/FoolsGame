using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoolsGame
{
    public class Program
    {

        static public Card trumpCard;//козырь
        static public int countOfPlayer = 2;
        static public Player[] players; //массив игроков, один на всю программу
        static public int turn; //ход НА КОГО ходят, один на всю программу
        static public Table table = new Table(); // стол один на всю игру
        static public Stack<Card> pack;
        static public Dictionary<string, Card> defaultPack = FormDict(); //словарь со всеми картами.
        static void Main(string[] args)
        {
            Console.WriteLine("Let's play!"); 
            pack = Arbiter.FormInitialPack();
            trumpCard = pack.First();
            players = new Player[countOfPlayer];
            for (int i = 0; i < countOfPlayer; i++)
            {
                players[i] = new Player();
                Arbiter.GiveCardsToPlayer(players[i], pack);
            }
            foreach (Nominal nominal in (Nominal[])Enum.GetValues(typeof(Nominal)))
            {
                Card card = new Card(trumpCard.suit, nominal);
                for (int i = 0; i < countOfPlayer; i++)
                    if (players[i].hand.Contains(card))
                    {
                        turn = (i + 1) % countOfPlayer;
                        break;
                    }
            }
            while (true)
            {
                //тут типа ход игры)))
            }
        }
        static Dictionary<string, Card> FormDict()
        {
            var pack = new Dictionary<string, Card>(); //try to make a pack
              foreach (Suit suit in (Suit[])Enum.GetValues(typeof(Suit)))
                  foreach (Nominal nominal in (Nominal[])Enum.GetValues(typeof(Nominal)))
                  {
                      Card card = new Card(suit, nominal);
                      char c;
                      switch (nominal.ToString())
                      {
                          case "Six":
                              c = '6';
                              break;
                          case "Seven":
                              c = '7';
                              break;
                          case "Eight":
                              c = '8';
                              break;
                          case "Nine":
                              c = '9';
                              break;
                          default:
                              c = nominal.ToString()[0];
                              break;
                      }
                      pack.Add(c.ToString() + suit.ToString()[0].ToString().ToLower(), card);
                  }
              return pack;
        }
    }
}
