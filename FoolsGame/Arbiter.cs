using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoolsGame
{
    public class Arbiter
    {
        static public Stack<Card> FormInitialPack()
        {
			var pack = new List<Card>(); //try to make a pack
            foreach (Suit suit in (Suit[])Enum.GetValues(typeof(Suit)))
                foreach (Nominal nominal in (Nominal[])Enum.GetValues(typeof(Nominal)))
                {
                    Card card = new Card(suit, nominal);
                    pack.Add(card);
                }
            var finalStack = new Stack<Card>();
            var rand = new Random();
            for (var i = 0; i < pack.Count(); i++)
            {
                var temp = pack[i];
                var randomedPosition = rand.Next(i, pack.Count - 1);
                pack[i] = pack[randomedPosition];
                pack[randomedPosition] = temp;
                finalStack.Push(pack[i]);
            }
			return finalStack; 
        }

        static public Table TryToDefense(List<Card> playerHand, Table prevTable, Table desirableTable)
        {
            var removedCards = new List<Card>(); //check if all offcards were beaten
            if (desirableTable.TablePosition.Count == 0)
            {
                foreach (var e in prevTable.TablePosition)
                    playerHand.Add(e.OffCard);
                return desirableTable;
            }
            else
            if (desirableTable.TablePosition.Count - prevTable.TablePosition.Count == 1)
            {//check tranfer
                if (playerHand.Contains(desirableTable.TablePosition[1].OffCard) &&
                    desirableTable.TablePosition[1].OffCard.nominal == prevTable.TablePosition[0].OffCard.nominal)
                {
                    playerHand.Remove(desirableTable.TablePosition[1].OffCard);
                    return desirableTable;
                }
            }
            else
                foreach (var pairOfCard in desirableTable.TablePosition)
                    if (playerHand.Contains(pairOfCard.DefCard) && IsPairBeaten(pairOfCard)) removedCards.Add(pairOfCard.DefCard);
            if (removedCards.Count == desirableTable.TablePosition.Count)
            {
                foreach (var e in removedCards)
                    playerHand.Remove(e);
                return desirableTable;
            }
            return prevTable;
        }

        static public Table TryToAttack(List<Card> playerHand, Table desirableTable, int countOfDefenseCards)
        {
            if (desirableTable.TablePosition.Count <= countOfDefenseCards)
                {
                    foreach (var e in desirableTable.TablePosition)
                        if (!playerHand.Contains(e.OffCard)) throw new ArgumentException("");
                        return desirableTable;
                }
            return desirableTable; // will be changed
        }

        static public bool IsPairBeaten(PairCard pair)
        {
            bool casualBeating = pair.DefCard.nominal > pair.OffCard.nominal && pair.OffCard.suit == pair.DefCard.suit;
            bool trumpCasualBeating = pair.DefCard.suit == Program.trumpCard.suit && pair.DefCard.suit != pair.OffCard.suit;
            return casualBeating || trumpCasualBeating;
        }

        static public void GiveCardsToPlayer (Player player, Stack<Card> pack)
        {
            while (pack.Count > 0 && player.hand.Count < 6)
                player.hand.Add(pack.Pop());
        } 

        bool[] BannedPlayers = new bool[4];

        public void BanPlayer (int numberOfPlayer)
        {
            BannedPlayers[numberOfPlayer] = true;
        }
    }
}
