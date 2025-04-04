namespace CardGameInteractive;

public partial class MainPage : ContentPage
{
    private CardGame _cardGame;

    public MainPage()
    {
        InitializeComponent();

        //initialize the CardGame object
        _cardGame = new CardGame();
    }

    private void OnDealCards(object sender, EventArgs e)
    {
        //ask the game object to deal cards to player and the house
        _cardGame.DealCards();
    }

    private void OnSwitchCards(object sender, EventArgs e)
    {
        //ask game object to switch cards between player and house
        _cardGame.SwitchCards();
    }

    private void OnPlayCards(object sender, EventArgs e)
    {
        //ask the game to play a round in the game
        _cardGame.Play();
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