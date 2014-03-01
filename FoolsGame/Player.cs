using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoolsGame
{
    interface IPlayer
    {
        Table FirstMove(int enemyCardCount, List<Card> myHand); //offense realization
        Table AdditionalMove(Table table, int enemyCardCount, List<Card> myHand); //additional moves if possible
        Table Defend(Table table, int enemyCardCount, List<Card> myHand); //player's reaction if he is under attack
    }

    class Player:IPlayer
    {
        public List<Card> hand = new List<Card>();
        //and his methods
        //The most stupid bot ever.
        //Ходить с минимальной некозырной карты. Если таковой не имеется,
        //ходить с минимальной козырной. Если несколько минимальных карт
        //И у атакуемого игрока количество карт, не меньше, чем количество
        //карт, которые подходят под вышеописанные условия.

        //Если есть возможность - у защищающегося есть карты на руках И
        //(есть подходящая некозырная карта ИЛИ на руках остались только
        //козыри и минимальный из них можно подкинуть без нарушения правил)

        //Выбирается минимальная по номиналу из некозырных, которой можно
        //побить карту на столе (если такой карты нет, то искать минимальную
        //карту из козырных). Если нет возможности покрыть карту, то брать. #   

        public Table FirstMove(int enemyCardCount, List<Card> myHand)
        {
            throw new NotImplementedException();
        }

        public Table AdditionalMove(Table table, int enemyCardCount, List<Card> myHand)
        {
            throw new NotImplementedException();
        }

        public Table Defend(Table table, int enemyCardCount, List<Card> myHand)
        {
            throw new NotImplementedException();
        }
    }
    //class DefenseInfo
    //{
    //    //information about defense turns, players use it to make decisions
    //    public int enemyCardCount = Program.players[Program.turn].hand.Count;
    //    public List<PairCard> tableStat = Program.table.TablePosition;
    //    public Move Move
    //    {
    //        get;
    //        set;
    //    }
    //}
}
