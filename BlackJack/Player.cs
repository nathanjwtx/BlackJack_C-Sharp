using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace BlackJack
{
    class Player : CardDeck
    {
        private string PlayerName { get; set; }
        public List<string> Hand { get; set; }
        private int BankRoll { get; set; }
        private int HandValue { get; set; }

        public Player()
        {
            this.Hand = new List<string>();
        }
        
        public void SetPlayerName(string name)
        {
            PlayerName = name;
        }
        
        public string GetPlayer()
        {
            return PlayerName;
        }

        public void UpdateHand(string card)
        {
            Hand.Add(card);
        }

        public void GetHand()
        {
            foreach (var card in Hand)
            {
                Console.WriteLine(card);
            }
        }

        public void SetHandValue()
        {
            var score = 0;
            foreach (var card in Hand)
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
                        default:
                            var x = char.GetNumericValue(card[0]);
                            score += Convert.ToInt32(x);
                            break;
                }
            }
            this.HandValue = score;
        }

        public int GetHandValue()
        {
            return this.HandValue;
        }
    }
}