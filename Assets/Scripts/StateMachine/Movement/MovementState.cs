using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementState : ContainerState
{
    public MovementState(string name, PlayerSM stateMachine) : base(name, stateMachine)
    {
        _psm = (PlayerSM)stateMachine;
        _psm.psl.jumped = false;

    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (Grounded.IsGrounded())
            _psm.psl.jumped = false;
    }

    
}
