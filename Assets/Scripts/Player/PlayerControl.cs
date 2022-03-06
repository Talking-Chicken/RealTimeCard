using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private int handSize;
    [SerializeField, Header("prefab")] private GameObject card;
    [SerializeField] private GameObject canvas;
    public List<GameObject> hand = new List<GameObject>();
    private Card currentCard;
    [SerializeField, Header("card deck")] private List<GameObject> backgrounds = new List<GameObject>();

    //deck is for draw, discard deck will be shuffled and put back to deck
    private Stack<GameObject> deck = new Stack<GameObject>(), discardDeck = new Stack<GameObject>();
    [Header("card deck")]public List<GameObject> playerDeck; //all cards that player have

    //player movements
    [SerializeField, Header("movement")]private Collider2D bound;
    [SerializeField] private float speed;
    private Vector2 destination;

    //getters & setters
    public int HandSize {get {return handSize;} private set {handSize = value;}}
    public Card CurrentCard {get {return currentCard;} private set {currentCard = value;}}
    public Vector2 Destination {get {return destination;} private set {destination = value;}}
    public float Speed {get {return speed;} private set {speed = value;}}
    public List<GameObject> Hand {get {return hand;} set {hand = value;}}
    public Stack<GameObject> DiscardDeck {get {return discardDeck;} set {discardDeck = value;}}

    // State
    // private BoardState state;
    private PlayerStateBase currentState;
    public PlayerStateIdle stateIdle = new PlayerStateIdle();
    public PlayerStateSetUp stateSetUp = new PlayerStateSetUp();
    public PlayerStatePlay statePlay = new PlayerStatePlay();
    public PlayerStateMove stateMove = new PlayerStateMove();

    //transition state functions
    public void ChangeToMoveState() {ChangeState(stateMove);}

    public void ChangeState(PlayerStateBase newState)
    {
        if (newState != currentState) {
            if (currentState != null)
            {
                currentState.LeaveState(this);
            }

            currentState = newState;

            if (currentState != null)
            {
                currentState.EnterState(this);
            }
        }
    }
    void Start()
    {
        Destination = transform.position;
        currentState = stateIdle;
        for (int i = 0; i < playerDeck.Count; i++) {
            deck.Push(playerDeck[i]);
            playerDeck[i].GetComponent<Card>().IndexInHand = i;
            deck.Peek().SetActive(false);
        }
        HandSize = 4;
        ChangeState(stateSetUp);
    }

    void Update()
    {
        currentState.Update(this);
    }

    void FixedUpdate() {
        moveTowardDestination();
    }

    //draw a card to fill the empty position of player's hand
    public void draw(int position) {
        if (position >= handSize) {
            Debug.LogWarning("trying to draw card to position (" + position + ") bigger than hand size");
        } else{
            hand.Add(deck.Pop());
            hand[position].SetActive(true);
            hand[position].transform.position = backgrounds[position].transform.position;

            hand[position].GetComponent<Card>().IndexInHand = position;
        }
    }

    //set a target destination to player, transition to move state
    public void setDestination(bool isMovingRight) {
        if (isMovingRight)
            Destination = Vector2.right * 5;
        else
            Destination = Vector2.left * 5;
    }

    //using lerp to move to destination, if haven't reach destination
    public void moveTowardDestination() {
        if (Vector2.Distance(transform.position, Destination) > 0.1f) {
            transform.position = Vector2.MoveTowards(transform.position, Destination, Time.deltaTime * Speed);
        }
    }

    //set current card to the card that player clicked on
    public void selectCurrentCard(Card selectingCard) {
        CurrentCard = selectingCard;
    }

    //after cd, change to play state
    public IEnumerator waitForCardCD() {
        yield return new WaitForSeconds(2.0f);
        ChangeState(statePlay);
    }
}
