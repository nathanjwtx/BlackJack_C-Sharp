using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace BlackJack
{
    public class CardDeck
    {
        private List<string> RawDeck { get; set; }
        private Stack<string> Deck { get; set; }
        private static readonly Random Random = new Random();
        private const string Cards = "A-h,A-d,A-c,A-s,2-h,2-d,2-c,2-s,3-h,3-d,3-c,3-s,4-h,4-d,4-c,4-s,5-h,5-d,5-c,5-s,"+
            "6-h,6-d,6-c,6-s,7-h,7-d,7-c,7-s,8-h,8-d,8-c,8-s,9-h,9-d,9-c,9-s,10-h,10-d,10-c,10-s,"+
            "J-h,J-d,J-c,J-s,Q-h,Q-d,Q-c,Q-s,K-h,K-d,K-c,K-s";

        public CardDeck()
        {
            this.RawDeck = new List<string>();
            this.Deck = new Stack<string>();
            RawDeck = Cards.Split(',').ToList();

            ShuffleList(RawDeck);

            foreach (var card in RawDeck)
            {
                Deck.Push(card);
            }
            
        }

        private static void ShuffleList<TE>(IList<TE> list)
        {
            if (list.Count <= 1) return;
            for (var i = list.Count - 1; i >= 0; i--)
            {
                var tmp = list[i];
                var randomIndex = Random.Next(i + 1);

                //Swap elements
                list[i] = list[randomIndex];
                list[randomIndex] = tmp;
            }
        }

        public string DealCard()
        {
            return Deck.Pop();
        }

        public int TestCardsLeft()
        {
            return Deck.Count();
        }

    }

}