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
        
        /*
        public Card[] PlayerHand;
        public List<PairCard> CurrentTable; //здесь только побитые карты, это решит проблемы null/не null
        public Card[] NotBeatenCards; //передавать отдельно, так удобнее
        public Suit Suit = Program.trumpCard.suit;
        public int[] CardsCounts;
        public int PlayerNumber; //какой у тебя номер в предыдущем массиве CardsCounts
        public int CountOfDefenseCards
        {
            get;
            set;
        }
        
        */
    }
}
