using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerHandKata
{
    public class HandCalculator
    {
        private List<Card> hand;

        public String ScoreHand(String cardString)
        {
            ConvertStringToHand(cardString);

            if (IsStraight() && IsFlush())
                return "Straight Flush";
            if (IsStraight())
                return "Straight";
            if (IsFlush())
                return "Flush";
            if (HasFourOfAKind())
                return "Four of a Kind";
            if (HasFullHouse())
                return "Full House";
            if (HasThreeOfAKind())
                return "Three of a Kind";
            if (HasTwoPair())
                return "Two Pair";
            if (HasPair())
                return "One Pair";

            return "High Card";
        }
        
        private void ConvertStringToHand(String cardString)
        {
            var splitCards = cardString.Split(' ');
            hand = new List<Card>();

            foreach (var value in splitCards)
            {
                var card = new Card(value);
                hand.Add(card);
            }
        }

        private Boolean IsStraight()
        {
            return hand.Max(h => h.Value) - hand.Min(h => h.Value) == 4 && hand.GroupBy(h => h.Value).Count() == 5;
        }

        private Boolean IsFlush()
        {
            return hand.GroupBy(h => h.Suit).Count() == 1;
        }

        private Boolean HasFourOfAKind()
        {
            return hand.GroupBy(h => h.Value).Any(g => g.Count() > 3);
        }

        private Boolean HasFullHouse()
        {
            return hand.GroupBy(h => h.Value).Count() == 2;
        }

        private Boolean HasThreeOfAKind()
        {
            return hand.GroupBy(h => h.Value).Any(g => g.Count() > 2);
        }

        private Boolean HasTwoPair()
        {
            return hand.GroupBy(h => h.Value).Count() == 3;
        }
        
        private Boolean HasPair()
        {
            return hand.GroupBy(h => h.Value).Any(g => g.Count() > 1);
        }
    }
}
