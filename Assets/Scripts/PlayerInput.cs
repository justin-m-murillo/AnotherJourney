using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    //[SerializeField] StateMachine _stateMachine;
    [SerializeField] MovementSM _movementStateMachine;
    private PlayerControls playerControls;
    private float _horizontalInput;

    private void Start()
    {
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

    private void Update()
    {
        _movementStateMachine.HorizontalInput = _horizontalInput;
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
        _horizontalInput = context.ReadValue<Vector2>().x;
    }

    public void AttackInput(InputAction.CallbackContext context)
    {
        /*if (context.performed)
        {
            _pc.Attack();
        }*/
    }
}
