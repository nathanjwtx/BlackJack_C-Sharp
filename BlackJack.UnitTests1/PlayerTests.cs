using NUnit.Framework;

namespace BlackJack.UnitTests1
{
    [TestFixture]
    public class PlayerTests
    {
        [Test]
        public void SetPlayerName_AddName_PLayerNameNotNull()
        {
            var player = new Player();
            player.SetPlayerName("nathan");

            var result = player.GetPlayer();
            
            Assert.That(result, Is.EqualTo("nathan"));
        }
    }
}