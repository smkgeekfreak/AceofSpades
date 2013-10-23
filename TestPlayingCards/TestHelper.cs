using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AceofSpades;

namespace TestPlayingCards
{
    static internal class TestHelper
    {
        static public void DisplayCollection(CardCollection collection)
        {
            Console.Out.WriteLine("-----------------");
            foreach (Card card in collection.Cards)
                Console.Out.WriteLine(card.Display());
            Console.Out.WriteLine("-----------------");
        }
        static public void DisplayCollection(String header, CardCollection collection)
        {
            Console.Out.WriteLine(header);
            DisplayCollection(collection);
        }
        static public void DisplayCard(String prefix, Card card)
        {
            Console.Out.WriteLine(prefix + ":" + card.Display());
            Console.Out.WriteLine("-----------------");
        }
    }
}
