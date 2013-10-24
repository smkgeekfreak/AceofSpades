using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AceofSpades
{
    public abstract class CardCollection
    {
        protected internal List<Card> _cards { get; set; }

        public ReadOnlyCollection<Card> Cards { get { return _cards.AsReadOnly(); } }
        public virtual void Initalize() { _cards = new List<Card>(); }
        public abstract void Insert(Card insertCard);
        public abstract void Delete(Card deleteCard);
        /*
         * Promoted Discard method from Card to CardCollection as it makes
         * more sense for the CardCollection to traverse the association the 
         * Cards it contains than vice versa.  Another way to do this would
         * have been to raise an event from Card and then search the collection. 
         * Additionally the problem stated that a discard would be place into a 
         * draw pile not a discard pile which seems wrong but is supported.  
         */
        public void Discard(Card card, CardCollection cardCollection)
        {
            if (Cards.IsNullOrEmpty())
                throw new ArgumentException("No cards to discard");

            if (Cards.Contains(card))
            {
                Delete(card);
                cardCollection.Insert(card);
            }
            else
                throw new ArgumentException("Card is not in collection");
        }
    }

}