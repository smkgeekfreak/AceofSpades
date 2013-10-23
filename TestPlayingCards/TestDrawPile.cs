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
            pile1.Cards.Add(new Card(Suit.Spades, Rank.Five));
            pile1.Cards.Add(new Card(Suit.Clubs, Rank.Two));
            pile1.Cards.Add(new Card(Suit.Diamonds, Rank.Four));
            pile1.Cards.Add(new Card(Suit.Spades, Rank.Ace));
            pile1.Cards.Add(new Card(Suit.Diamonds, Rank.Ten));
        }
        [TestCleanup]
        public void CleanupPileTests()
        {
            pile1 = null;
        }
        [TestMethod]
        public void TestTopOfPile()
        {
            InitializePileTests();
            TestHelper.DisplayCollection(pile1);
            Card topCard = pile1.TopOfPile();
            TestHelper.DisplayCard("Top Card is ", topCard);
        }
        [TestMethod]
        public void TestBottomOfPile()
        {
            InitializePileTests();
            TestHelper.DisplayCollection(pile1);
            Card bottomCard = pile1.BottomOfPile();
            TestHelper.DisplayCard("Bottom Card is ", bottomCard);
        }
        public void TestInsert()
        {
            pile1.Insert(insertCard1);
        }
        public void TestDelete()
        {
            pile1.Delete(insertCard1);
        }
        public void TestDraw()
        {
            pile1.Draw(hand1);
        }
    }
}
