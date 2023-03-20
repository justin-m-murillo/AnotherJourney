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
        _psm.RigBody.gravityScale = _psm.pdl.STORED_GRAVITY_SCALE;

    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        StateTimer(ref _psm.pdl.JUMP_COOLDOWN, 0, true);        
    }
}
