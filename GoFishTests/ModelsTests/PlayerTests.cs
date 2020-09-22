using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoFish.Models;
using System.Collections.Generic;
namespace GoFishTests.ModelsTests
{
    [TestClass]
    public class PlayerTests
    {
  
        [TestMethod]
        public void GiveCards_TestIfCardsAreGivenCorrectly_ReturnsTrue()
        {
            //Arrange
            List<Card> hand = new List<Card>()
            {new Card("Clubs","black","3",0),
            new Card("Clubs","black","4",1),
            new Card("Clubs","black","5",2),
            new Card("Clubs","black","6",3),
            new Card("Clubs","black","7",4)};

            Player p = new Player(hand, 0);
            


            List<Card> hand2 = new List<Card>()
            {new Card("Spades","black","3",5),
            new Card("Spades","black","4",6),
            new Card("Spades","black","5",7),
            new Card("Spades","black","6",8),
            new Card("Spades","black","7",9)};

            Player p2 = new Player(hand2, 1);
        
            //Act
            p.GiveCards("3",p2);

            Assert.AreEqual(4,p.Hand.Count);
            Assert.AreEqual(4, p2.Hand.Count);
            Assert.AreEqual(1, p2.pairs.Count);
        }
    }
}