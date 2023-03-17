using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowRelease : CombatState
{
    private float animationTimer;

    public BowRelease(PlayerSM stateMachine) : base("BowRelease", stateMachine) 
    { 
        _psm = stateMachine;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        animationTimer = _psm.psl.bowReleaseAnimTimer;
        _psm.Anim.TriggerBowRelease();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        animationTimer = animationTimer > 0 ?
            animationTimer - Time.deltaTime : 
            0;

        if (animationTimer == 0)
        {
            stateMachine.ChangeState(_psm.idleState);
        }
    }


}
