using UnityEngine;
using UnityEngine.InputSystem;

public class Grounded : MovementState
{
    public Grounded(string name, PlayerSM stateMachine) : base(name, stateMachine)
    {
        _psm = (PlayerSM)stateMachine;
        _psm.psl.horizontalInput = 0f;
        _psm.psl.isFacingRight = true;
    }

    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (_psm.psl.IsGrounded(_psm.RigBody, _psm.GroundLayer))
        {
            _psm.RigBody.gravityScale = _psm.GravityStored;
        }

        //Debug.Log(jumpCooldown.ToString("F3"));
        _psm.psl.jumpCooldown = _psm.psl.jumpCooldown > 0 ? 
            _psm.psl.jumpCooldown - Time.deltaTime
            : 0f;
    }
}
