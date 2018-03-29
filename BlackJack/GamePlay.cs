using System;
using System.Collections.Generic;

namespace BlackJack
{
    public class GamePlay
    {
        public CardDeck Deck { get; set; }
        
        public void Game(List<Player> players)
        {
//            var dealer = new Dealer(new Player());
            Deck = new CardDeck();
            var hand = new Hand();
//            var dealerHand = new Hand(deck);
            // dealer's face card
//            dealerHand.SetCardValue(dealerHand.Deal());
//            Console.WriteLine(dealerHand.GetHandValue());
            // Deal initial cards 
            DealInitialCards(players, hand);

            foreach (var player in players)
            {
                Console.WriteLine($"{player.GetPlayer()} your cards are: ");
//                hand.GetHand();
                player.PlayerHand.GetHand();
//                hand.SetHandValue();
                Console.WriteLine(hand.GetHandValue());
                // Next card
                while (hand.Stick == false)
                {
                    Console.WriteLine("(D)eal or (S)tick?");
                    if (Console.ReadLine().ToUpper() == "S")
                    {
                        hand.Stick = true;
                        player.Status = "stick";
                        Console.WriteLine($"{player.GetPlayer()} has stuck on {hand.GetHandValue()}");
                    }
                    else
                    {
                        hand.SetCardValue(Deck.DealCard());
                        hand.GetHand();
                        Console.WriteLine($"{player.GetPlayer()} score is {hand.GetHandValue()}");
                        if (hand.GetIsBust())
                        {
                            player.Status = "bust";
                            Console.WriteLine("You busted");
                            break;
                        }
                    }
                }
            }

            Console.WriteLine($"Cards left: {Deck.TestCardsLeft()}");
            var countStick = 0;
            foreach (var player in players)
            {
                if (player.Status == "stick")
                {
                    countStick += 1;
                }
            }
//            if (countStick > 0)
//            {
//                Console.WriteLine("dealer's next card:");
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
//            }
        }

        private void DealInitialCards(List<Player> players, Hand hand)
        {
            for (int i = 0; i < 2; i++)
            {
                foreach (Player player in players)
                {
                    var card = Deck.DealCard();
                    hand.PlayerHand.Add(card);
                    hand.SetCardValue(card);
                    Console.WriteLine($"Card {i + 1} for {player.GetPlayer()} is: ");
                    Console.WriteLine(card);
                }
            }
        }
    }
}