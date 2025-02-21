namespace CardGameInteractive;
/// <summary>
/// Defines the card game that implements the game logic and holds the card deck
/// </summary>
public class CardGame
{
    #region Fields
    ///Represents the deck of cards the game is using
    private CardDeck _cardDeck;
    
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

    #endregion
    
    #region Constructors
    /// <summary>
    /// The constructor of the card game class
    /// </summary>
    public CardGame()
    {
        _cardDeck = new CardDeck();
        _score = new Score();
        _playerCard = null;
        _houseCard = null;
    }
    #endregion
    
    #region Properties

    public Score Score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
        }
    }

    public Card PlayerCard
    {
        get
        {
            return _playerCard;
        }
    }

    public Card HouseCard
    {
        get
        {
            return _houseCard; 
        }
    }

    public bool IsOver
    {
        get
        {
            //TODO: Add card count method to _cardDeck
            return _cardDeck.CardCount < 2;
        }
    }

    public bool PlayerWins
    {
        get
        {
            //TODO: Add PlayerScore and HouseScore to _score
            return this.IsOver && (_score.PlayerScore > _score.HouseScore); //When using a property, use this.property
        }
    }

    public bool HouseWins
    {
        get
        {
            this.IsOver && (_score.HouseScore > _score.PlayerScore);
        }
    }
    #endregion
    
    #region Methods
    /// <summary>
    /// Plays the game
    /// </summary>
    public void Play()
    {
        //TODO: Implement play()
    }
    /// <summary>
    /// Plays a round of the game
    /// </summary>
    ///<returns>
    ///     +1: The user won a round
    ///      0: There was a tie
    ///     -1: The house won a round
    /// </returns>
    private sbyte PlayRound()
    {
       //Determine the card ranks for the player and house cards
       byte houseRank = DetermineCardRank(_houseCard);
       byte cardRank = DetermineCardRank(_playerCard);
       
       //Check which card has the higher rank to determine the winner
       if (cardRank > houseRank)
       {
           //Player won the round
           return 1;
       }
       else if (houseRank > cardRank)
       {
           //The house won the round
           return -1;
       }
       else
       {
           //Tie
           return 0;
       }
    }
/// <summary>
/// Deals the cards to the player and house when a new round starts
/// </summary>
    private void DealCards()
    {
        
    }

    private void SwitchCards()
    {
        
    }

    /// <summary>
    /// Determine the rank of tje card as used in the game. The Ace is the highest card
    /// </summary>
    /// <returns></returns>
    private byte DetermineCardRank(Card card)
    {
        //Check if the card is an ace
        byte cardRank = (card.Value == 1) ? (byte)14 : card.Value;
        return cardRank;
    }

    private void ShowRoundResult()
    {
        
    }

    private void ShowGameOver()
    {
        
    }
    #endregion
}