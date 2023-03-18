using UnityEngine;

public class Grounded : MovementState
{
    public override void Init(string stateName, string animName, PlayerSM stateMachine)
    {
        base.Init(stateName, animName, stateMachine);
        _psm.pdl.HORIZONTAL_INPUT = 0f;
        _psm.pdl.IS_FACING_RIGHT = true;
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
        _psm.pdl.JUMP_COOLDOWN = _psm.pdl.JUMP_COOLDOWN > 0 ? 
            _psm.pdl.JUMP_COOLDOWN - Time.deltaTime
            : 0f;
    }
}
