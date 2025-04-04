namespace CardGameInteractive;

public partial class MainPage : ContentPage
{
    private readonly static ImageSource s_imageSourceCardBack;
    private CardGame _cardGame;
    public MainPage()
    {
        InitializeComponent();
        
        //Initalize the game object
        _cardGame = new CardGame();
    }

    private void OnDealCards(object sender, EventArgs e)
    {
        //Ensure the cards being dealt are turned face down
        _imgPlayerCard.Source = s_imageSourceCardBack;
        _imgHouseCard.Source = s_imageSourceCardBack;
        
        //Ask the game object to deal cards to the player and house
        _cardGame.DealCards();
        
        //Inform the user what they can do next: switch or play
        _txtGameBoard.Text = "You can play the round or swap cards with the house";

        //Allow the user to play
        _btnDealCards.IsEnabled = true;
        _btnSwitchCards.IsEnabled = true;
        _btnSwitchCards.IsEnabled = true;
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