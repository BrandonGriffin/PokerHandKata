using System;
using System.Collections.Generic;

namespace PokerHandKata
{
    class Card
    {
        public Int32 Value { get; private set; }
        public Char Suit { get; private set; }

        private String card;
        private Dictionary<Char, Int32> valueConverter;

        public Card(String card)
        {
            this.card = card;
            valueConverter = new Dictionary<Char, Int32>
            {
                { '2', 2 },
                { '3', 3 },
                { '4', 4 },
                { '5', 5 },
                { '6', 6 },
                { '7', 7 },
                { '8', 8 },
                { '9', 9 },
                { 'T', 10 },
                { 'J', 11 },
                { 'Q', 12 },
                { 'K', 13 },
                { 'A', 14 }
            };

            Value = valueConverter[card[0]];
            Suit = card[1];
        }
    }
}
