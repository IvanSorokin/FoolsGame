using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoolsGame
{
    class Arbiter
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

        public bool TryToMove(List<Card> playerHand, Table prevTable, Table desirableTable)
        {
            var removedCards = new List<Card>(); //check if all offcards were beaten
            foreach (var pairOfCard in desirableTable.TablePosition)
                if (playerHand.Contains(pairOfCard.DefCard)) removedCards.Add(pairOfCard.DefCard);
            if (removedCards.Count == desirableTable.TablePosition.Count)
            {
                foreach (var e in removedCards)
                    playerHand.Remove(e);
                return true;
            }
            else //if he transfer a card?
            {
                if (desirableTable.TablePosition.Count - prevTable.TablePosition.Count == 1)
                    if (playerHand.Contains(desirableTable.TablePosition[1].OffCard))
                    {
                        playerHand.Remove(desirableTable.TablePosition[1].OffCard);
                        return true;
                    }
            }
            //looking through player's hand and table position and checking
            //and then make a decision: allow this turn or ban this player for cheating
            //player give his hand and table position which he wanted to make*
            return false;
        }

        public void GiveCardsToPlayer (Player player, List<Card> pack)
        {
            while (player.hand.Count < 6)
            {
                var card = pack[pack.Count - 1];
                player.hand.Add(card);
                pack.Remove(card);
            }
            //append players hand with cards if necessary
        }

        bool[] BannedPlayers = new bool[4];

        public void BanPlayer (int numberOfPlayer)
        {
            BannedPlayers[numberOfPlayer] = true;
        }
    }
}
