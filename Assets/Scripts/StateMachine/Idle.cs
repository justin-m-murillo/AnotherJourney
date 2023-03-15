using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : Grounded
{
    public Idle(MovementSM stateMachine) : base("Idle", stateMachine) 
    {
        _movementSM = (MovementSM)stateMachine;
    }

    public override void OnEnter()
    {
        base.OnEnter();

        _movementSM.HorizontalInput = 0f;

        _movementSM.Anim.TriggerIdle();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (Mathf.Abs(_horizontalInput) > Mathf.Epsilon)
        {
            stateMachine.ChangeState(_movementSM.movingState);
        }
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();

        // To eliminate sliding when approaching rest
        _movementSM.RigBody.AddForce(new Vector2
            (-(_movementSM.RigBody.velocity.x * _movementSM.DragFactor), 0),
            ForceMode2D.Force
        );
    }
}
