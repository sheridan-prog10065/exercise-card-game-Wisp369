namespace CardGameInteractive;
/// <summary>
/// Defines the card game that implements the game logic and holds the card deck
/// </summary>
public class CardGame
{
    ///Represents the deck of cards the game is using
    private CardDeck _deck;
    
    /// <summary>
    /// The score of hte game
    /// </summary>
    private Score _score;

    /// <summary>
    /// Last card that is played by the user
    /// </summary>
    private Card _playerCard;
    
    ///The last card played by the house
    private Card _houseCard;
    
}