using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AceofSpades;

namespace TestPlayingCards
{
    [TestClass]
    public class TestDrawPile
    {
        Pile pile1 = new DrawPile();
        Card insertCard1 = new Card();
        Hand hand1 = new Hand(5);

        //[ClassInitialize]

        [TestInitialize]
        public void InitializePileTests()
        {
            pile1 = new DrawPile();
            pile1.Initalize();
            pile1.Insert(new Card(Suit.Spades, Rank.Five));
            pile1.Insert(new Card(Suit.Clubs, Rank.Two));
            pile1.Insert(new Card(Suit.Diamonds, Rank.Four));
            pile1.Insert(new Card(Suit.Spades, Rank.Ace));
            pile1.Insert(new Card(Suit.Diamonds, Rank.Ten));
        }
        [TestCleanup]
        public void CleanupPileTests()
        {
            pile1 = null;
        }
        [TestMethod]
        public void TestDrawPileTopOfPile()
        {
            TestHelper.DisplayCollection(pile1);
            Card topCard = pile1.TopOfPile();
            TestHelper.DisplayCard("Top Card is ", topCard);
        }
        [TestMethod]
        public void TestDrawPileBottomOfPile()
        {
            TestHelper.DisplayCollection(pile1);
            Card bottomCard = pile1.BottomOfPile();
            TestHelper.DisplayCard("Bottom Card is ", bottomCard);
        }
        [TestMethod]
        public void TestDrawPileInsert()
        {
            Card newCard1 = new Card(Suit.Hearts, Rank.Seven);
            Assert.IsNotNull(pile1.Cards);
            Assert.IsFalse(pile1.Cards.Contains(newCard1));
            TestHelper.DisplayCollection("Pile Before Insert", pile1);
            pile1.Insert(newCard1);
            TestHelper.DisplayCollection("Pile After Insert", pile1);
            Assert.IsTrue(pile1.Cards.Contains(newCard1));
        }
        [TestMethod]
        public void TestDrawPileDeleteTopOfPile()
        {
            //Only allows TopOfPile to be deleted
            Card topCard = pile1.TopOfPile();
            TestHelper.DisplayCollection("Draw Pile before delete", pile1);
            TestHelper.DisplayCard("Card is ", topCard);
            pile1.Delete(topCard);
            TestHelper.DisplayCollection("Draw Pile after delete", pile1);
            Assert.IsFalse(pile1.Cards.Contains(topCard), "Card not deleted");

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDrawPileDeleteNotTopOfPile()
        {
            //Only allows TopOfPile to be deleted
            Card notTopCard = pile1.Cards[pile1.Cards.Count - 1];
            TestHelper.DisplayCollection("Draw Pile before delete", pile1);
            TestHelper.DisplayCard("Card is ", notTopCard);
            pile1.Delete(notTopCard);
            TestHelper.DisplayCollection("Draw Pile after delete", pile1);
        }

        [TestMethod]
        public void TestDrawPileDraw()
        {
            pile1.Draw(hand1);
        }
    }
}
