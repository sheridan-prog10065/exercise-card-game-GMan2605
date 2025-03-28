
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
    private static Random s_randomizer = new Random();

    /// <summary>
    /// The list of cards in the deck
    /// </summary>
    private List<Card> _cardList;

    #endregion

    public CardDeck()
    {
        
    }

    /// <summary>
    /// Read-only property for the static s_randomizer
    /// </summary>
    public static Random Randomizer
    {
        get
        {
            return s_randomizer;
        }
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
        
    }

    public void ShuffleCards()
    {
        
    }

    public void PrintCards()
    {
        
    }

    public bool GetPairOfCards(out Card cardOne, out Card cardTwo)
    {
        try
        {
            cardOne = _cardList[s_randomizer.Next(_cardList.Count)];
            cardTwo = _cardList[s_randomizer.Next(_cardList.Count)];
            return true;
        }
        catch (ArgumentOutOfRangeException)
        {
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