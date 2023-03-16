using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

public class ContainerState : BaseState
{
    protected static PlayerSM _psm;
    protected static PlayerControls playerControls;

    public ContainerState(string name, PlayerSM stateMachine) : base(name, stateMachine)
    {
        _psm = stateMachine;

        playerControls = new();
        playerControls.Enable();
    }
}
