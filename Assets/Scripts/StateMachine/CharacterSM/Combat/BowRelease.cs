using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowRelease : CombatState
{
    private float _animationTimer;

    public override void Init(string stateName, string animName, PlayerSM stateMachine)
    {
        base.Init(stateName, animName, stateMachine);
    }

    public override void OnEnter()
    {
        base.OnEnter();

        Projectile p = _psm.LoadedProjectile.GetComponent<Projectile>();
        p.FireProjectile(_psm.pdl.IS_FACING_RIGHT);

        _psm.Anim.ChangeAnimationState(_animName);
        _animationTimer = _psm.pdl.BOW_RELEASE_ANIM_DURATION;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (!StateTimer(ref _animationTimer, 0, true)) return; 
        stateMachine.ChangeState(_psm.idleState);
        
    }


}
