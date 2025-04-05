using System.Diagnostics;

namespace CardGameInteractive;

public partial class MainPage : ContentPage
{
    private CardGame _cardGame;

    // Side note: constants are all primitive types (and strings and enums)

    private readonly static ImageSource s_imageSourceCardBack;

    public MainPage()
    {
        InitializeComponent();

        //initialize the CardGame object
        _cardGame = new CardGame();
    }
    
    static MainPage()
    {
        s_imageSourceCardBack = ImageSource.FromFile("playing_card_back.jpg");
    }

    private void OnDealCards(object sender, EventArgs e)
    {
        // ensure the cards being dealt are turned face down
        _imgPlayerCard.Source = s_imageSourceCardBack;
        _imgHouseCard.Source = s_imageSourceCardBack;

        //ask the game object to deal cards to player and the house
        _cardGame.DealCards();

        // inform the user what they can do next -> switch or play cards
        _txtGameBoard.Text = "You can play the round or swap cards with the house";

        // Allow the user to play
        _btnDealCards.IsEnabled = false;
        _btnSwitchCards.IsEnabled = true;
        _btnPlayCards.IsEnabled = true;
    }

    private void OnSwitchCards(object sender, EventArgs e)
    {
        //ask game object to switch cards between player and house
        _cardGame.SwitchCards();
    }

    private void OnPlayCards(object sender, EventArgs e)
    {
        //ask the game to play a round in the game
        sbyte roundResult = _cardGame.PlayRound();

        //show the results of the round
        ShowRoundResults(roundResult);

        //disable the play commands
        _btnSwitchCards.IsEnabled = false;
        _btnPlayCards.IsEnabled = false;
        _btnDealCards.IsEnabled = true;

        //check if the game is over
        if (_cardGame.IsOver)
        {
            //show who won the game
            ShowGameOver();
        }
    }

    private void ShowRoundResults(sbyte roundResult)
    {
        // First, update the scoreboard
        _txtPlayerScore.Text = _cardGame.Score.PlayerScore.ToString();
        _txtHouseScore.Text = _cardGame.Score.HouseScore.ToString();

        // Then, show the cards
        ShowCard(_imgPlayerCard, _cardGame.PlayerCard);
        ShowCard(_imgHouseCard, _cardGame.HouseCard);

        // Display who won the round (player or the house)
        switch (roundResult)
        {
            case 1:
                _txtGameBoard.Text = "Player wins the round!";
                break;
            case -1:
                _txtGameBoard.Text = "House wins the round!";
                break;
            case 0:
                _txtGameBoard.Text = "The round was a tie!";
                break;
            default:
                Debug.Assert(false, "Unknown round result");
                break;
        }
    }

    private void ShowGameOver()
    {
        //Display who won the game
        if (_cardGame.PlayerWins)
        {
            _txtGameBoard.Text = "The player won the game!";
        }
        else if (_cardGame.HouseWins)
        {
            _txtGameBoard.Text = "The house won the game!";
        }
        else
        {
            _txtGameBoard.Text = "The game was a draw.";
        }

        // Disallow the dealing of the cards
        _btnDealCards.IsEnabled = false;
        _btnPlayCards.IsEnabled = false;
        _btnSwitchCards.IsEnabled = false;

        //ask the user if they want to play the game again
    }

    private void ShowCard(Image imageControl, Card card)
    {
        // Determine the image source for the image control based on card value and suit
        char suitId = card.Suit.ToString()[0];
        string fileName = $"{suitId}{card.Value.ToString("00")}.png";

        // Set the image source
        imageControl.Source = ImageSource.FromFile(fileName);

    }

    private void OnBasicPress(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            button.Opacity = 0.5;
        }
    }

    private void OnBasicRelease(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            button.Opacity = 1.0;
        }
    }
}