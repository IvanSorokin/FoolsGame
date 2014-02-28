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
        //The most stupid bot ever.
        //Ходить с минимальной некозырной карты. Если таковой не имеется,
        //ходить с минимальной козырной. Если несколько минимальных карт
        //И у атакуемого игрока количество карт, не меньше, чем количество
        //карт, которые подходят под вышеописанные условия.
        public void FirstMove()
        {
            throw new ArgumentException("");
        }
        //Если есть возможность - у защищающегося есть карты на руках И
        //(есть подходящая некозырная карта ИЛИ на руках остались только
        //козыри и минимальный из них можно подкинуть без нарушения правил)
        public void AdditionalMove()
        {
            throw new ArgumentException("");
        }
        //Выбирается минимальная по номиналу из некозырных, которой можно
        //побить карту на столе (если такой карты нет, то искать минимальную
        //карту из козырных). Если нет возможности покрыть карту, то брать. #
        public void Defend()
        {
            throw new ArgumentException("");
        }

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
