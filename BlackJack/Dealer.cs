using System;

namespace BlackJack
{
    public class Dealer
    {
        public Player _dealer { get; }

        private static int dealerCount;

        public Dealer(Player dealer)
        {
            if (dealerCount == 0)
            {
                _dealer = dealer;
                dealer.SetBankRoll(10000);
                dealer.SetPlayerName("Dealer");
                dealerCount += 1;
            }
            else
            {
                Console.WriteLine("Dealer already exists");
            }
        }
    }
}