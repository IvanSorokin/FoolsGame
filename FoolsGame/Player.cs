using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoolsGame
{
    interface IPlayer
    {
        void FirstMove(); //offense realization
        void AdditionalMove(); //additional moves if possible
        void Defend(); //player's reaction if he is under attack
    }

    class Player: IPlayer
    {
        public List<Card> hand;
        public DefenseInfo defenseInfo;
        //and his methods
    }

    class DefenseInfo
    {
        //information about defense turns, players use it to make decisions
    }
}
