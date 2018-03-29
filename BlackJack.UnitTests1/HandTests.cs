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
            var hand = new Hand();

            var result = hand.PlayerHand;
            
            Assert.That(result, Is.TypeOf<List<String>>());
        }
        
        [Test]
        public void Deal_AdddCardToHand_HandIsNotEmpty()
        {
            var deck = new CardDeck();
            var hand = new Hand();
            hand.PlayerHand.Add(deck.DealCard());

            var result = hand.PlayerHand;
            
            Assert.That(result.Count, Is.EqualTo(1));
        }
    }
}