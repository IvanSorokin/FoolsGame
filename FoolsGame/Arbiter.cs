using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoolsGame
{
    class Arbiter
    {
        public void IsPossibleTurn(); //etc

        public Card[] FormInitialPack()
        {
            var pack = new List<Card>(); //try to make a pack
            foreach (Suit suit in (Suit[])Enum.GetValues(typeof(Suit)))
                foreach (Nominal nominal in (Nominal[])Enum.GetValues(typeof(Nominal)))
                {
                    Card card = new Card(suit, nominal);
                    pack.Add(card);
                }
            return pack.ToArray();
        }
    }
}
