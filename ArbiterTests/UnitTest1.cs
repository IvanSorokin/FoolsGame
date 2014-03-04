using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FoolsGame
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void RightDefense()
        {
            var hand = new List<Card>(){new Card(Suit.Clubs, Nominal.Ten)};
            var attack = new Card(Suit.Clubs, Nominal.Eight);
            var defense = new Card(Suit.Clubs, Nominal.Ten);
            var desirableTable = new Table();
            Program.trumpCard = new Card(Suit.Diamonds, Nominal.Ace);
            desirableTable.AddOffCard(attack);
            desirableTable.AddDefCard(defense,0);
            Assert.AreEqual(Arbiter.TryToDefense(hand, desirableTable, desirableTable), true);
        }

        [TestMethod]
        public void WrongDefense()
        {
            Program.trumpCard = new Card(Suit.Diamonds, Nominal.Ace);
            var hand = new List<Card>() { new Card(Suit.Clubs, Nominal.Ten) };
            var attack = new Card(Suit.Clubs, Nominal.Eight);
            var defense = new Card(Suit.Clubs, Nominal.Ten);
            var desirableTable = new Table();
            desirableTable.AddOffCard(defense);
            desirableTable.AddDefCard(attack, 0);
            Assert.AreEqual(Arbiter.TryToDefense(hand, desirableTable, desirableTable), false);
        }

        [TestMethod]
        public void RightAttack()
        {
            Program.trumpCard = new Card(Suit.Diamonds, Nominal.Ace);
            var hand = new List<Card>() { new Card(Suit.Clubs, Nominal.Eight) };
            var attack = new Card(Suit.Clubs, Nominal.Eight);
            var desirableTable = new Table();
            desirableTable.AddOffCard(attack);
            Assert.AreEqual(Arbiter.TryToAttack(hand, desirableTable,1), true);
        }

        [TestMethod]
        public void WrongAttack()
        {
            Program.trumpCard = new Card(Suit.Diamonds, Nominal.Ace);
            var hand = new List<Card>() { new Card(Suit.Diamonds, Nominal.Eight) };
            var attack = new Card(Suit.Clubs, Nominal.Eight);
            var desirableTable = new Table();
            desirableTable.AddOffCard(attack);
            Assert.AreEqual(Arbiter.TryToAttack(hand, desirableTable, 1), false);
        }

        [TestMethod]
        public void RightTrumpDefense()
        {
            Program.trumpCard = new Card(Suit.Diamonds, Nominal.Ace);
            var hand = new List<Card>() { new Card(Suit.Diamonds, Nominal.Eight) };
            var attack = new Card(Suit.Clubs, Nominal.Eight);
            var defense = new Card(Suit.Diamonds, Nominal.Eight);
            var desirableTable = new Table();
            desirableTable.AddOffCard(attack);
            desirableTable.AddDefCard(defense,0);
            Assert.AreEqual(Arbiter.TryToDefense(hand, desirableTable, desirableTable), true);
        }

        [TestMethod]
        public void TakeCards()
        {
            Program.trumpCard = new Card(Suit.Diamonds, Nominal.Ace);
            var hand = new List<Card>() { new Card(Suit.Diamonds, Nominal.Eight) };
            var attack = new Card(Suit.Clubs, Nominal.Eight);
            var prevTable = new Table();
            var desTable = new Table();
            prevTable.AddOffCard(attack);
            Assert.AreEqual(Arbiter.TryToDefense(hand, prevTable, desTable), true);
        }
    }
}
