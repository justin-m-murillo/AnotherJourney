using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementState : ContainerState
{
    public MovementState(string name, PlayerSM stateMachine) : base(name, stateMachine)
    {
        _psm.psl.jumped = false;
    }

    public override void OnEnter()
    {
        base.OnEnter();

        _psm.psl.previousYPosition = _psm.RigBody.position.y;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (_psm.psl.IsGrounded(_psm.RigBody, _psm.GroundLayer))
            _psm.psl.jumped = false;

        _psm.psl.diffYPosition = _psm.RigBody.position.y - _psm.psl.previousYPosition;
        if (_psm.psl.diffYPosition < 0)
        {
            stateMachine.ChangeState(_psm.fallingState);
        }
        _psm.psl.previousYPosition = _psm.RigBody.position.y;
    }

    
}
