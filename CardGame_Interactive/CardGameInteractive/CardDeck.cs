
namespace CardGameInteractive;

/// <summary>
/// Defines the card deck as a list of cards
/// </summary>
public class CardDeck
{
    #region Fields
    /// <summary>
    /// The list of cards in the deck
    /// </summary>
    private List<Card> _cardList;
    #endregion

    public CardDeck()
    {
        
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
}