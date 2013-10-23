using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceofSpades
{
    public class Card : IComparable, IEquatable<Card>
    {
        public Suit Suit { get; set; }

        public Rank Rank { get; set; }

        public Card()
        { // Blank card
        }
        public Card(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }
        public string Display()

        {
            return String.Format("{0} of {1}", Rank, Suit);
        }

        public int Compare(Card otherCard)
        {
            /*
             * Return 1 if this Card is greater
             * Return-1 if otherCard is greater
             * Return 0 if equal
             */
            if (this == otherCard)
                return 0;

            if (this.Rank > otherCard.Rank)
                return 1;
            else if (this.Rank < otherCard.Rank)
                return -1;
            else if (this.Suit > otherCard.Suit) // this.Rank == otherCard.Rank
                return 1;
            else // this.Suit < otherCad.Suit
                return -1;
        }

        public override bool Equals(object obj)
        {
            Card other = obj as Card;
            if (other == null)
                return false;

            if (this.Suit == other.Suit &&
                this.Rank == other.Rank)
                return true;
            return false;
        }

        public int CompareTo(object obj)
        {
            Card otherCard = obj as Card;
            return this.Compare(otherCard);
        }
        public override string ToString()
        {
            return this.Display();
        }

        public bool Equals(Card other)
        {
            throw new NotImplementedException();
        }
    }
}
