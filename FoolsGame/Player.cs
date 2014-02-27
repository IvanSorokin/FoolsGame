using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoolsGame
{
    public enum Move {TakeCards, Transfer, Defend};
    interface IPlayer
    {
        void FirstMove(); //offense realization
        void AdditionalMove(); //additional moves if possible
        void Defend(); //player's reaction if he is under attack
    }

    class Player//:IPlayer
    {
        public List<Card> hand = new List<Card>();
        public DefenseInfo defenseInfo;
        //and his methods
    }
    class DefenseInfo
    {
        //information about defense turns, players use it to make decisions
        public int enemyCardCount = Program.players[Program.turn].hand.Count;
        public List<PairCard> tableStat = Program.table.TablePosition;
        public Move move;
        public Move Move
        {
            get {return move;}
            set { move = value; }
        }
    }
}
