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

        _movementSM.Anim.TriggerFalling();
    }

    public override void OnExit()
    {
        base.OnExit();
        _movementSM.Jumped = false;
        _movementSM.JumpPerformed = false;
        _movementSM.RBody.gravityScale = _movementSM.GravityStored;

    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();

        if (_movementSM.IsGrounded())
        {
            stateMachine.ChangeState(_movementSM.idleState);
        }
    }
}
