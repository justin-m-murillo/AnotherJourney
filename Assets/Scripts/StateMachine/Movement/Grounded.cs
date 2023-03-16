using UnityEngine;
using UnityEngine.InputSystem;

public class Grounded : ContainerState
{
    // to prevent double jump glitches 
    public static float defaultJumpCooldown = 0.02f;
    public static float jumpCooldown = defaultJumpCooldown; 

    public Grounded(string name, PlayerSM stateMachine) : base(name, stateMachine)
    {
        _psm = (PlayerSM)stateMachine;
        static_horizontalInput = 0f;
        playerControls.PlayerControlsMap.Jump.started += JumpStarted;
        playerControls.PlayerControlsMap.Jump.performed += JumpPerformed;
        playerControls.PlayerControlsMap.Jump.canceled += JumpCanceled;
    }

    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        static_horizontalInput = playerControls.PlayerControlsMap.Move.ReadValue<Vector2>().x;

        if (_psm.IsGrounded())
        {
            _psm.RigBody.gravityScale = _psm.GravityStored;
        }

        //Debug.Log(jumpCooldown.ToString("F3"));
        jumpCooldown = jumpCooldown > 0 ? 
            jumpCooldown - Time.deltaTime
            : 0f;
    }

    public void JumpStarted(InputAction.CallbackContext context)
    {
        if (jumpCooldown > 0f) return;
        if (!_psm.IsGrounded()) return;
        
        stateMachine.ChangeState(_psm.jumpState);
    }

    public void JumpPerformed(InputAction.CallbackContext context)
    {
        if (context.started)
            _psm.JumpPerformed = true;
    }

    public void JumpCanceled(InputAction.CallbackContext context)
    {
        if (!context.performed)
            _psm.InvokeGravityScaler();
    }
}
