using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//set up the initial hand deck
public class PlayerStateSetUp : PlayerStateBase
{
    public override void EnterState(PlayerControl player) {
        for (int i = 0; i < player.HandSize; i++) {
            player.draw(i);
        }

        player.ChangeState(player.statePlay);
    }
    public override void Update(PlayerControl player) {

    }
    public override void LeaveState(PlayerControl player) {

    }
}
