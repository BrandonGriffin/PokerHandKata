using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerHandKata
{
    public class Converter
    {
        public IEnumerable<Card> ConvertStringToHand(String cardString)
        {
            var splitCards = cardString.Split(' ');
            var hand = new List<Card>();

            foreach (var card in splitCards)
                hand.Add(new Card(card));

            hand.OrderBy(h => h.Value);

            return hand;
        }
    }
}
