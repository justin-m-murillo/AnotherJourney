using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    //[SerializeField] StateMachine _stateMachine;
    [SerializeField] MovementSM _movementStateMachine;
    private PlayerControls playerControls;

    private void Start()
    {
        //playerControls.PlayerControlsMap.Enable();
        playerControls.PlayerControlsMap.Jump.started += JumpStarted;
        playerControls.PlayerControlsMap.Jump.performed += JumpPerformed;
        playerControls.PlayerControlsMap.Jump.canceled += JumpCanceled;
    }

    private void OnEnable()
    {
        playerControls = new PlayerControls();
        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }

    public void JumpStarted(InputAction.CallbackContext context)
    {
        if (!_movementStateMachine.Jumped)
            _movementStateMachine.InvokeJump();
    }

    public void JumpPerformed(InputAction.CallbackContext context)
    {
        if (_movementStateMachine.Jumped)
            _movementStateMachine.JumpPerformed = true;
    }

    public void JumpCanceled(InputAction.CallbackContext context)
    {
        if (!_movementStateMachine.JumpPerformed)
        {
            _movementStateMachine.InvokeGravityScaler();
        }
    }

    public void MoveInput(InputAction.CallbackContext context)
    {
        _movementStateMachine.HorizontalInput = context.ReadValue<Vector2>().x;
    }

    public void AttackInput(InputAction.CallbackContext context)
    {
        /*if (context.performed)
        {
            _pc.Attack();
        }*/
    }
}
