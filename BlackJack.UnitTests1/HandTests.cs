using System.ComponentModel;
using NUnit.Framework;

namespace BlackJack.UnitTests1
{
    [TestFixture]
    public class HandTests
    {
        [Test]
        public void Deal_AddACard_HandValueGreaterThan1()
        {
            var deck = new CardDeck();
            var hand = new Hand(deck);
            hand.Deal();
            hand.SetHandValue();

            var result = hand.GetHandValue();
            
            Assert.That(result, Is.GreaterThan(0));
        }
    }
}