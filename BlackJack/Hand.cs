using System;
using System.Collections.Generic;

namespace BlackJack
{
    class Hand
    {
        private readonly CardDeck _deck;
        private int HandValue { get; set; }
        public List<string> PlayerHand { get; set; }
        private bool IsBust { get; set; }
        public bool Stick { get; set; }
        private bool IsBlackJack { get; set; }
        
        public Hand (CardDeck _deck)
        {
            this._deck = _deck;
            this.PlayerHand = new List<string>();
            this.IsBust = false;
        }

        public void Deal()
        {
            PlayerHand.Add(this._deck.DealCard());
        }

        public void GetHand()
        {
            foreach (var card in PlayerHand)
            {
                Console.WriteLine(card);
            }
        }

        public void SetHandValue()
        {
            var score = 0;
            foreach (var card in PlayerHand)
            {
                if (card.Length <= 0) continue;
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
            }
            this.HandValue = score;
            if (this.HandValue > 21)
            {
                this.IsBust = true;
            }
        }

        public int GetHandValue()
        {
            return this.HandValue;
        }

        public bool GetIsBust()
        {
            return this.IsBust;
        }
    }
}