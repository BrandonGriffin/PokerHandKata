using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerHandKata
{
    public class HandCalculator
    {
        private Converter converter;
        private IEnumerable<Card> hand;
        private IEnumerable<IGrouping<Int32, Card>> valueGroups;

        public HandCalculator(Converter converter)
        {
            this.converter = converter;
        }

        public String ScoreHand(String cardString)
        {
            this.hand = converter.ConvertStringToHand(cardString);
            valueGroups = GetValueGroups();

            var isStraight = IsStraight();
            var isFlush = IsFlush();

            if (isStraight && isFlush)
                return "Straight Flush";
            if (HasFourOfAKind())
                return "Four of a Kind";
            if (HasFullHouse())
                return "Full House";
            if (isFlush)
                return "Flush";
            if (isStraight)
                return "Straight";
            if (HasThreeOfAKind())
                return "Three of a Kind";
            if (HasTwoPair())
                return "Two Pair";
            if (HasPair())
                return "One Pair";

            return "High Card";
        }
        
        private IEnumerable<IGrouping<Int32, Card>> GetValueGroups()
        {
            return hand.GroupBy(c => c.Value);
        }
        
        private Boolean IsStraight()
        {
            if (hand.Max(c => c.Value) - hand.Min(c => c.Value) == 4 && valueGroups.Count() == 5)
                return true;

            if (IsAceLowStraight())
                return true;

            return false;
        }

        private Boolean IsAceLowStraight()
        {
            return valueGroups.Count() == 5 && hand.Min(c => c.Value) == 2 && hand.Sum(c => c.Value) == 28;
        }

        private Boolean IsFlush()
        {
            return hand.GroupBy(c => c.Suit).Count() == 1;
        }

        private Boolean HasFourOfAKind()
        {
            return valueGroups.Any(g => g.Count() > 3);
        }

        private Boolean HasFullHouse()
        {
            return valueGroups.Count() == 2;
        }

        private Boolean HasThreeOfAKind()
        {
            return valueGroups.Any(g => g.Count() > 2);
        }

        private Boolean HasTwoPair()
        {
            return valueGroups.Count() == 3;
        }
        
        private Boolean HasPair()
        {
            return valueGroups.Any(g => g.Count() > 1);
        }
    }
}
