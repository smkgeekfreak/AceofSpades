using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AceofSpades;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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
            hand1.Insert(new Card(Suit.Spades, Rank.Five));
            hand1.Insert(new Card(Suit.Clubs, Rank.Two));
            hand1.Insert(new Card(Suit.Diamonds, Rank.Four));
            hand1.Insert(new Card(Suit.Spades, Rank.Ace));
            hand1.Insert(new Card(Suit.Diamonds, Rank.Ten));
        }
        [TestCleanup]
        public void CleanupHandTests()
        {
            hand1 = null;
        }

        [TestMethod]
        public void TestHandInsert()
        {
            hand1 = new Hand(10);
            Card newCard1 = new Card(Suit.Hearts, Rank.Seven);
            Assert.IsNotNull(hand1.Cards);
            Assert.IsFalse(hand1.Cards.Contains(newCard1));
            TestHelper.DisplayCollection("Hand Before Insert",hand1);
            hand1.Insert(newCard1);
            TestHelper.DisplayCollection("Hand After Insert",hand1);
            Assert.IsTrue(hand1.Cards.Contains(newCard1));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestHandInsertFull()
        {
            Assert.IsNotNull(hand1.Cards);
            Assert.IsTrue(hand1.Cards.Count==5);
            Card newCard1 = new Card(Suit.Hearts, Rank.Seven);
            Assert.IsFalse(hand1.Cards.Contains(newCard1));
            TestHelper.DisplayCollection("Hand Before Insert",hand1);
            hand1.Insert(newCard1);
        }
        [TestMethod]
        public void TestHandDelete()
        {
            Assert.IsNotNull(hand1.Cards);
            Card remCard1 = hand1.Cards[hand1.Cards.Count-1]; 
            Assert.IsTrue(hand1.Cards.Contains(remCard1));
            TestHelper.DisplayCollection("Hand Before Delete", hand1);
            hand1.Delete(remCard1);
            TestHelper.DisplayCollection("Hand After Delete", hand1);
            Assert.IsFalse(hand1.Cards.Contains(remCard1));
        }

        [TestMethod]
        public void TestHandSort()
        {
            TestHelper.DisplayCollection("Hand Before Sort",hand1);
            hand1.Sort();
            TestHelper.DisplayCollection("Hand After Sort",hand1);
            for(int c = 0; c < hand1.Cards.Count; c++)
            {
                Card card = hand1.Cards[c];
                for(int oc = c+1 ; oc < hand1.Cards.Count; oc++)
                {
                    Card otherCard = hand1.Cards[oc];
                    Assert.IsTrue(otherCard.CompareTo(card)==1, "Not Sorted");
                }
            }
        }

        [TestMethod]
        public void TestHandSort52()
        {
            Deck deck1 = new Deck();
            deck1.Initalize();
            deck1.Shuffle();
            List<Hand> sortHands = deck1.Deal(1,52);
            TestHelper.DisplayCollection("Hand Before Sort",sortHands[0]);
            sortHands[0].Sort();
            TestHelper.DisplayCollection("Hand After Sort",sortHands[0]);
            for (int c = 0; c < sortHands[0].Cards.Count; c++)
            {
                Card card = sortHands[0].Cards[c];
                for (int oc = c + 1; oc < sortHands[0].Cards.Count; oc++)
                {
                    Card otherCard = sortHands[0].Cards[oc];
                    Assert.IsTrue(otherCard.CompareTo(card) == 1, "Not Sorted");
                }
            }
        }

        [TestMethod]
        public void TestHandDiscard()
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
        
        [TestMethod]
        public void TestHandDiscardAll()
        {
            DrawPile drawPile1 = new DrawPile();
            drawPile1.Initalize();
            Card[] discards = new Card[hand1.Cards.Count];
            hand1.Cards.CopyTo(discards, 0);
            foreach (Card discardCard in discards)
            {
                TestHelper.DisplayCollection("Hand before discard", hand1);
                TestHelper.DisplayCard("Discarding ", discardCard);
                hand1.Discard(discardCard, drawPile1);
                TestHelper.DisplayCollection("Draw Pile", drawPile1);
                TestHelper.DisplayCollection("Hand after discard", hand1);
            }
            Assert.IsTrue(hand1.Cards.Count == 0, "All cards not discarded");
        }
    }

}
