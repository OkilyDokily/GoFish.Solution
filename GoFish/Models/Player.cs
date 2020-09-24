using System.Linq;
using System;

using System.Collections.Generic;

namespace GoFish.Models
{
    public class Player
    {
        public int Id {get;set;}
        public List<Card> Hand{get;set;} 
        public static bool Played {get;set;}
        public Player(List<Card> initialHand, int id)
        {
          Hand = initialHand;
          Id = id;
          Played = false;
        }

       
        public List<List<Card>> pairs = new List<List<Card>>();

        private void ReceiveCards(List<Card> received, string rank)
        {
          if(MatchesPair(rank))
          {
            List<Card> pair = pairs.Where(x=> x[0].Rank == rank).ToList()[0];
            pair = pair.Concat(received).ToList();
          }
          else
          {
            received = received.Concat(Hand.Where(item => item.Rank == rank).ToList()).ToList();
            Hand.RemoveAll(item => item.Rank == rank);
            pairs.Add(received);
          }
        }

        public bool MatchesPair(string rank)
        {
          foreach(List<Card> pair in pairs)
          {
            if(pair[0].Rank ==  rank)
            {
              return true;
            }
          }
          return false;
        }

        public void ForceCards(string rank, Player player)
        { 
          if(Hand.Where(item => item.Rank == rank).ToList().Count > 0){
            List<Card> matches = Hand.FindAll(item => item.Rank == rank);
            Hand.RemoveAll(item => item.Rank == rank);
            player.ReceiveCards(matches,rank);
          }
          else{
            player.GoFish();
          }
          Game.Current.NextTurn();
          Game.Moves++;
        }

        private void AddFourPairToPairs()
        {
          foreach(Card card in Hand)
          {
            if(Hand.Where(x => x.Rank == card.Rank).ToList().Count == 4)
            {
              pairs.Add(Hand.Where(x => x.Rank == card.Rank).ToList());
              Hand.RemoveAll(item => item.Rank == card.Rank);
            }
          }
        }

        public void GoFish()
        {
          if(MatchesPair(Game.Current.CardDeck[0].Rank))
          {
            List<Card> pair = pairs.Where(x=> x[0].Rank == Game.Current.CardDeck[0].Rank).ToList()[0];
            pair.Add(Game.Current.CardDeck[0]);
          }
          else
          {
            Hand.Add(Game.Current.CardDeck[0]);
          }
          Game.Current.CardDeck.RemoveAt(0);
          AddFourPairToPairs();
        }
    }
}