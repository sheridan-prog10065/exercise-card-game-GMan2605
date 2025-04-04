
namespace CardGameInteractive;

/// <summary>
/// Defines the card deck as a list of cards
/// </summary>
public class CardDeck
{

    #region Fields

    /// <summary>
    /// Static field for the randomizer instance used by all CardDecks
    /// </summary>
    private static Random s_randomizer;

    private const int MAX_SUIT_COUNT = 4;

    private const int MAX_CARD_VALUE = 13;

    /// <summary>
    /// The list of cards in the deck
    /// </summary>
    private List<Card> _cardList;

    #endregion

    public CardDeck()
    {
        _cardList = new List<Card>(); // Initialize the list of cards
        CreateCards();
    }

    /// <summary>
    /// Static constructor to initialize the static fields (eg. the randomizer)
    /// </summary>
    static CardDeck()
    {
        s_randomizer = new Random();
    }

    /// <summary>
    /// Read-only property for the static s_randomizer field
    /// </summary>
    public static Random Randomizer
    {
        get { return s_randomizer; }
    }

    /// <summary>
    /// Read-only property that returns the number of cards in the deck
    /// </summary>
    public int CardCount
    {
        get
        {
            return _cardList.Count();
        }
    }

    private void CreateCards()
    {
        //iterate for each suit in the card deck
        for (int iSuit = 1; iSuit <= MAX_SUIT_COUNT; iSuit++)
        {
            CardSuit suit = (CardSuit)iSuit;

            //iterate for each card value
            for (byte cardValue = 1; cardValue <= MAX_CARD_VALUE; cardValue++)
            {
                //create the card object with the given card suit and value
                Card card = new Card(cardValue, suit);

                //add the card suit to the deck
                _cardList.Add(card);
            }
        }


    }

    public void ShuffleCards()
    {
        //iterate through each card in the deck
        for (int iCard = 0; iCard < _cardList.Count; iCard++)
        {
            //choose a random position in the deck
            int randPos = s_randomizer.Next(iCard, _cardList.Count);

            //replace the current card with the card at the random position
            Card crtCard = _cardList[iCard];
            Card randCard = _cardList[randPos];
            _cardList[randPos] = crtCard; // Place the random card at the current pos
            _cardList[iCard] = randCard; // Place the current at the random position

        }
    }

    public void PrintCards()
    {
        
    }

    /// <summary>
    /// Extracts two random cards from the deck
    /// </summary>
    /// <param name="cardOne">first card output</param>
    /// <param name="cardTwo">second card output</param>
    /// <returns>True if the extraction was possible, false if there are no cards left</returns>
    public bool GetPairOfCards(out Card cardOne, out Card cardTwo)
    {
        // Check that we have enough cards to extract a pair
        if (_cardList.Count >= 2)
        {
            // extract the first card
            // generate the a random position
            int randPos = CardDeck.Randomizer.Next(_cardList.Count);

            // assign cardOne to the card at that random position
            cardOne = _cardList[randPos];

            // extract the second card
            // generate a random number 
            randPos = CardDeck.Randomizer.Next(_cardList.Count);

            // assign cardTwo to the card at that random position
            cardTwo = _cardList[randPos];

            return true;
        }
        else
        {
            // Else there are not enough cards, the game must be over
            cardOne = null;
            cardTwo = null;
            return false;
        }
    }

    public void ExchangeCards(ref Card cardOne, ref Card cardTwo)
    {
        Card tempCard = cardOne;
        cardOne = cardTwo;
        cardTwo = cardOne;
    }
}