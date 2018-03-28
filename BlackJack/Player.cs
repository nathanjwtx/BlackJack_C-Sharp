using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace BlackJack
{
    public class Player
    {
        private string PlayerName { get; set; }
        private int BankRoll { get; set; }


        public Player()
        {
            this.BankRoll = 100;
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