using System;
using System.Collections.Generic;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            var cards = new CardDeck();
            Console.WriteLine(cards.DealCard());
        }
    }

    public class Player
    {
        public string PlayerName { get; set; }
        public List<string> Hand { get; set; }

        public Player()
        {
            
        }

    }

    class PlayerHand : CardDeck
    {
        
    }
}