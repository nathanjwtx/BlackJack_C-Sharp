using System;
using System.Collections.Generic;

namespace BlackJack
{
    public class Hand
    {
//        private readonly CardDeck _deck;
        private int HandValue { get; set; }
        public List<string> PlayerHand { get; set; }
        private bool IsBust { get; set; }
        public bool Stick { get; set; }
        private bool IsBlackJack { get; set; }
        public int HandCount { get; set; }
        
        public Hand ()
//        public Hand (CardDeck _deck)
        {
//            this._deck = _deck;
            PlayerHand = new List<string>();
            IsBust = false;
            HandCount += 1;
        }

        public void AddCardToHand(string card)
        {
            PlayerHand.Add(card);            
        }

        public void GetHand()
        {
            foreach (var card in PlayerHand)
            {
                Console.WriteLine(card);
            }
        }

        public void SetCardValue(string card)
        {
            var score = 0;
            //foreach (var card in PlayerHand)
            //{
//                if (card.Length <= 0)
                switch (card[0])
                {
                    case 'A':
                        Console.WriteLine("Ace is 1 or 11?");
                        score += Convert.ToInt32(Console.ReadLine());
                        break;
                    case 'K':
                        score += 10;
                        break;
                    case 'Q':
                        score += 10;
                        break;
                    case 'J':
                        score += 10;
                        break;
                    case '1':
                        score += 10;
                        break;
                    default:
                        var x = char.GetNumericValue(card[0]);
                        score += Convert.ToInt32(x);
                        break;
                }
            //}
            // Update value of hand
            HandValue += score;
            if (HandValue > 21)
            {
                IsBust = true;
            }
        }
        
        public int GetHandValue()
        {
            return HandValue;
        }

        public bool GetIsBust()
        {
            return IsBust;
        }
    }
}