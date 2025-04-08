using System.Diagnostics;

namespace CardGameApp;

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
    static MainPage()
    {
        s_imageSourceCardBack = ImageSource.FromResource("playing_card_back.png"); 
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
        //Ask the game to swap the cards of the player with the house and remember the round result
        sbyte roundResult = _cardGame.PlayRound();

        //Show the results of the round
        ShowRoundResult(roundResult);
        //Disable the play commands and allow the user to deal another card
        _btnDealCards.IsEnabled = true;
        _btnPlayCards.IsEnabled = false;
        _btnSwitchCards.IsEnabled = false;

        //Check weather the game is over
        if (_cardGame.IsOver)
        {
            //Show who won the game
            ShowGameOver();
        }
    }

    private void ShowRoundResult(sbyte roundResult)
    {
        //Update the score board
        _txtPlayerScore.Text = _cardGame.Score.PlayerScore.ToString();
        _txtHouseScore.Text = _cardGame.Score.HouseScore.ToString();
        
        //Show the cards that have been played
        ShowCard(_imgPlayerCard, _cardGame.PlayerCard);
        ShowCard(_imgHouseCard, _cardGame.HouseCard);

        //Display who won the round, the player or the house
        switch (roundResult)
        {
            case 1:
                _txtGameBoard.Text = "The player wins the round!";
                break;
            case -1:
                _txtGameBoard.Text = "The house wins the round!";
                break;
            case 0:
                _txtGameBoard.Text = "The round is a tie";
                break;
            default:
                Debug.Assert(false, "Unknown round result");
                break;
        }
    }

    private void ShowCard(Image imageControl, Card card)
    {
        //Determine the image source for player and house cards based on card values
        char suitId = card.Suit.ToString()[0];
        string fileName = $"{suitId}{card.Value.ToString("00")}.png";
        //Set the image source 
        imageControl.Source = ImageSource.FromFile(fileName);
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
            _txtGameBoard.Text = "The game is a draw!";
        }
        //Disallow the dealing of the cards
        _btnDealCards.IsEnabled = false;
        _btnPlayCards.IsEnabled = false;
        _btnSwitchCards.IsEnabled = false;
        
        //TODO: Ask the user if they want to play the game
        
    }
}