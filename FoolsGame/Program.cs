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
        static void Main(string[] args)
        {
            //Console.WriteLine("Let's play!"); 
            //pack = Arbiter.FormInitialPack();
            //trumpCard = pack.First();
            //players = new Player[countOfPlayer];
            //for (int i = 0; i < countOfPlayer; i++)
            //{
            //    players[i] = new Player();
            //    Arbiter.GiveCardsToPlayer(players[i], pack);
            //}
            //foreach (Nominal nominal in (Nominal[])Enum.GetValues(typeof(Nominal)))
            //{
            //    Card card = new Card(trumpCard.suit, nominal);
            //    for (int i = 0; i < countOfPlayer; i++)
            //        if (players[i].hand.Contains(card))
            //        {
            //            turn = (i + 1) % countOfPlayer;
            //            break;
            //        }
            //}
            //while (true)
            //{
            //    //тут типа ход игры)))
                
            //}
            //rollback
        }
    }
}
