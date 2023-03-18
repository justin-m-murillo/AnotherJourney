using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MovementState
{
    public Jump(PlayerSM stateMachine) : base("Jump", "P_Jump", stateMachine) { }

    public override void OnEnter()
    {
        base.OnEnter();

        Vector2 vel = _psm.RigBody.velocity;
        vel.y += _psm.JumpForce;
        _psm.RigBody.velocity = vel;

        _psm.Anim.ChangeAnimationState(_animName);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

    }
}
