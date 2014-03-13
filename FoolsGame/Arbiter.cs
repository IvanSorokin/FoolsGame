using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoolsGame
{
    public class Arbiter
    {
        static public Stack<Card> FormInitialPack()
        {
			var pack = new List<Card>(); //try to make a pack
            foreach (Suit suit in (Suit[])Enum.GetValues(typeof(Suit)))
                foreach (Nominal nominal in (Nominal[])Enum.GetValues(typeof(Nominal)))
                {
                    Card card = new Card(suit, nominal);
                    pack.Add(card);
                }
            var finalStack = new Stack<Card>();
            var rand = new Random();
            for (var i = 0; i < pack.Count(); i++)
            {
                var temp = pack[i];
                var randomedPosition = rand.Next(i, pack.Count - 1);
                pack[i] = pack[randomedPosition];
                pack[randomedPosition] = temp;
                finalStack.Push(pack[i]);
            }
			return finalStack; 
        }


//все эти методы должны принимать в аргументах все что им надо
//TryToDefence(Hand, Triumph, Offence, Defence) -- отдельно сделать методы для проверки корректности перевода,
// - корректности покрыти CheckTransfer, CheckDefend
//только проверка корректности

// изменения в отдельном методе, и его можно не тестировать

        static public void TryToDefense(DefendInfo defend)
        {
            if (defend.Move == WhatMove.Take)
            {
                foreach (var e in Program.table.TablePosition)
                    Program.players[Program.turn].hand.Add(e.OffCard);
            }
            if (defend.Move == WhatMove.Defend)
            {
                int i = 0;
                for (; i < Program.table.TablePosition.Count; i++)
                    if (!Program.table.TablePosition[i].IsBeaten())
                        break;
                if (Program.table.TablePosition.Count - i - 1 != defend.BeatenCards.Count)
                    throw new Exception();//��� � �� ����. ��������, ����� ������ ���������� �� �� �����...
                for (int j = 0; j < Program.table.TablePosition.Count; j++)
                {//��� � �� ����, ��� ��-������� ��� ��������... ���� ���� ���� - �������
                    var inHand = Program.players[Program.turn].hand.Contains(defend.BeatenCards[j]);
                    var sameSuit = Program.table.TablePosition[i + j].OffCard.suit == defend.BeatenCards[j].suit;
                    var lessNominal = Program.table.TablePosition[i + j].OffCard.nominal > defend.BeatenCards[j].nominal;
                    var isTrump = defend.BeatenCards[j].suit == Program.trumpCard.suit;
                    if (!inHand ||
                        (sameSuit && lessNominal) ||
                        (!sameSuit && !isTrump) )
                            throw new Exception();
                    Program.players[Program.turn].hand.Remove(defend.BeatenCards[j]);
                    Program.table.TablePosition[i + j].DefCard = defend.BeatenCards[j];
                }
            }
            if (defend.Move == WhatMove.Translate)
            {
                foreach (var e in defend.BeatenCards)//������ ��� �������, ������� �� �� ������� 2 ���������� �����
                    if (!Program.players[Program.turn].hand.Contains(e))
                        throw new Exception();
                    else
                    {
                        Program.table.TablePosition.Add(new PairCard() { OffCard = e, DefCard = null });
                        Program.players[Program.turn].hand.Remove(e);
                    }
            }
        }

        static public void TryToAttack(AttackResponse attack, int whoAttack)
        {
            if (attack.OffCards.Count <= Program.players[whoAttack].hand.Count)
                foreach (var e in attack.OffCards)
                    if (!Program.players[whoAttack].hand.Contains(e))
                        throw new Exception();
                    else
                        Program.players[whoAttack].hand.Remove(e);
            else
                throw new Exception(); // will be changed
        }

        static public bool IsPairBeaten(PairCard pair)
        {
            bool casualBeating = pair.DefCard.nominal > pair.OffCard.nominal && pair.OffCard.suit == pair.DefCard.suit;
            bool trumpCasualBeating = pair.DefCard.suit == Program.trumpCard.suit && pair.DefCard.suit != pair.OffCard.suit;
            return casualBeating || trumpCasualBeating;
        }

        static public void GiveCardsToPlayer (Player player, Stack<Card> pack)
        {
            while (pack.Count > 0 && player.hand.Count < 6)
                player.hand.Add(pack.Pop());
        } 

        bool[] BannedPlayers = new bool[4];

        public void BanPlayer (int numberOfPlayer)
        {
            BannedPlayers[numberOfPlayer] = true;
        }
    }
}
