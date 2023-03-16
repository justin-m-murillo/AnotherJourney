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

        //_psm.HorizontalInput = 0f;
        _psm.Anim.TriggerIdle();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (Mathf.Abs(static_horizontalInput) > Mathf.Epsilon)
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
