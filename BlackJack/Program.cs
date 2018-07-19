﻿using System;
using System.Collections.Generic;

namespace BlackJack
{
    class Program
    {
        static void Main()
        {
            var game = new GamePlay();
            var players = new List<Player>();
            Console.WriteLine("-----------------------");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Welcome to BlackJack");
            Console.WriteLine("Enter: \n\tN for a new game, \n\tC to continue a saved game, or \n\tX to exit");
            var input = Console.ReadLine();
            if (input != null && input.ToUpper() == "N")
            {
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

                var playAgain = true;
                do
                {
                    var dealer = new TheDealer(new Player());
                    game.Game(players, dealer);
                    Console.WriteLine("Play again? Y or N");
                    if (Console.ReadLine() == "N" || Console.ReadLine() == "n")
                    {
                        playAgain = false;
                    }
                } while (playAgain);

                Console.WriteLine("Thanks for playing!");
            }
        }
    }
}