using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : BaseState
{
    protected MovementSM _movementSM;

    public Grounded(string name, MovementSM stateMachine) : base(name, stateMachine)
    {
        _movementSM = (MovementSM)stateMachine;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (_movementSM.Jumped && _movementSM.IsGrounded())
        {
            stateMachine.ChangeState(_movementSM.jumpState);
        }
    }
}
