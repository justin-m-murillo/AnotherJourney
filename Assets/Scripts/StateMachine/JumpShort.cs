using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpShort : BaseState
{
    private readonly MovementSM _movementSM;

    public JumpShort(MovementSM stateMachine) : base("Jump", stateMachine)
    {
        _movementSM = (MovementSM)stateMachine;
    }

    public override void OnEnter()
    {
        base.OnEnter();

        Vector2 vel = _movementSM.RBody.velocity;
        vel.y += _movementSM.JumpForce * 0.5f;
        _movementSM.RBody.velocity = vel;

        _movementSM.Anim.TriggerJump();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (_movementSM.RBody.velocity.y < 0f)
        {
            stateMachine.ChangeState(_movementSM.fallingState);
        }
    }
}
