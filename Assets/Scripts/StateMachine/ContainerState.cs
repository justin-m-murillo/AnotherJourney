using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

public class ContainerState : BaseState
{
    protected static PlayerSM _psm;

    public ContainerState(string name, PlayerSM stateMachine) : base(name, stateMachine)
    {
        _psm = stateMachine;
    }
}
