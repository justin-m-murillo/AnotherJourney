public class Falling : MovementState
{
    public Falling(string stateName, string animName, PlayerSM stateMachine) :
        base(stateName, animName, stateMachine)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();

        PSM.Anim.ChangeAnimationState(AnimName);

        PSM.pdl.INVOKE_GRAVITY_SCALAR(PSM.RB2D, PSM.pdl.BASE_GRAVITY_SCALE);
    }

    public override void OnExit()
    {
        base.OnExit();

        PSM.pdl.JUMP_COOLDOWN = PSM.pdl.BASE_JUMP_COOLDOWN;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (!PSM.pdl.INVOKE_IS_GROUNDED(PSM.RB2D, PSM.GroundLayer)) return;
        PSM.ChangeState(PSM.idleState);
    }
}
