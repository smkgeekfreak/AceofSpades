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
        public void TestInitialize()
        {
            Assert.AreEqual(52, deck1.Cards.Count, "Not enough cards added to deck");
            TestHelper.DisplayCollection(deck1);
        }

        [TestMethod]
        public void TestShuffle()
        {
            Card[] one, two, three, four;
            TestInitialize();
            one = deck1.Cards.ToArray();
            deck1.Shuffle();
            TestHelper.DisplayCollection(deck1);
            two = deck1.Cards.ToArray();
            TestSimiliarity(one, two);
            deck1.Shuffle();
            TestHelper.DisplayCollection(deck1);
            three = deck1.Cards.ToArray();
            TestSimiliarity(two,three);
            deck1.Shuffle();
            TestHelper.DisplayCollection(deck1);
            four = deck1.Cards.ToArray();
            TestSimiliarity(three,four);

        }


        private void TestSimiliarity(Card[] one, Card[] two)
        {
            int similarityTolerance = 0;
            for (int i = 0; i < deck1.Cards.Count; i++)
            {
                if (one[i] == two[1])
                {
                    similarityTolerance++;
                    Console.Out.WriteLine("Similiarity at index = " + i);
                    Console.Out.WriteLine(one[i].Display());
                }

            }
            Console.Out.WriteLine("Similiarity = " + similarityTolerance);
            Console.Out.WriteLine();
            Assert.IsTrue((similarityTolerance < 5), "Shuffle didn't work");
        }


        [TestMethod]
        public void TestDeal()
        {
            TestInitialize();
            List<Hand> hands = deck1.Deal(4, 5);
            foreach (Hand hand in hands)
                TestHelper.DisplayCollection(hand);
        }
        
    }
}
