using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : Grounded
{
    public Idle(PlayerSM stateMachine) : base("Idle", stateMachine) 
    {
        _psm = (PlayerSM)stateMachine;
    }

    public override void OnEnter()
    {
        base.OnEnter();

        _psm.psl.ResetAttackParams();
        _psm.Anim.TriggerIdle();
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
        ApplyGroundDrag();
    }
}
