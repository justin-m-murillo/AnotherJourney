using UnityEngine;
using UnityEngine.InputSystem;

public class Grounded : MovementState
{
    // to prevent double jump glitches 
    public static float static_defaultJumpCooldown = 0.02f;
    public static float static_jumpCooldown = static_defaultJumpCooldown;

    public static float static_horizontalInput;
    public static bool static_isFacingRight;

    public Grounded(string name, PlayerSM stateMachine) : base(name, stateMachine)
    {
        _psm = (PlayerSM)stateMachine;
        static_horizontalInput = 0f;
        static_isFacingRight = true;

        
    }

    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        static_horizontalInput = playerControls.PlayerControlsMap.Move.ReadValue<Vector2>().x;

        if (IsGrounded())
        {
            _psm.RigBody.gravityScale = _psm.GravityStored;
        }

        //Debug.Log(jumpCooldown.ToString("F3"));
        static_jumpCooldown = static_jumpCooldown > 0 ? 
            static_jumpCooldown - Time.deltaTime
            : 0f;
    }

    /// <summary>
    /// Checks if the character's collider is touching the ground layer
    /// </summary>
    /// <returns>True if touching a ground layer, false otherwise</returns>
    public static bool IsGrounded()
    {
        return _psm.RigBody.IsTouchingLayers(_psm.GroundLayer);
    }

    public static void ApplyGroundDrag(float mult = 1f)
    {
        // To eliminate sliding when approaching rest
        _psm.RigBody.AddForce(new Vector2
            (-(_psm.RigBody.velocity.x * (_psm.DragFactor * mult)), 0),
            ForceMode2D.Force
        );
    }
}
