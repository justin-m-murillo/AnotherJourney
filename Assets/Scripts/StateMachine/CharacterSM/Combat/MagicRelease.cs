using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicRelease : CombatState
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
        _animationTimer = _psm.pdl.MAGIC_RELEASE_ANIM_DURATION;
    }

    public override void OnExit()
    {
        base.OnExit();

        _psm.pdl.CAN_MAGIC = true;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (!StateTimer(ref _animationTimer, 0, true)) return;
        stateMachine.ChangeState(_psm.idleState);
    }
}
