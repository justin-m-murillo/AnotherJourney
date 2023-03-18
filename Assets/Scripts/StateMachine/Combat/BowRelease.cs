using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowRelease : CombatState
{
    private float animationTimer;

    //public BowRelease(PlayerSM stateMachine) : base("BowRelease", "P_BowRelease", stateMachine) { }
    public override void Init(string stateName, string animName, PlayerSM stateMachine)
    {
        base.Init(stateName, animName, stateMachine);
    }

    public override void OnEnter()
    {
        base.OnEnter();
        animationTimer = _psm.psl.bowReleaseAnimTimer;
        _psm.Anim.ChangeAnimationState(_animName);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        animationTimer = animationTimer > 0 ?
            animationTimer - Time.deltaTime : 
            0;

        if (animationTimer != 0) return;
        stateMachine.ChangeState(_psm.idleState);
        
    }


}
