public class Block : CombatState
{
    public Block(string stateName, string animName, PlayerSM stateMachine) :
        base(stateName, animName, stateMachine)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();

        PSM.Anim.ChangeAnimationState(AnimName);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (PSM.pdl.IS_BLOCKING) return;
        PSM.ChangeState(PSM.idleState);
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();

        if (!PSM.pdl.INVOKE_IS_GROUNDED(PSM.RB2D, PSM.GroundLayer)) return;
        PSM.pdl.INVOKE_SET_MODIFIED_MOVE_SPEED(PSM.RB2D, PSM.pdl.BLOCK_WALK_SPEED);
    }
}
