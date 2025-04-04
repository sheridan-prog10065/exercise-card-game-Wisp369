namespace CardGameInteractive;

public partial class MainPage : ContentPage
{
    private CardGame _cardGame;
    public MainPage()
    {
        InitializeComponent();
        
        //Initalize the game object
        _cardGame = new CardGame();
    }

    private void OnDealCards(object sender, EventArgs e)
    {
        //Ask the game object to deal cards to the player and house
        _cardGame.DealCards();
    }

    private void OnSwitchCards(object sender, EventArgs e)
    {
        //Ask the game to swap the cards of the player with the house
        _cardGame.SwitchCards();
        }

    private void OnPlayCards(object sender, EventArgs e)
    {
        //Ask the game to swap the cards of the player with the house
        _cardGame.PlayRound();
    }
}