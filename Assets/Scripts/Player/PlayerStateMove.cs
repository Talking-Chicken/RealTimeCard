using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//card will do their play function. Then, after cool down, go back to play state
public class PlayerStateMove : PlayerStateBase
{
    public override void EnterState(PlayerControl player) {
        if (player.CurrentCard != null) {
            player.CurrentCard.play();

            //discard card from hand, and draw a new card
            player.discard(player.CurrentCard.IndexInHand);
            player.draw(player.CurrentCard.IndexInHand);
            
            player.StartCoroutine(player.waitForCardCD());
        } else {
            Debug.LogWarning("current selecting card is null");
            player.ChangeState(player.statePlay);
        }
    }
    public override void Update(PlayerControl player) {
        
    }
    public override void LeaveState(PlayerControl player) {

    }
}
