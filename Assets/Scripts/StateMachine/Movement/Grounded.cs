using UnityEngine;
using UnityEngine.InputSystem;

public class Grounded : BaseState
{
    protected MovementSM _movementSM;
    protected float _horizontalInput;

    // to prevent double jump glitches 
    public static float defaultJumpCooldown = 0.02f;
    public static float jumpCooldown = defaultJumpCooldown; 

    public Grounded(string name, MovementSM stateMachine) : base(name, stateMachine)
    {
        _movementSM = (MovementSM)stateMachine;
        _horizontalInput = 0f;
        controls.PlayerControlsMap.Jump.started += JumpStarted;
        controls.PlayerControlsMap.Jump.performed += JumpPerformed;
        controls.PlayerControlsMap.Jump.canceled += JumpCanceled;
    }

    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        _horizontalInput = controls.PlayerControlsMap.Move.ReadValue<Vector2>().x;

        if (_movementSM.IsGrounded())
        {
            _movementSM.RigBody.gravityScale = _movementSM.GravityStored;
        }

        //Debug.Log(jumpCooldown.ToString("F3"));
        jumpCooldown = jumpCooldown > 0 ? 
            jumpCooldown - Time.deltaTime
            : 0f;
    }

    public void JumpStarted(InputAction.CallbackContext context)
    {
        if (jumpCooldown > 0f) return;
        if (!_movementSM.IsGrounded()) return;
        
        stateMachine.ChangeState(_movementSM.jumpState);
    }

    public void JumpPerformed(InputAction.CallbackContext context)
    {
        if (context.started)
            _movementSM.JumpPerformed = true;
    }

    public void JumpCanceled(InputAction.CallbackContext context)
    {
        if (!context.performed)
            _movementSM.InvokeGravityScaler();
    }
}
