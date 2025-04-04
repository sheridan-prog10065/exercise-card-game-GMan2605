using AndroidX.Activity;

namespace CardGameInteractive;

/// <summary>
/// Defines the card game that implements the game logic and holds the card deck
/// </summary>
public class CardGame
{
    #region Field Declarations

    /// <summary>
    /// Represents the deck of cards the game is using
    /// </summary>
    private CardDeck _cardDeck;
    
    /// <summary>
    /// The score of the game
    /// </summary>
    private Score _score;
    
    /// <summary>
    /// The last card played by the user
    /// </summary>
    private Card _playerCard;
    
    /// <summary>
    /// The last card played by the house
    /// </summary>
    private Card _houseCard;

    #endregion

    #region Constructors
    /// <summary>
    /// The constructor of the crd game class
    /// </summary>
    public CardGame()
    {
        _cardDeck = new CardDeck();
        _score = new Score();
        _houseCard = null;
        _playerCard = null;
    }

    #endregion

    #region Properties

    public Score Score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
        }
    }
    public Card PlayerCard
    {
        get
        {
            return _playerCard;
        }
    }
    public Card HouseCard
    {
        get
        {
            return _houseCard;
        }
    }
    public bool IsOver
    {
        get
        {
            return _cardDeck.CardCount < 2;
        }
    }
    public bool PlayerWins
    {
        get
        {
            return this.IsOver && (_score.PlayerScore > _score.HouseScore);
        }
    }
    public bool HouseWins
    {
        get
        {
            return this.IsOver && (_score.HouseScore > _score.PlayerScore)
        }
    }

    #endregion

    #region Methods
    /// <summary>
    /// Plays the game
    /// </summary>
    public void Play()
    {
        //TODO: Implement Play()
    }
    
    /// <summary>
    /// Plays a round of the game
    /// </summary>
    /// <returns>
    ///     +1: if the user won the round
    ///     0: there was a tie
    ///     -1: the house won the round
    /// </returns>
    public sbyte PlayRound()
    {
        //determine the card ranks for the player and house cards
        byte cardRank = DetermineCardRank(_playerCard);
        byte houseRank = DetermineCardRank(_houseCard);

        //check which card has the higer rank to determine the winner
        if (cardRank > houseRank)
        {
            //the player won the round
            return 1;
        }
        else if (houseRank > cardRank)
        {
            //the house won the round
            return -1;
        }
        else
        {
            //there was a tie
            return 0;
        }
    }

    public void SwitchCards(int cardCount)
    {
        // Create a deck fo cards (cardCount is passd as unidirectional input)
        CardDeck deck = new CardDeck(cardCount);

        //ask the deck for two cards
        Card cardOne;
        Card cardTwo;

        //obtain three values from a method (unidirectional output)
        if (deck.GetPairOfCards(out cardOne, out cardTwo))
        {
            //pass AND get information from the Exchange method
            //(bidirectional: input AND output)

        }
    }

    private void DealCards()
    {
        //TODO: Impement DealCards
    }

    /// <summary>
    /// Determine the rank of the card as used in the game. The Ace is the highest card
    /// </summary>
    /// <returns></returns>
    private byte DetermineCardRank(Card card)
    {
        return card.Value == 1 ? (byte)14 : card.Value;
    }

    private void ShowRoundResult()
    {
        
    }

    private void ShowGameOver()
    {
        
    }

    #endregion
}