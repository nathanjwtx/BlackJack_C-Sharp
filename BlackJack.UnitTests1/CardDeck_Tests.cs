using System;
using NUnit.Framework;

namespace BlackJack.UnitTests1
{
    [TestFixture]
    public class CardDeckTests 
    {
        [Test]
        public void CardDeck_FullDeck_Returns52Cards()
        {
            var deck = new CardDeck();

            var result = deck.TestCardsLeft();
            
            Assert.That(result, Is.EqualTo(52));
        }
    }
}