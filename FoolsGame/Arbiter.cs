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
            return pack; //return a pack WITHOUT random, like a stock pack
        }

        public List<Card> RandomizePack( List<Card> initPack)
        {
            var rand = new Random();
            for (var i = 0; i < initPack.Count(); i++)
            {
                var temp = initPack[i];
                var randomedPosition = rand.Next(i, initPack.Count - 1);
                initPack[i] = initPack[randomedPosition];
                initPack[randomedPosition] = temp;
            }
            return initPack; //sample of randomed pack
        }

        public bool IsPossibleOffense(List<Card> playerHand, Table table )
        {
            //looking through player's hand and table position and checking
            //and then make a decision: allow this turn or ban this player for cheating
            //player give his hand and table position which he wanted to make*
            return true;
        }

        public bool IsPossibleDefense(List<Card> playerHand, Table table)
        {
            //looking through player's hand and table position and checking
            //and then make a decision: allow this turn or ban this player for cheating
            //player give his hand and table position which he wanted to make*
            return true;
        }

        public void GiveCardsToPlayer (Player player)
        {
            //append players hand with cards if necessary
        }

        public void BanPlayer (Player player)
        {
            //give a ban to player
        }
    }
}