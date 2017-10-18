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
            for (var i = 0; i < intPlayers + 1; i++)
            {
                var name = "";
                if (i == 0)
                {
                    name = "Dealer";
                }
                else
                {
                    Console.WriteLine($"Enter player {i} name: ");
                    name = Console.ReadLine();
                }
                var p1 = new Player();
                players.Add(p1);
                p1.SetPlayerName(name);
            }
            Game(players);
        }
        
        static void Game(List<Player> players)
        {
            var cards = new CardDeck();
            foreach (Player player in players)
            {
                Console.WriteLine(player.GetPlayer());
                // Deal initial cards 
                for (int i = 0; i < 2; i++)
                {
                    player.UpdateHand(cards.DealCard());    
                }
                Console.WriteLine($"{player.GetPlayer()} your cards are: ");
                player.GetHand();
                player.SetHandValue();
                Console.WriteLine(player.GetHandValue());
            }
        }
    }
}