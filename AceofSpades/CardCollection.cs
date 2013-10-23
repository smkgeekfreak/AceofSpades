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
        public void Discard(Card card, DrawPile pile1)
        {
            if (Cards.IsNullOrEmpty())
                throw new ArgumentException("No cards to discard");

            if (Cards.Contains(card)) 
            {
                Delete(card);
                pile1.Insert(card);
            }
            else
                throw new ArgumentException("Card is not in collection");
        }
    }

    static class MyExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable == null)
                return true;

            return !enumerable.Any();
        }
    }
}
