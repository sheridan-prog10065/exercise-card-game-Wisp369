using System.Diagnostics;

namespace CardGameInteractive;
/// <summary>
/// Defines the card in a card game with it's values and suit
/// </summary>
public class Card
{
    /// <summary>
    /// The value of the playing card
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

    public byte Value
    {
        get
        {
            return _value;
        }
        set
        {
            _suit = value;
        }
    }

    public string CardName
    {
        get
        {
            switch (_value)
            {
                case 1: 
                    return "Ace";
                case 13:
                    return "King";
                case 12:
                    return "Queen";
                case 11:
                    return "Jack";
                default:
                    //Convert the numeric value into a string
                    return _value.ToString();
            }
        }
    }

    public string SuitName
    {
        get
        {
            switch (_suit)
            {
                case CardSuit.Clubs:
                    return "Club";
                case CardSuit.Diamonds:
                    return "Diamond";
                case CardSuit.Hearts:
                    return "Heart";
                case CardSuit.Spades:
                    return "Spade";
                default:
                    Debug.Assert(false, "Unknown suit value, cannot return suit name");
                    return _suit.ToString();
            }
        }
    }
}