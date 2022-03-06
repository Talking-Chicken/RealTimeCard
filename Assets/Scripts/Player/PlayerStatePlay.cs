using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//player will select card and play card in this state
public class PlayerStatePlay : PlayerStateBase
{
    public override void EnterState(PlayerControl player) {
        for (int i = 0; i < player.Hand.Count; i++) {
                player.Hand[i].GetComponent<EventTrigger>().enabled = true;
        }
    }
    public override void Update(PlayerControl player) {

    }
    public override void LeaveState(PlayerControl player) {
        for (int i = 0; i < player.Hand.Count; i++) {
                player.Hand[i].GetComponent<EventTrigger>().enabled = false;
        }
    }
}
