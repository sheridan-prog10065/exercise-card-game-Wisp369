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
 }