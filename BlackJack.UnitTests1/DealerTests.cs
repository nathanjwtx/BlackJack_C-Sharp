using System;
using NUnit.Framework;

namespace BlackJack.UnitTests1
{
    [TestFixture]
    public class DealerTests
    {
        [Test]
        public void Dealer_SingleDealer_ReturnsNull()
        {
            var d1 = new Dealer(new Player());
            var d2 = new Dealer(new Player());

            var result = d2._dealer;

            Assert.That(result, Is.Null);
        }

        [Test]
        public void Dealer_GetBankRoll_ReturnsInt()
        {
            var d1 = new Dealer(new Player());

            var result = d1._dealer.BankRoll;
            
            Assert.That(result, Is.EqualTo(10000));
        }
    }
}