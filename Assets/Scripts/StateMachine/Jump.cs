using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : BaseState
{
    private readonly MovementSM _movementSM;
    //private float _prevY;
    //private float _ydiff;

    public Jump(MovementSM stateMachine) : base("Jump", stateMachine)
    {
        _movementSM = (MovementSM)stateMachine;
    }

    public override void OnEnter()
    {
        base.OnEnter();

        //_prevY = _movementSM.RBody.velocity.y;

        /*Vector2 vel = _movementSM.RBody.velocity;
        vel.y += _movementSM.JumpForce * _movementSM.JumpMultiplier;
        _movementSM.RBody.velocity = vel;*/

        _movementSM.Anim.TriggerJump();
    }

    public override void OnExit()
    {
        base.OnExit();

        _movementSM.JumpMultiplier = 0f;
        //_movementSM.Jumped = false;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

       // _ydiff = _movementSM.RBody.velocity.y - _prevY;

        if (!_movementSM.Jumped)
        {
            stateMachine.ChangeState(_movementSM.fallingState);
        }

        //_prevY = _movementSM.RBody.velocity.y;
    }
}
