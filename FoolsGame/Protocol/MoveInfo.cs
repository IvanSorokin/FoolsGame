using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoolsGame
{
    public class MoveInfo
    {
        public List<Card> PlayerHand;
        public Table CurrentTable;
        public Suit Suit = Program.trumpCard.suit;
        public int CountOfDefenseCards
        {
            get;
            set;
        }
    }
}
