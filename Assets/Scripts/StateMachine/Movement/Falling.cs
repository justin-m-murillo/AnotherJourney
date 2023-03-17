using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MovementState
{
    public Falling(PlayerSM stateMachine) : base("Falling", stateMachine) 
    { 
        _psm = (PlayerSM)stateMachine;
    }

    public override void OnEnter()
    {
        base.OnEnter();

        _psm.Anim.TriggerFalling();
    }

    public override void OnExit()
    {
        base.OnExit();

        _psm.psl.jumpCooldown = _psm.psl.defaultJumpCooldown;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (_psm.psl.IsGrounded(_psm.RigBody, _psm.GroundLayer))
        {
            stateMachine.ChangeState(_psm.movingState);
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
