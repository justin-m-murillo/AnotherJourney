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

        if (Mathf.Abs(_psm.psl.horizontalInput) > Mathf.Epsilon)
        {
            stateMachine.ChangeState(_psm.movingState);
        }
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();
        _psm.psl.ApplyGroundDrag(_psm.RigBody, _psm.DragFactor);
    }
}
