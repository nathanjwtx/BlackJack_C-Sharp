using System;
using System.Collections.Generic;

namespace BlackJack
{
    public class GamePlay
    {
        private CardDeck Deck { get; set; }
        
        public void Game(List<Player> players, TheDealer dealer)
        {
            Deck = new CardDeck();
            // Deal initial cards 
            DealInitialCards(players);
            // dealer's face card
            var dealerFace = Deck.DealCard();
            var dealerSecond = Deck.DealCard();
            dealer.Dealer.PlayerHand.SetCardValue(dealerFace);
//            dealerHand.SetCardValue(dealerFace);
            Console.WriteLine("Dealer's face card is:");
            Console.WriteLine(dealerFace);
            // Player turns
            PlayerTurn(players);
            Console.WriteLine($"Cards left: {Deck.TestCardsLeft()}");

            DealerTurn(players, dealerSecond, dealer);
        }

        private void DealerTurn(List<Player> players, string dealerSecond, TheDealer dealer)
        {
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
                dealer.Dealer.PlayerHand.SetCardValue(dealerSecond);
                Console.WriteLine($"Dealer's second card is: {dealerSecond}");
                var dealDealer = true;
                while (dealDealer)
                {
                    if (dealer.Dealer.PlayerHand.GetHandValue() <= 17)
                    {
                        var dealerCard = Deck.DealCard();
                        dealer.Dealer.PlayerHand.SetCardValue(dealerCard);
//                        dealerHand.SetCardValue(dealerCard);
                        dealer.Dealer.PlayerHand.AddCardToHand(dealerCard);
//                        dealerHand.AddCardToHand(dealerCard);
                        Console.WriteLine($"Dealer's next card is: {dealerCard}");
                    }
                    else if (dealer.Dealer.PlayerHand.GetHandValue() <= 21)
                    {
                        dealer.Dealer.PlayerHand.Stick = true;
                        Console.WriteLine($"Dealer sticks on: {dealer.Dealer.PlayerHand.GetHandValue()}");
                        dealDealer = false;
                    }
                    else if (dealer.Dealer.PlayerHand.GetHandValue() > 21)
                    {
                        Console.WriteLine("Dealer went bust!");
                        dealDealer = false;
                    }
                    else
                    {
                        dealer.Dealer.PlayerHand.Stick = true;
                        dealer.Dealer.Status = "stick";
                        Console.WriteLine($"Dealer sticks on: {dealer.Dealer.PlayerHand.GetHandValue()}");
                        dealDealer = false;
                    }
                }
            }
            else
            {
                Console.WriteLine("Dealer won this hand!");
            }
        }

        private void PlayerTurn(List<Player> players)
        {
            foreach (var player in players)
            {
                Console.WriteLine($"{player.GetPlayer()} your cards are: ");
                player.PlayerHand.GetHand();
                Console.WriteLine($"{player.GetPlayer()} score is {player.PlayerHand.GetHandValue()}");
                // Next card
                while (player.PlayerHand.Stick == false)
                {
                    Console.WriteLine("(D)eal or (S)tick?");
                    var playResponse = Console.ReadLine();
                    if (playResponse != null && playResponse.ToUpper() == "S")
                    {
                        player.PlayerHand.Stick = true;
                        player.Status = "stick";
                        Console.WriteLine($"{player.GetPlayer()} has stuck on {player.PlayerHand.GetHandValue()}");
                        break;
                    }

                    if (playResponse != null && playResponse.ToUpper() == "D")
                    {
                        var card = Deck.DealCard();
                        player.PlayerHand.SetCardValue(card);
                        player.PlayerHand.AddCardToHand(card);
                        Console.WriteLine(card);
                        Console.WriteLine($"{player.GetPlayer()} score is {player.PlayerHand.GetHandValue()}");
                    }

                    if (player.PlayerHand.GetIsBust())
                    {
                        player.Status = "bust";
                        Console.WriteLine("You busted");
                        break;
                    }
                }
            }
        }

        private void DealInitialCards(List<Player> players)
        {
            Console.WriteLine("--------------START INITIAL DEAL-----------------------------");
            for (int i = 0; i < 2; i++)
            {
                foreach (Player player in players)
                {
                    var card = Deck.DealCard();
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