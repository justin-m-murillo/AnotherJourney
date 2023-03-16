using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : ContainerState
{
    protected PlayerSM _movementSM;
    private float _prevY;
    private float _yDiff;

    public Jump(PlayerSM stateMachine) : base("Jump", stateMachine) 
    {
        _movementSM = (PlayerSM)stateMachine;
    }

    public override void OnEnter()
    {
        base.OnEnter();

        _prevY = _movementSM.RigBody.position.y;

        Vector2 vel = _movementSM.RigBody.velocity;
        vel.y += _movementSM.JumpForce;
        _movementSM.RigBody.velocity = vel;

        _movementSM.Anim.TriggerJump();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        _yDiff = _movementSM.RigBody.position.y - _prevY;
        if (_yDiff < 0)
        {
            stateMachine.ChangeState(_movementSM.fallingState);
        }
        _prevY = _movementSM.RigBody.position.y;
    }


}
