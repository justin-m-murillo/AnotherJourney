using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : BaseState
{
    private readonly MovementSM _movementSM;
    private float MAX_Y;
    private float _prevY;
    private float _ydiff;

    public Jump(MovementSM stateMachine) : base("Jump", stateMachine)
    {
        _movementSM = (MovementSM)stateMachine;
        
    }

    public override void OnEnter()
    {
        base.OnEnter();

        _prevY = _movementSM.RBody.position.y;
        MAX_Y = _movementSM.JumpForce;

        Vector2 vel = _movementSM.RBody.velocity;
        vel.y += _movementSM.JumpForce;
        _movementSM.RBody.velocity = vel;

        _movementSM.Anim.TriggerJump();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        _ydiff = _movementSM.RBody.position.y - _prevY;
        
        if (_ydiff < 0)
        {
            stateMachine.ChangeState(_movementSM.fallingState);
        }

        _prevY = _movementSM.RBody.position.y;
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();
        Vector2 vel = _movementSM.RBody.velocity;
        vel.y = Mathf.Clamp(vel.y, -MAX_Y, MAX_Y);
        _movementSM.RBody.velocity = vel;
    }
}
