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

    public static class MyExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable == null)
                return true;

            return !enumerable.Any();
        }

        public static IEnumerable<T> FindAllAfter<T>(this IEnumerable<T> enumerable, Func<T,bool> match)
        {
            if (enumerable == null)
                return null;

            return enumerable.Where(match);
        }
    }
}