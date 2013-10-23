using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AceofSpades
{
    public class Deck : Pile
    {
        public override void Initalize()
        {
            _cards = new List<Card>(52);
            //Loop through the set of Suit and add a card for each rank for every suit
            var suits= Enum.GetValues(typeof(Suit)).Cast<Suit>();
            var ranks= Enum.GetValues(typeof(Rank)).Cast<Rank>();
            foreach (Suit s in suits)
            {
                foreach (Rank r in ranks)
                {
                    _cards.Add(new Card(s, r));
                }
            }
        }

        public List<Hand> Deal(int numberOfHands, int cardsPerHand)
        {
            if (Cards == null)
                throw new NullReferenceException("Cards must not be null");

            /*
             * Check the total number of cards to be dealt exist in the deck
             */
            if (Cards.Count < (cardsPerHand * numberOfHands))
                throw new ArgumentException("Asked to deal more cards that exist in the deck");
            /*
             * Create hands
             */
            List<Hand> hands = new List<Hand>(numberOfHands);
            for (int h = 0; h < numberOfHands; h++)
            {
                hands.Add(new Hand(cardsPerHand));
            }
            /*
             * Deal a number of cards request to each hand
             */ 
            for (int round = 0; round < cardsPerHand; round++)
            {
                /*
                 * Iterate over each hand
                 */
                foreach (Hand hand in hands)
                {
                    hand.Insert(this.TopOfPile());
                    this.Delete(this.TopOfPile());
                }
            }
            return hands;
                    
        }

        public void Shuffle()
        {
            int loopCounter = Cards.Count;
            Random rdm = new Random();
            while (loopCounter > 1)
            {
                loopCounter--;
                int index = rdm.Next(loopCounter + 1);
                Card moveCard = Cards[index];
                _cards[index] = Cards[loopCounter];
                _cards[loopCounter] = moveCard;
            }
        }

    }

    public static class MyThreadSafeRandom
    {
        [ThreadStatic]
        private static Random Local;

        public static Random ThisThreadsRandom
        {
            get { return Local ?? (Local = new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId))); }
        }
    }

    //static class MyExtensions
    //{
    //    public static void Shuffle<T>(this IList<T> list)
    //    {
    //        int n = list.Count;
    //        while (n > 1)
    //        {
    //            n--;
    //            int k = ThreadSafeRandom.ThisThreadsRandom.Next(n + 1);
    //            T value = list[k];
    //            list[k] = list[n];
    //            list[n] = value;
    //        }
    //    }
    //}

}
