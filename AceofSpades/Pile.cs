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
            throw new NotImplementedException();
        }

        public override void Delete(Card deleteCard)
        {
            throw new NotImplementedException();
        }

        public void Draw(Hand hand1)
        {
            throw new NotImplementedException();
        }

        public Card TopOfPile()
        {
            if (Cards == null || Cards.Count < 1)
                throw new ArgumentNullException("Cards may not be null");
            return Cards[0];
            
        }

        public Card BottomOfPile()
        {
            if (Cards == null || Cards.Count < 1)
                throw new ArgumentNullException("Cards may not be null");
            return Cards[Cards.Count-1];
        }
    }
}
