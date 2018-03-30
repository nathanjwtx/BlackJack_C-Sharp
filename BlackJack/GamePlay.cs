using System;
using System.Collections.Generic;

namespace BlackJack
{
    public class GamePlay
    {
        private CardDeck Deck { get; set; }
        
        public void Game(List<Player> players)
        {
//            var dealer = new Dealer(new Player());
            Deck = new CardDeck();
            var hand = new Hand();
            var dealerHand = new Hand();
            // Deal initial cards 
            DealInitialCards(players, hand);
            // dealer's face card
            var dealerFace = Deck.DealCard();
            dealerHand.SetCardValue(dealerFace);
            Console.WriteLine("Dealer's face card is:");
            Console.WriteLine(dealerFace);
            // Player turns
            PlayerTurn(players, hand);

            Console.WriteLine($"Cards left: {Deck.TestCardsLeft()}");
            // Check to see if any players are not bust
            var countStick = 0;
            foreach (var player in players)
            {
                if (player.Status == "stick")
                {
                    countStick += 1;
                }
            }
            if (countStick > 0)
            {

                Console.WriteLine("dealer's next card:");
//                dealerHand.Deal();
//                Console.WriteLine(dealerHand.GetHandValue());
//                if (dealerHand.GetHandValue() <= 17)
//                {
//                    dealerHand.SetCardValue(dealerHand.Deal());
//                    Console.WriteLine(dealerHand.GetHandValue());
//                }
//                else
//                {
//                    dealerHand.Stick = true;
//                }
            }
            else
            {
                Console.WriteLine("Dealer won this hand!");
            }
        }

        private void PlayerTurn(List<Player> players, Hand hand)
        {
            foreach (var player in players)
            {
                Console.WriteLine($"{player.GetPlayer()} your cards are: ");
                player.PlayerHand.GetHand();
                Console.WriteLine(player.PlayerHand.GetHandValue());
                // Next card
                while (hand.Stick == false)
                {
                    Console.WriteLine("(D)eal or (S)tick?");
                    if (Console.ReadLine().ToUpper() == "S")
                    {
                        player.PlayerHand.Stick = true;
                        player.Status = "stick";
                        Console.WriteLine($"{player.GetPlayer()} has stuck on {player.PlayerHand.GetHandValue()}");
                        break;
                    }

//                    else
                    {
                        var card = Deck.DealCard();
                        player.PlayerHand.SetCardValue(card);
                        player.PlayerHand.AddCardToHand(card);
                        Console.WriteLine(card);
                        Console.WriteLine($"{player.GetPlayer()} score is {player.PlayerHand.GetHandValue()}");
                        if (player.PlayerHand.GetIsBust())
                        {
                            player.Status = "bust";
                            Console.WriteLine("You busted");
                            break;
                        }
                    }
                }
            }
        }

        private void DealInitialCards(List<Player> players, Hand hand)
        {
            Console.WriteLine("--------------START INITIAL DEAL-----------------------------");
            for (int i = 0; i < 2; i++)
            {
                foreach (Player player in players)
                {
                    var card = Deck.DealCard();
//                    hand.PlayerHand.Add(card);
                    player.PlayerHand.AddCardToHand(card);
                    player.PlayerHand.SetCardValue(card);
                    Console.WriteLine($"Card {i + 1} for {player.GetPlayer()} is: ");
                    Console.WriteLine(card);
                }
            }
            Console.WriteLine("--------------END INITIAL DEAL-----------------------------");
        }
    }
}