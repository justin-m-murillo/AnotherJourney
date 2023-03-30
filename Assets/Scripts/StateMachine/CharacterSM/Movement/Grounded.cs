public class Grounded : MovementState
{    
    public Grounded(string stateName, string animName, PlayerSM stateMachine) : 
        base(stateName, animName, stateMachine)
    {
        PSM.pdl.HORIZONTAL_INPUT = 0f;
        PSM.pdl.IS_FACING_RIGHT = true;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        PSM.RB2D.gravityScale = PSM.pdl.STORED_GRAVITY_SCALE;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        Timer.StateTimer(ref PSM.pdl.JUMP_COOLDOWN, 0, true);        
    }
}
