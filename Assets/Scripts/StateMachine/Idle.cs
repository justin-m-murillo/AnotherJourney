using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : Grounded
{
    public Idle(MovementSM stateMachine) : base("Idle", stateMachine) 
    {
        _movementSM = stateMachine;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        _movementSM.Anim.TriggerIdle();
        //HorizontalInput = 0f;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();


        if (Mathf.Abs(_movementSM.HorizontalInput) > Mathf.Epsilon)
        {
            stateMachine.ChangeState(_movementSM.movingState);
        }
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();

        _movementSM.RBody.velocity = new Vector2(0, _movementSM.RBody.velocity.y);
    }
}
