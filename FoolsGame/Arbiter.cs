using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoolsGame
{
    public class Arbiter
    {
        public List<Card> FormInitialPack()
        {
			var pack = new List<Card>(); //try to make a pack
            foreach (Suit suit in (Suit[])Enum.GetValues(typeof(Suit)))
                foreach (Nominal nominal in (Nominal[])Enum.GetValues(typeof(Nominal)))
                {
                    Card card = new Card(suit, nominal);
                    pack.Add(card);
                }
            var rand = new Random();
            for (var i = 0; i < pack.Count(); i++)
            {
                var temp = pack[i];
                var randomedPosition = rand.Next(i, pack.Count - 1);
                pack[i] = pack[randomedPosition];
                pack[randomedPosition] = temp;
            }
			return pack; 
        }

        static public bool TryToMove(List<Card> playerHand, Table prevTable, Table desirableTable, int countOfDefenseCards)
        {
            var removedCards = new List<Card>(); //check if all offcards were beaten
            if (desirableTable.TablePosition.Count - prevTable.TablePosition.Count == 1) //check tranfer
                if (playerHand.Contains(desirableTable.TablePosition[1].OffCard) && 
                    desirableTable.TablePosition[1].OffCard.nominal == prevTable.TablePosition[0].OffCard.nominal)
                {
                    playerHand.Remove(desirableTable.TablePosition[1].OffCard);
                    return true;
                }
                else
            foreach (var pairOfCard in desirableTable.TablePosition)
                if (playerHand.Contains(pairOfCard.DefCard) && IsPairBeaten(pairOfCard)) removedCards.Add(pairOfCard.DefCard);
            if (removedCards.Count == desirableTable.TablePosition.Count)
            {
                foreach (var e in removedCards)
                    playerHand.Remove(e);
                return true;
            }
            else 
                if (desirableTable.TablePosition.Count <= countOfDefenseCards)
                {
                    foreach (var e in desirableTable.TablePosition)
                        if (!playerHand.Contains(e.OffCard)) return false;
                        return true;
                }
            return false;
        }

        static public bool IsPairBeaten(PairCard pair)
        {
            bool casualBeating = pair.DefCard.nominal > pair.OffCard.nominal && pair.OffCard.suit == pair.DefCard.suit;
            bool trumpCasualBeating = pair.DefCard.suit == Program.trumpCard.suit && pair.DefCard.suit != pair.OffCard.suit;
            return casualBeating || casualBeating;
        }

        /*static public void GiveCardsToPlayer (Player player, List<Card> pack)
        {
            while (player.hand.Count < 6)
            {
                var card = pack[pack.Count - 1];
                player.hand.Add(card);
                pack.Remove(card);
            }
            //append players hand with cards if necessary
        } */

        bool[] BannedPlayers = new bool[4];

        public void BanPlayer (int numberOfPlayer)
        {
            BannedPlayers[numberOfPlayer] = true;
        }
    }
}
