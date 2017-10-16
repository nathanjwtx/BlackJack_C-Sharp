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
        private const string _cards = "A-h, A-d, A-c, A-s, 2-h, 2-d, 2-c, 2-s";

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

        public string DealCard()
        {
            
            return Deck[0];
        }

    }

}