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

        if (_psm.psl.isBlocking) return;
        stateMachine.ChangeState(_psm.idleState);
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();

        if (!_psm.psl.IsGrounded(_psm.RigBody, _psm.GroundLayer)) return;
        _psm.psl.SetModifiedMovementSpeed(_psm.RigBody, _psm.psl.blockWalkSpeed);
    }
}
