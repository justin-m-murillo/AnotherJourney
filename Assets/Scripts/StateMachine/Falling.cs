using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : BaseState
{
    private readonly MovementSM _movementSM;

    public Falling(MovementSM stateMachine) : base("Falling", stateMachine)
    {
        _movementSM = stateMachine;
    }

    public override void OnEnter()
    {
        base.OnEnter();

        Vector2 vel = _movementSM.RBody.velocity;
        vel.y -= _movementSM.JumpForce * _movementSM.JumpMultiplier;
        _movementSM.RBody.velocity = vel;

        _movementSM.Anim.TriggerFalling();
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (_movementSM.IsGrounded())
        {
            stateMachine.ChangeState(_movementSM.idleState);
        }
    }
}
