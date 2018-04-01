using System;

namespace BlackJack
{
    public class TheDealer
    {
        public Player Dealer { get; }

        private static int _dealerCount;

        public TheDealer(Player dealer)
        {
            if (_dealerCount == 0)
            {
                Dealer = dealer;
                dealer.SetBankRoll(10000);
                dealer.SetPlayerName("Dealer");
                _dealerCount += 1;
            }
            else
            {
                Console.WriteLine("Dealer already exists");
            }
        }
    }
}