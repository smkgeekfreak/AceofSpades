using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AceofSpades;

namespace TestPlayingCards
{
    [TestClass]
    public class TestHand
    {

        Hand hand1;
        [TestInitialize]
        public void InitializeHandTests()
        {
            hand1 = new Hand(5);
            hand1.Initalize();
            hand1.Cards.Add(new Card(Suit.Spades, Rank.Five));
            hand1.Cards.Add(new Card(Suit.Clubs, Rank.Two));
            hand1.Cards.Add(new Card(Suit.Diamonds, Rank.Four));
            hand1.Cards.Add(new Card(Suit.Spades, Rank.Ace));
            hand1.Cards.Add(new Card(Suit.Diamonds, Rank.Ten));
        }
        [TestCleanup]
        public void CleanupHandTests()
        {
            hand1 = null;
        }

        [TestMethod]
        public void TestInsert()
        {
        }
        [TestMethod]
        public void TestDelete()
        {
        }

        [TestMethod]
        public void TestSort()
        {
            TestHelper.DisplayCollection("Hand Before Sort",hand1);
            hand1.Sort();
            TestHelper.DisplayCollection("Hand After Sort",hand1);
        }

        [TestMethod]
        public void TestDiscard()
        {
            DrawPile drawPile1 = new DrawPile();
            drawPile1.Initalize();
            Card discardCard = new Card(Suit.Diamonds, Rank.Four);
            TestHelper.DisplayCollection("Hand before discard", hand1);
            TestHelper.DisplayCard("Discarding ",discardCard);
            hand1.Discard(discardCard, drawPile1);
            TestHelper.DisplayCollection("Draw Pile", drawPile1);
            TestHelper.DisplayCollection("Hand after discard", hand1);
        }
    }

}
