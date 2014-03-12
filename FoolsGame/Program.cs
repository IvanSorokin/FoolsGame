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
            bool t = false;
            while (true)
            {
                if (t)
                    break;
                AttackResponse firstAttack = players[(turn - 1 + countOfPlayer) % countOfPlayer].FirstMove(
                    new MoveInfo() { CurrentTable = table, PlayerHand = players[(turn - 1 + countOfPlayer) % countOfPlayer].hand, Suit = trumpCard.suit });
                Arbiter.TryToAttack(firstAttack, (turn - 1 + countOfPlayer) % countOfPlayer);
                while (true)//Пока что понятия не имею, когда это закончить. нужна помощь
                {
                    DefendInfo defend = players[turn].Defend(
                        new MoveInfo() { CurrentTable = table, PlayerHand = players[(turn - 1 + countOfPlayer) % countOfPlayer].hand, Suit = trumpCard.suit });
                    if (defend.Move == WhatMove.Translate)
                    {
                        turn += 1;
                        continue;
                    }
                    if (defend.Move == WhatMove.Take)
                    {
                        turn = (turn + 2) % countOfPlayer;
                        break;
                    }
                    AttackResponse addAttack = players[(turn + 1) % countOfPlayer].AdditionalMove(
                        new MoveInfo() { CurrentTable = table, PlayerHand = players[(turn - 1 + countOfPlayer) % countOfPlayer].hand, Suit = trumpCard.suit });
                    Arbiter.TryToAttack(addAttack, (turn + 1) % countOfPlayer);
                    addAttack = players[(turn - 1 + countOfPlayer) % countOfPlayer].AdditionalMove(
                        new MoveInfo() { CurrentTable = table, PlayerHand = players[(turn - 1 + countOfPlayer) % countOfPlayer].hand, Suit = trumpCard.suit });
                    Arbiter.TryToAttack(addAttack, (turn - 1 + countOfPlayer) % countOfPlayer);
                }
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
