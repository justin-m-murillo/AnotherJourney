using UnityEngine;

public class Idle : Grounded
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

        if (Mathf.Abs(_psm.pdl.HORIZONTAL_INPUT) < Mathf.Epsilon) return;
        stateMachine.ChangeState(_psm.movingState);
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();
        _psm.pdl.INVOKE_GROUND_DRAG(_psm.RigBody, _psm.pdl.BASE_GROUND_DRAG);
    }
}
