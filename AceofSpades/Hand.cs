using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AceofSpades
{
    public class Hand : CardCollection
    {
        public int InitialSize { get; set; }

        public override void Insert(Card insertCard)
        {
            if (Cards == null)
                throw new ArgumentNullException("Cards cannot be null");

            if (Cards.Contains(insertCard))
                throw new ArgumentException("Hand contains duplicate card");
            if (Cards.Count == InitialSize)
                throw new ArgumentException("Hand is full");
            else
            {
                _cards.Add(insertCard);
            }
        }

        public override void Delete(Card deleteCard)
        {
            if (Cards.IsNullOrEmpty())
                throw new ArgumentException("No cards in hand to discard");

            if (Cards.Contains(deleteCard))
            {
                _cards.Remove(deleteCard);
            }
            else
                throw new ArgumentException("Card is not in hand");
        }

        public void Sort()
        {
            _cards.Sort();
        }        

        public override void Initalize()
        {
            // bypass initalize resetting the size
        }

        public Hand(int size)
        {
            InitialSize = size;
            _cards = new List<Card>(size);
        }

    }
}
