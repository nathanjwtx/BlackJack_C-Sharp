using System;
using System.Collections.Generic;

namespace BlackJack
{
    public partial class GamePlay
    {
        public static void GetWinner(Dictionary<string, int> allScores)
        {
            var scores = allScores.Values;
            foreach (var score in scores)
            {
                Console.WriteLine(score);
            }
        }        
    }
}