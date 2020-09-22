using System.Linq;
using System;

using System.Collections.Generic;

namespace GoFish.Models
{
    public class Player
    {
        public int Id {get;set;}
        public List<Card> Hand{get;set;} 
        public Player(List<Card> initialHand, int id)
        {
          Hand = initialHand;
          Id = id;
        }

        public List<List<Card>> pairs = new List<List<Card>>();

        private void ReceiveCards(List<Card> received, string rank)
        {
          received.Concat(Hand.Where(item => item.Rank == rank).ToList());
          Hand.RemoveAll(item => item.Rank == rank);
          pairs.Add(received);
        }

        public void GiveCards(string rank, Player player)
        {
          if(Hand.Where(item => item.Rank == rank).ToList().Count > 0){
            List<Card> matches = Hand.FindAll(item => item.Rank == rank);
            Hand.RemoveAll(item => item.Rank == rank);
            player.ReceiveCards(matches,rank);
          }
          else{
            player.GoFish();
          }
        }

        public void GoFish()
        {
          Hand.Add(Game.Current.CardDeck[0]);
          Game.Current.CardDeck.RemoveAt(0);
        }
    }
}