using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCard : Card
{
    [SerializeField] private bool isMovingRight;
    public override void play()
    {
        FindObjectOfType<PlayerControl>().setDestination(isMovingRight);
        base.play();
    }
}
