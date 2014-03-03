using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FoolsGame
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var hand = new List<Card>(){new Card(Suit.Clubs, Nominal.Ten)};
            var attack = new Card(Suit.Clubs, Nominal.Eight);
            var defense = new Card(Suit.Clubs, Nominal.Ten);
            var desirableTable = new Table();
            desirableTable.AddOffCard(attack);
            desirableTable.AddDefCard(defense,0);
            Assert.AreEqual(Arbiter.TryToMove(hand, desirableTable, desirableTable, 1), true);
        }
    }
}
