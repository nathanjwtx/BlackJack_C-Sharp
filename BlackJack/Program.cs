using System;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            var cards = new CardDeck();
            Console.WriteLine(cards.DealCard());
        }
    }
}