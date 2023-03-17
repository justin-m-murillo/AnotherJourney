using UnityEngine;

public class Grounded : MovementState
{
    public Grounded(string name, PlayerSM stateMachine) : base(name, stateMachine)
    {
        _psm.psl.horizontalInput = 0f;
        _psm.psl.isFacingRight = true;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        _psm.RigBody.gravityScale = _psm.GravityStored;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        //Debug.Log(jumpCooldown.ToString("F3"));
        _psm.psl.jumpCooldown = _psm.psl.jumpCooldown > 0 ? 
            _psm.psl.jumpCooldown - Time.deltaTime
            : 0f;
    }
}
