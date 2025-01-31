namespace CardGameInteractive;

/// <summary>
/// Defines the card in a card game with its value and suit
/// </summary>
public class Card
{
    /// <summary>
    /// The numerical value of the playing card
    /// </summary>
    private byte _value;
    
    /// <summary>
    /// The suit of the player card
    /// </summary>
    private CardSuit _suit;

    public Card(byte value, CardSuit suit)
    {
        _value = value;
        _suit = suit;
    }
}