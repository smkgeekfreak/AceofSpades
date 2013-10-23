using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AceofSpades
{
    public abstract class CardCollection
    {
        public List<Card> Cards { get; set; }
        public virtual void Initalize() { Cards = new List<Card>(); }
        public abstract void Insert(Card insertCard);
        public abstract void Delete(Card deleteCard);
        public void Discard(Card card, DrawPile pile1)
        {
            if (!Cards.Any())
                throw new ArgumentException("No cards to discard");
            
            if (Cards.Exists(eCard => eCard.Rank == card.Rank))
            {
                Delete(card);
                pile1.Cards.Add(card);
            }
            else
                throw new ArgumentException("Card is not in collection");
        }
    }
}
