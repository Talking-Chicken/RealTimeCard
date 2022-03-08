using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//base state class for player state
public abstract class PlayerStateBase 
{
    public abstract void EnterState(PlayerControl player);
    public abstract void Update(PlayerControl player);
    public abstract void LeaveState(PlayerControl player);
}
