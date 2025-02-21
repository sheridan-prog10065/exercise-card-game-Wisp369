using Android.Icu.Text;

namespace CardGameInteractive;
/// <summary>
/// Defines the card deck as a list of cards
/// </summary>
public class CardDeck
{
    /// <summary>
    /// List of cards in the deck
    /// </summary>
    private List<Card> _cardList;

    private int _playerScore;
    
    private int _houseScore;

    /// <summary>
    /// The suit of the player card
    /// </summary>
    public CardDeck()
    {
        _cardList = new List<Card>();
    }

    /// <summary>
    /// Read-only propery that returns the number of cards in the deck
    /// </summary>
    public int CardCount
    {
        get
        {
            return _cardList.Count;
        }
    }

    public int PlayerScore
    {
        get
        {
            return _playerScore; 
            
        }
    }

    public int HouseScore
    {
        get
        {
            return _houseScore;
        }
    }
    
    
}