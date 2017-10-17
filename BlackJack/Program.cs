using System;
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
            var players = new List<object>();
            var cards = new CardDeck();
            Console.WriteLine("Enter number of players: ");
            var intPlayers = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < intPlayers; i++)
            {
                Console.WriteLine($"Enter player {i + 1} name: ");
                var p1 = new Player();
                p1.SetPlayerName(Console.ReadLine());
                players.Add(p1);
            }
            
        }

        public static void Testing(ref object player)
        {
            Type type = player.GetType();
            PropertyInfo prop = type.GetProperty("GetPlayer");
            Console.WriteLine(prop.GetGetMethod());

        }

    }

//    public class Game
//    {
//        public List<string> Deck { get; set; }
//        public List<string> Players { get; set; }
//        
//        
//    }

    public class Player
    {
        public string PlayerName { private get; set; }
        public List<string> Hand { get; set; }

        public void SetPlayerName(string name)
        {
            this.PlayerName = name;
        }
        
        public string GetPlayer()
        {
            return PlayerName;
        }
    }
}