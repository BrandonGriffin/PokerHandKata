using NUnit.Framework;

namespace PokerHandKata.Tests
{
    [TestFixture]
    public class HandCalculatorTests
    {
        private HandCalculator scorer;

        [SetUp]
        public void SetUp()
        {
            scorer = new HandCalculator();
        }

        [Test]
        public void HighCardShouldReturnHighCard()
        {
            var actual = scorer.ScoreHand("2S 6C 8D 7C 4H");
            Assert.That(actual, Is.EqualTo("High Card"));
        }

        [Test]
        public void OnePairShouldReturnOnePair()
        {
            var actual = scorer.ScoreHand("2S 2C 8D 7C 4H");
            Assert.That(actual, Is.EqualTo("One Pair"));
        }

        [Test]
        public void ThreeOfAKindShouldReturnThreeOfAKind()
        {
            var actual = scorer.ScoreHand("2S 2C 2D 7C 4H");
            Assert.That(actual, Is.EqualTo("Three of a Kind"));
        }

        [Test]
        public void FullHouseShouldReturnFullHouse()
        {
            var actual = scorer.ScoreHand("2S 2C 2D 4C 4H");
            Assert.That(actual, Is.EqualTo("Full House"));
        }

        [Test]
        public void FourOfAKindShouldReturnFourOfAKind()
        {
            var actual = scorer.ScoreHand("2S 2C 2D 4C 2H");
            Assert.That(actual, Is.EqualTo("Four of a Kind"));
        }

        [Test]
        public void FlushShouldReturnFlush()
        {
            var actual = scorer.ScoreHand("2S 5S 8S JS 4S");
            Assert.That(actual, Is.EqualTo("Flush"));
        }

        [Test]
        public void StraightShouldReturnStraight()
        {
            var actual = scorer.ScoreHand("2S 3H 6C 5S 4S");
            Assert.That(actual, Is.EqualTo("Straight"));
        }

        [Test]
        public void TwoPairShouldReturnTwoPair()
        {
            var actual = scorer.ScoreHand("2S 2H 5C 5S 4S");
            Assert.That(actual, Is.EqualTo("Two Pair"));
        }

        [Test]
        public void StraightFlushShouldReturnStraightFlush()
        {
            var actual = scorer.ScoreHand("2S 3S 6S 5S 4S");
            Assert.That(actual, Is.EqualTo("Straight Flush"));
        }
    }
}
