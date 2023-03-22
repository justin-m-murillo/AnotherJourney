using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowRelease : CombatState
{
    private float _animationTimer;

    public BowRelease(string stateName, string animName, PlayerSM stateMachine) :
        base(stateName, animName, stateMachine)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();

        Projectile p = PSM.LoadedProjectile.GetComponent<Projectile>();
        p.FireProjectile(PSM.pdl.IS_FACING_RIGHT);

        PSM.Anim.ChangeAnimationState(AnimName);
        _animationTimer = PSM.pdl.BOW_RELEASE_ANIM_DURATION;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (!Timer.StateTimer(ref _animationTimer, 0, true)) return; 
        PSM.ChangeState(PSM.idleState);
    }
}
