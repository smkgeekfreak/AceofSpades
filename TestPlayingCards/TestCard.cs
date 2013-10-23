using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AceofSpades;

namespace TestPlayingCards
{
    [TestClass]
    public class TestCard
    {
        Card c1 = new Card(Suit.Spades, Rank.Ace);
        Card otherCard = new Card(Suit.Hearts, Rank.Ace);
        DrawPile drawPile1 = new DrawPile();

        [TestMethod]
        public void TestDisplay()
        {
            string expected = String.Format("{0} of {1}", c1.Rank, c1.Suit);
            Console.Out.WriteLine(c1.Display());
            Assert.AreEqual(expected, c1.Display());
        }

        [TestMethod]
        public void TestCompareSameRankDiffSuit()
        {
            c1.Suit = Suit.Spades;
            otherCard.Suit = Suit.Diamonds;
            c1.Rank = Rank.King;
            otherCard.Rank = Rank.King;
            Console.Out.WriteLine(c1.Display());
            Console.Out.WriteLine(otherCard.Display());
            Assert.AreEqual(1, c1.Compare(otherCard));
        }

        [TestMethod]
        public void TestCompareSameSuitDiffRankFirstHigh()
        {
            c1.Suit = Suit.Spades;
            otherCard.Suit = Suit.Spades;
            c1.Rank = Rank.Eight;
            otherCard.Rank = Rank.Four;
            Console.Out.WriteLine(c1.Display());
            Console.Out.WriteLine(otherCard.Display());
            Assert.AreEqual(1, c1.Compare(otherCard));
        }
        [TestMethod]
        public void TestCompareSameSuitDiffRankFirstLow()
        {
            c1.Suit = Suit.Spades;
            otherCard.Suit = Suit.Spades;
            c1.Rank = Rank.Three;
            otherCard.Rank = Rank.Jack;
            Console.Out.WriteLine(c1.Display());
            Console.Out.WriteLine(otherCard.Display());
            Assert.AreEqual(-1, c1.Compare(otherCard));
        }
        [TestMethod]
        public void TestCompareDiffSuitDiffRankFirstHigh()
        {
            c1.Suit = Suit.Clubs;
            otherCard.Suit = Suit.Spades;
            c1.Rank = Rank.Eight;
            otherCard.Rank = Rank.Four;
            Console.Out.WriteLine(c1.Display());
            Console.Out.WriteLine(otherCard.Display());
            Assert.AreEqual(1, c1.Compare(otherCard));
        }
        [TestMethod]
        public void TestCompareSameDiffDiffRankFirstLow()
        {
            c1.Suit = Suit.Hearts;
            otherCard.Suit = Suit.Diamonds;
            c1.Rank = Rank.Three;
            otherCard.Rank = Rank.Jack;
            Console.Out.WriteLine(c1.Display());
            Console.Out.WriteLine(otherCard.Display());
            Assert.AreEqual(-1, c1.Compare(otherCard));
        }


        #region Private Helpers
        #endregion

    }
}
