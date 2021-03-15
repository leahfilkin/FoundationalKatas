namespace BlackJackKataConsole
{
    public class GameCreator
    { 
        public Game SetUpGame(Deck deck)
        {
            Hand playersHand = new Hand();
            Hand dealersHand = new Hand();
            playersHand = AddFirstCardsToHand(playersHand, deck, 2);
            dealersHand = AddFirstCardsToHand(dealersHand, deck, 2);
            Game game = AddHandsToGame(playersHand, dealersHand);
            return game;

        }
        public Hand AddFirstCardsToHand(Hand hand, Deck deck, int amountOfCards)
        {
            for (var i = 0; i < amountOfCards; i++)
            {
                hand.theirCards.Add(deck.GetRandomCard());
            }
            return hand;
        }

        public Game AddHandsToGame(Hand playersHand, Hand dealersHand)
        {
            var game = new Game(playersHand, dealersHand);
            return game;
        }
    }
}