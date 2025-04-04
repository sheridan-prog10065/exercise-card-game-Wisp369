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
    
    //Define card deck constant
    private const int MAX_SUIT_COUNT = 4;
    private const int MAX_CARD_VALUE = 13;

    private int _playerScore;
    
    private int _houseScore;
    /// <summary>
    /// The randomizer for the card deck shuffiling
    /// </summary>
    private static Random s_randomizer;

    static CardDeck()
    {
        s_randomizer = new Random();
    }

    /// <summary>
    /// The suit of the player card
    /// </summary>
    public CardDeck()
    {
        _cardList = new List<Card>();
        
        //Create the cards in the deck
        CreateCards();
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
    public static Random Randomizer { get { return s_randomizer; } }

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
    private void CreateCards()
    {
        //For each suit in the card deck
        for (int iSuit = 1; iSuit <= MAX_SUIT_COUNT; iSuit++)
        {
            CardSuit suit = (CardSuit)iSuit;
            //For each card value
            for (byte value = 1; value <= MAX_SUIT_COUNT; value++)
            {
                //Create the card object with the given suit and value
                Card card = new Card(value, suit);
                //Add the card to the deck
                _cardList.Add(card);
            }
        }
    }

    public void ShuffleCards()
    {
        //For each card in the deck
        for (int iCard = 0; iCard < _cardList.Count; iCard++)
        {
            //Chose a random position in the deck
            int randPos = s_randomizer.Next(iCard, _cardList.Count);
            
            //Replace the current card with the card at the random position
            Card crtCard = _cardList[iCard];
            Card randCard = _cardList[randPos];
            _cardList[randPos] = crtCard;
            _cardList[iCard] = randCard;
        }
    }

    /// <summary>
    /// Extracts two random cards from the deck
    /// </summary>
    /// <param name="cardOne">First card output</param>
    /// <param name="cardTwo">Second card outpup</param>
    /// <returns>true if extraction is possible, false if there are no cards left</returns>
    public bool GetPairOfCards(out Card cardOne, out Card cardTwo)
    {
        //Check that we have enough cards for the extraction
        if (_cardList.Count >= 2)
        {
            //Extract the first card
            int randPos = CardDeck.Randomizer.Next(0, _cardList.Count);

            //Extract the second card
            cardOne = _cardList[randPos];
            
            //Remove the card from the deck
            _cardList.RemoveAt(randPos);
            
            //Extract the second card
            randPos = CardDeck.Randomizer.Next(0, _cardList.Count);
            cardTwo = _cardList[randPos];
            _cardList.RemoveAt(randPos);
            
            //Indicate success
            return true;
        }
        else
        {
            //There are not enough cards, the game must be over
            cardOne = null;
            cardTwo = null;
            return false;
        }
    }

    public void ExchangeCards(ref Card cardOne, ref Card cardTwo)
    {
        (cardOne, cardTwo) = (cardTwo, cardOne);
    }
}