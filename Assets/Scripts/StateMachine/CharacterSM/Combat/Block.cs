using UnityEngine;

public class Block : CombatState
{
    public override void Init(string stateName, string animName, PlayerSM stateMachine)
    {
        base.Init(stateName, animName, stateMachine);
    }

    public override void OnEnter()
    {
        base.OnEnter();

        _psm.Anim.ChangeAnimationState(_animName);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (_psm.pdl.IS_BLOCKING) return;
        stateMachine.ChangeState(_psm.idleState);
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();

        if (!_psm.pdl.INVOKE_IS_GROUNDED(_psm.RigBody, _psm.GroundLayer)) return;
        _psm.pdl.INVOKE_SET_MODIFIED_MOVE_SPEED(_psm.RigBody, _psm.pdl.BLOCK_WALK_SPEED);
    }
}
