using System.Collections.Generic;

namespace BlackJack
{
    public class Player
    {
        private string PlayerName { get; set; }
        public List<string> Hand { get; set; }

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