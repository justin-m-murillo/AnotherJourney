using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MovementState
{
    protected PlayerSM _movementSM;
    public Falling(PlayerSM stateMachine) : base("Falling", stateMachine) 
    { 
        _movementSM = (PlayerSM)stateMachine;
    }

    public override void OnEnter()
    {
        base.OnEnter();

        _movementSM.Anim.TriggerFalling();
    }

    public override void OnExit()
    {
        base.OnExit();

        Grounded.static_jumpCooldown = Grounded.static_defaultJumpCooldown;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (Grounded.IsGrounded())
        {
            stateMachine.ChangeState(_movementSM.movingState);
        }
    }

    /// <summary>
    /// Adjusts the Rigidbody2D's gravityScale to GravityFall's value
    /// </summary>
    public static void InvokeGravityScalar()
    {
        _psm.RigBody.gravityScale = _psm.GravityFall;
    }
}
