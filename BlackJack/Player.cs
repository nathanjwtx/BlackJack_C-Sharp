using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;

namespace BlackJack
{
    public class Player
    {
        private string PlayerName { get; set; }
        public int BankRoll { get; set; }


        public Player()
        {
            this.BankRoll = 100;
        }

        public Player(int bankroll)
        {
            SetBankRoll(bankroll);
        }

        public void SetBankRoll(int bankroll)
        {
            BankRoll = bankroll;
        }
        
        public void SetPlayerName(string name)
        {
            PlayerName = name;
        }
        
        public string GetPlayer()
        {
            return PlayerName;
        }

        
    }
}