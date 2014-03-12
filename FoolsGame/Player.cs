using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoolsGame
{
    interface IPlayer
    {
        AttackResponse FirstMove(MoveInfo move); //offense realization
        AttackResponse AdditionalMove(MoveInfo move); //additional moves if possible
        DefendInfo Defend(MoveInfo move); //player's reaction if he is under attack
    }

    public class Player:IPlayer
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

        public AttackResponse FirstMove(MoveInfo moveInfo)
        {
            //throw new NotImplementedException();
            var cardToMove = new Card(Program.trumpCard.suit, Nominal.Ace);
            foreach (var value in moveInfo.PlayerHand)
                if (value.suit != Program.trumpCard.suit && value.nominal <= cardToMove.nominal)
                    cardToMove = value;
            if (cardToMove.suit == Program.trumpCard.suit)
                foreach (var value in moveInfo.PlayerHand)
                    if (value.nominal < cardToMove.nominal)
                        cardToMove = value;
            var response = new AttackResponse();
            response.OffCards = new List<Card>();
            response.OffCards.Add(cardToMove);
            return response;
        }

        public AttackResponse AdditionalMove(MoveInfo moveInfo)//Table table, int enemyCardCount, List<Card> myHand)
        {
            //throw new NotImplementedException();
            var response = new AttackResponse();
            response.OffCards = new List<Card>();
            var enemyCardCount = moveInfo.CountOfDefenseCards;
            if (moveInfo.CurrentTable.TablePosition.Count == 0)
                throw new Exception("somthing went wrong in AdditionalMove :C");
            foreach (var value in moveInfo.CurrentTable.TablePosition)
            {
                if (moveInfo.PlayerHand.Contains(value.DefCard) && value.DefCard.nominal != Program.trumpCard.nominal)
                    foreach (var value2 in moveInfo.PlayerHand)
                        if (value2.nominal == value.DefCard.nominal && enemyCardCount != 0)
                        {
                            response.OffCards.Add(value2);
                            enemyCardCount--;
                        }
                if (moveInfo.PlayerHand.Contains(value.OffCard) && value.OffCard.nominal != Program.trumpCard.nominal)
                    foreach (var value2 in moveInfo.PlayerHand)
                        if (value2.nominal == value.OffCard.nominal && enemyCardCount != 0)
                        {
                            response.OffCards.Add(value2);
                            enemyCardCount--;
                        }
            }
            return response;
        }

        public DefendInfo Defend(MoveInfo moveInfo)//Table table, int enemyCardCount, List<Card> myHand)
        {
            var info = new DefendInfo();
            info.BeatenCards = new List<Card>();
            var table = moveInfo.CurrentTable;
            var myHand = moveInfo.PlayerHand;
            if (table.TablePosition.Count == 1) //перевод, если карта одна
                foreach (var value in myHand)
                    if (value.nominal == table.TablePosition[0].OffCard.nominal)
                    {
                        info.BeatenCards.Add(value);
                        info.Move = WhatMove.Translate;
                        return info;
                    }
            foreach (var value in table.TablePosition) 
                if (!value.IsBeaten())
                {
                    foreach (var value2 in myHand) //попытка отбиться с помощью не-козыря 
                        if (value2.suit == value.OffCard.suit && value2.nominal > value.OffCard.nominal)
                            info.BeatenCards.Add(value2);
                    if (value.IsBeaten())
                        continue;
                    foreach (var value2 in myHand) //попытка отбиться с помозью козыря
                        if (Program.trumpCard.suit == value2.suit && value.OffCard.suit != Program.trumpCard.suit)
                            info.BeatenCards.Add(value2);
                    if (value.IsBeaten())
                        continue;
                    table.Clear(); //взять карты, вернуть пустой стол. арбитр разберется.
                    info.Move = WhatMove.Take;
                    return info;
                }
            return info;
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
