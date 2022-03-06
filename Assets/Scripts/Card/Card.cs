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

    public void selectThisCard() {
        FindObjectOfType<PlayerControl>().selectCurrentCard(this);
        FindObjectOfType<PlayerControl>().ChangeToMoveState();
    }
}
