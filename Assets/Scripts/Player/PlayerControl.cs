using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private int handSize;

    private List<Card> hand = new List<Card>();

    //deck is for draw, discard deck will be shuffled and put back to deck
    private Queue<Card> deck = new Queue<Card>(), discardDeck = new Queue<Card>(); 

    public List<Card> playerDeck; //all cards that player have

    //getters & setters
    public int HandSize {get {return handSize;} private set {handSize = value;}}

    // State
    // private BoardState state;
    private PlayerStateBase currentState;
    public PlayerStateSetUp stateSetUp = new PlayerStateSetUp();
    public PlayerStatePlay statePlay = new PlayerStatePlay();
    public PlayerStateMove stateMove = new PlayerStateMove();


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
        for (int i = 0; i < playerDeck.Count; i++) {
            deck.Enqueue(playerDeck[i]);
        }
        HandSize = 4;
        ChangeState(stateSetUp);
    }

    void Update()
    {
        currentState.Update(this);
    }

    public void draw(int position) {
        if (position >= handSize) {
            Debug.LogWarning("trying to draw card to position (" + position + ") bigger than hand size");
        } else if (hand[position] != null) {
            Debug.LogWarning("trying to draw to a already existed position");
        } else{
            hand[position] = deck.Dequeue();
        }
    }
}
