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
            throw new NotImplementedException();
        }

        public override void Delete(Card deleteCard)
        {
            throw new NotImplementedException();
        }

        public Hand(int size)
        {
            InitialSize = size;
            Cards = new List<Card>(size);
        }
        public void Sort()
        {
            Cards.Sort();
        }

    }
}
