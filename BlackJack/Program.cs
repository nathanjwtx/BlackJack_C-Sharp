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
        static void Main()
        {
            var game = new GamePlay();
            var players = new List<Player>();
            Console.WriteLine("Enter number of players: ");
            var intPlayers = Convert.ToInt32(Console.ReadLine());
            for (var i = 0; i < intPlayers; i++)
            {
                Console.WriteLine($"Enter player {i + 1} name: ");
                var name = Console.ReadLine();
                var p1 = new Player();
                players.Add(p1);
                p1.SetPlayerName(name);
            }

            game.Game(players);
        }
    }
}