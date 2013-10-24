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
        public void TestCardDisplay()
        {
            string expected = String.Format("{0} of {1}", c1.Rank, c1.Suit);
            Console.Out.WriteLine(c1.Display());
            Assert.AreEqual(expected, c1.Display());
        }

        [TestMethod]
        public void TestCardCompareSameRankDiffSuit()
        {
            c1 = new Card(Suit.Spades, Rank.King);
            otherCard = new Card(Suit.Diamonds, Rank.King);
            Console.Out.WriteLine(c1.Display());
            Console.Out.WriteLine(otherCard.Display());
            Assert.AreEqual(1, c1.Compare(otherCard));
        }

        [TestMethod]
        public void TestCardCompareSameSuitDiffRankFirstHigh()
        {
            c1 = new Card(Suit.Spades, Rank.Eight);
            otherCard = new Card(Suit.Spades, Rank.Four);
            Console.Out.WriteLine(c1.Display());
            Console.Out.WriteLine(otherCard.Display());
            Assert.AreEqual(1, c1.Compare(otherCard));
        }
        [TestMethod]
        public void TestCardCompareSameSuitDiffRankFirstLow()
        {
            c1 = new Card(Suit.Spades, Rank.Three);
            otherCard = new Card(Suit.Spades, Rank.Four);
            Console.Out.WriteLine(c1.Display());
            Console.Out.WriteLine(otherCard.Display());
            Assert.AreEqual(-1, c1.Compare(otherCard));
        }
        [TestMethod]
        public void TestCardCompareDiffSuitDiffRankFirstHigh()
        {
            c1 = new Card(Suit.Spades, Rank.Four);
            otherCard = new Card(Suit.Clubs, Rank.Eight);
            Console.Out.WriteLine(c1.Display());
            Console.Out.WriteLine(otherCard.Display());
            Assert.AreEqual(1, c1.Compare(otherCard));
        }
        [TestMethod]
        public void TestCardCompareDiffSuitDiffRankFirstLow()
        {
            c1 = new Card(Suit.Diamonds, Rank.Three);
            otherCard = new Card(Suit.Hearts, Rank.Jack);
            Console.Out.WriteLine(c1.Display());
            Console.Out.WriteLine(otherCard.Display());
            Assert.AreEqual(-1, c1.Compare(otherCard));
        }


        #region Private Helpers
        #endregion

    }
}
