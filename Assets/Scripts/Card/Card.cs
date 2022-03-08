using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    protected PlayerControl player;
    private int indexInHand;
    
    //getters & setters
    public int IndexInHand {get{return indexInHand;} set {indexInHand = value;}}
    
    void Start() {
        player = FindObjectOfType<PlayerControl>();
    }

    public virtual void play() {
        gameObject.SetActive(false);
    }

    //set a indicator at the card position, when mouse is hover on it
    public void examineThisCard() {
        if (player.CurrentState == player.statePlay)
            FindObjectOfType<PlayerControl>().selectCurrentCard(this);
    }

    //use this card, when player clicked on it
    public void selectThisCard() {
        if (player.CurrentState == player.statePlay)
            FindObjectOfType<PlayerControl>().ChangeToMoveState();
    }
}
