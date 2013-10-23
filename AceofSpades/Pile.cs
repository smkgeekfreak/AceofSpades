using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AceofSpades
{
    public abstract class Pile : CardCollection
    {

        public override void Insert(Card insertCard)
        {
            if (Cards == null)
                throw new ArgumentNullException("Cards cannot be null");

            if (Cards.Contains(insertCard))
                throw new ArgumentException("Pile contains duplicate card");
            else
            {
                _cards.Add(insertCard);
            }
        }

        public override void Delete(Card deleteCard)
        {
            if (Cards.IsNullOrEmpty())
                throw new ArgumentException("No cards to discard");

            if (TopOfPile() == deleteCard)
            {
                _cards.Remove(deleteCard);
            }
            else
                throw new ArgumentException("Card is not on the top");
        }

        public void Draw(Hand hand)
        {
            if (hand == null)
                throw new ArgumentNullException("Hand cannot be null");

            Card drawCard = TopOfPile();
            Delete(TopOfPile());
            hand.Insert(drawCard);
        }

        public Card TopOfPile()
        {
            if (Cards.IsNullOrEmpty())
                throw new ArgumentNullException("Cards may not be null");
            return Cards[0];
            
        }

        public Card BottomOfPile()
        {
            if (Cards.IsNullOrEmpty())
                throw new ArgumentNullException("Cards may not be null");
            return Cards[Cards.Count-1];
        }
    }
}
