using System;
using System.Collections.Generic;
using System.ComponentModel;
using NUnit.Framework;

namespace BlackJack.UnitTests1
{
    [TestFixture]
    public class HandTests
    {
        [Test]
        public void Hand_CreateNewHand_ReturnsListOfTypeString()
        {
            var deck = new CardDeck();
            var hand = new Hand(deck);

            var result = hand.PlayerHand;
            
            Assert.That(result, Is.TypeOf<List<String>>());
        }
        
        [Test]
        public void Deal_AdddCardToHand_HandIsNotEmpty()
        {
            var deck = new CardDeck();
            var hand = new Hand(deck);
            hand.Deal();

            var result = hand.PlayerHand;
            
            Assert.That(result, Is.Not.Empty);
        }
        
        [Test]
        public void Deal_AddACard_HandHas1Card()
        {
            var deck = new CardDeck();
            var hand = new Hand(deck);
            hand.Deal();

            var result = hand.PlayerHand;

            Assert.That(result.Count, Is.EqualTo(1));
        }
    }
}