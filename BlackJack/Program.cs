﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            var players = new List<Player>();
            Console.WriteLine("Enter number of players: ");
            var intPlayers = Convert.ToInt32(Console.ReadLine());
            for (var i = 0; i < intPlayers; i++)
            {
                var name = "";
                Console.WriteLine($"Enter player {i + 1} name: ");
                name = Console.ReadLine();
                var p1 = new Player();
                players.Add(p1);
                p1.SetPlayerName(name);
            }
            Game(players);
        }
        
        static void Game(List<Player> players)
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
            Console.WriteLine(deck.TestCardsLeft());
        }
    }
}