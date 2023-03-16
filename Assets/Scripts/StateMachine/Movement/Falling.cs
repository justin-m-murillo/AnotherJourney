using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : BaseState
{
    protected MovementSM _movementSM;
    public Falling(MovementSM stateMachine) : base("Falling", stateMachine) 
    { 
        _movementSM = (MovementSM)stateMachine;
    }

    public override void OnEnter()
    {
        base.OnEnter();

        _movementSM.Anim.TriggerFalling();
    }

    public override void OnExit()
    {
        base.OnExit();

        Grounded.jumpCooldown = Grounded.defaultJumpCooldown;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (_movementSM.IsGrounded())
        {
            stateMachine.ChangeState(_movementSM.movingState);
        }
    }
}
