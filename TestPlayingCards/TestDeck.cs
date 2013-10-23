using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AceofSpades;

namespace TestPlayingCards
{
    [TestClass]
    public class TestDeck
    {
        Deck deck1 = new Deck();

        [TestInitialize]
        public void InitializeDeckTests()
        {
            deck1.Initalize();
        }
        [TestCleanup]
        public void CleanupDeckTests()
        {
            deck1 = null;
        }

        [TestMethod]
        public void TestDeckInitialize()
        {
            Assert.AreEqual(52, deck1.Cards.Count, "Not enough cards added to deck");
            TestHelper.DisplayCollection("Deck Initialized", deck1);
        }

        [TestMethod]
        public void TestDeckShuffle()
        {
            TestDeckInitialize();
            Card[] one = new Card[52], 
                two = new Card[52], 
                three = new Card[52], 
                four = new Card[52];

            deck1.Cards.CopyTo(one, 0) ;
            deck1.Shuffle();
            TestHelper.DisplayCollection(deck1);
            deck1.Cards.CopyTo(two, 0) ;
            TestSimiliarity(one, two, 5);
            deck1.Shuffle();
            TestHelper.DisplayCollection(deck1);
            deck1.Cards.CopyTo(three, 0) ;
            TestSimiliarity(two,three, 5);
            deck1.Shuffle();
            TestHelper.DisplayCollection(deck1);
            deck1.Cards.CopyTo(four, 0) ;
            TestSimiliarity(three,four, 5);

        }

        [TestMethod]
        public void TestDeckDeal()
        {
            TestDeckInitialize();
            List<Hand> hands = deck1.Deal(4, 5);
            foreach (Hand hand in hands)
            {
                TestHelper.DisplayCollection("Hand", hand);
                Card[] thisHand = new Card[hand.Cards.Count];
                hand.Cards.CopyTo(thisHand, 0);
                foreach( Hand otherHand in hands.FindAll(predHand=>predHand != hand))
                {
                    TestHelper.DisplayCollection("Other Hand", hand);
                    Card[] thatHand = new Card[otherHand.Cards.Count];
                    otherHand.Cards.CopyTo(thatHand, 0);
                    TestSimiliarity(thisHand, thatHand, 0);
                }
            }
        }
        [TestMethod]
        public void TestDeckDiscard()
        {
            TestDeckInitialize();
            DrawPile dp1 = new DrawPile();
            dp1.Initalize();
            Card disCard = deck1.TopOfPile();
            TestHelper.DisplayCard("Top of Pile", deck1.TopOfPile());
            deck1.Discard(deck1.TopOfPile(), dp1);
            TestHelper.DisplayCollection("After discard", deck1);
            TestHelper.DisplayCollection("Draw Pile", dp1);
            Assert.IsFalse(deck1.Cards.Contains(disCard));
        }
        #region Private Helpers
        private void TestSimiliarity(Card[] one, Card[] two, int toleranceLevel)
        {
            int similarityTolerance = 0;
            for (int i = 0; i < one.Length; i++)
            {
                if (one[i] == two[i])
                {
                    similarityTolerance++;
                    Console.Out.WriteLine("Similiarity at index = " + i);
                    Console.Out.WriteLine(one[i].Display());
                }

            }
            Console.Out.WriteLine("Similiarity = " + similarityTolerance);
            Console.Out.WriteLine();
            Assert.IsTrue((similarityTolerance <= toleranceLevel), "Shuffle didn't work");
        }
        #endregion

    }
}
