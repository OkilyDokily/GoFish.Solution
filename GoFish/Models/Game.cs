using System.Collections.Generic;
using System;
using System.Linq;

namespace GoFish.Models
{
    
    public class Game
    {
        public List<Player> Players = new List<Player>();
        public List<Card> CardDeck {get;set;}
        public static Game Current {get;set;}

        public int WhoseTurn {get;set;}
        public Game(int players)
        {
            CardDeck = (new Deck()).Shuffle();
            int id = 0;
            int[] arr = new int[players];
            Array.ForEach(arr,item => {
                List<Card> hand = CardDeck.Take(5).ToList();
                CardDeck.RemoveRange(0,5);
                Players.Add(new Player(hand,id));
                id++;
            });
            Current = this;
        }

        public void NextTurn()
        {
            if(WhoseTurn == Players.Count - 1)
            {
                WhoseTurn = 0;
            }
            else{
                WhoseTurn++;
            }
        }

        public bool IsGameOver()
        {
            return (CardDeck.Count == 0 && Players.All(item => item.Hand.Count == 0));
        }

        public Player DetermineWinner()
        {
           List<Player> nl =  Players.OrderBy(item => item.pairs.Count).ToList();
           return nl[0]; 
        }
    }
}