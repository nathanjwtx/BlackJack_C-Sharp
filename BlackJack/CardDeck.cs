using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace BlackJack
{
    class CardDeck
    {
        public List<string> Deck { get; set; }
        private static Random random = new Random();
        private const string _cards = "A-h, A-d, A-c, A-s, 2-h, 2-d, 2-c, 2-s, 3-h, 3-d, 3-c, 3-s, 4-h, 4-d, 4-c, 4-s, 5-h, 5-d, 5-c, 5-s," +
                                      "6-h, 6-d, 6-c, 6-s, 7-h, 7-d, 7-c, 7-s, 8-h, 8-d, 8-c, 8-s, 9-h, 9-d, 9-c, 9-s, 10-h, 10-d, 10-c, 10s," +
                                      "J-h, J-d, J-c, J-s, Q-h, Q-d, Q-c, Q-s, K-h, K-d, K-c, K-s";

        public CardDeck()
        {
            this.Deck = new List<string>();
            Deck = _cards.Split(',').ToList();
            ShuffleList(Deck);
        }
        
        public static void ShuffleList<E>(IList<E> list)
        {
            if (list.Count > 1)
            {
                for (int i = list.Count - 1; i >= 0; i--)
                {
                    E tmp = list[i];
                    int randomIndex = random.Next(i + 1);

                    //Swap elements
                    list[i] = list[randomIndex];
                    list[randomIndex] = tmp;
                }
            }
        }

        public List<string> DealCard()
        {
            
            return Deck;
        }

    }

}