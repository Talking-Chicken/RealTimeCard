using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    private string cardName;
    private int indexInHand;
    
    //getters & setters
    public int IndexInHand {get{return indexInHand;} set {indexInHand = value;}}
    
    public virtual void play() {
        gameObject.SetActive(false);
    }

    //set a indicator at the card position, when mouse is hover on it
    public void examineThisCard() {
        FindObjectOfType<PlayerControl>().selectCurrentCard(this);
        FindObjectOfType<PlayerControl>().Indicator.transform.position = transform.position;
    }

    //use this card, when player clicked on it
    public void selectThisCard() {
        FindObjectOfType<PlayerControl>().ChangeToMoveState();
    }
}
