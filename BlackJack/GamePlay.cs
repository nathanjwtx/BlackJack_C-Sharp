using System;
using System.Collections.Generic;

namespace BlackJack
{
    public class GamePlay
    {
        public void Game(List<Player> players)
        {
            var dealer = new Player();
            dealer.SetPlayerName("Dealer");
            var deck = new CardDeck();
            foreach (Player player in players)
            {
                var hand = new Hand(deck);
                Console.WriteLine(player.GetPlayer());
                // Deal initial cards 
                for (int i = 0; i < 2; i++)
                {
                    hand.Deal();  
                }
                Console.WriteLine($"{player.GetPlayer()} your cards are: ");
                hand.GetHand();
                hand.SetHandValue();
                Console.WriteLine(hand.GetHandValue());
                // Next card
                while (hand.Stick == false)
                {
                    Console.WriteLine("(D)eal or (S)tick?");
                    if (Console.ReadLine().ToUpper() == "S")
                    {
                        hand.Stick = true;
                        Console.WriteLine($"{player.GetPlayer()} has stuck on {hand.GetHandValue()}");
                    }
                    else
                    {
                        hand.Deal();
                        hand.GetHand();
                        hand.SetHandValue();
                        Console.WriteLine($"{player.GetPlayer()} score is {hand.GetHandValue()}");
                        if (hand.GetIsBust() == true)
                        {
                            Console.WriteLine("You busted");
                            break;
                        }
                    }
                }
            }
            Console.WriteLine($"Cards left: {deck.TestCardsLeft()}");
        }
    }
}