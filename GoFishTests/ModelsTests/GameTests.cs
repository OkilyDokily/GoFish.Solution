using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoFish.Models;
namespace GoFishTests.ModelsTests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void GameConstructor_DeckHasRightNumberOfCards_ReturnsTrue(){
            //act
            Game g = new Game(2);
            //assert
            Assert.AreEqual(42,g.CardDeck.Count);
            Assert.AreEqual(5, g.Players[0].Hand.Count);
        }
    }
}