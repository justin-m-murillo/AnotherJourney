public class MovementState : ContainerState
{
    public MovementState(string stateName, string animName, PlayerSM stateMachine) :
        base(stateName, animName, stateMachine)
    {
        PSM.pdl.IS_JUMP = false;
    }

    public override void OnEnter()
    {
        base.OnEnter();

        PSM.pdl.INVOKE_RESET_ATTACK_PARAMS();
        PSM.pdl.PREV_Y_POS = PSM.RB2D.position.y;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (PSM.pdl.INVOKE_IS_GROUNDED(PSM.RB2D, PSM.GroundLayer))
            PSM.pdl.IS_JUMP = false;
    }

    public override void OnLateUpdate()
    {
        base.OnLateUpdate();

        PSM.pdl.DIFF_Y = PSM.RB2D.position.y - PSM.pdl.PREV_Y_POS;
        if (PSM.pdl.DIFF_Y < 0 && PSM.pdl.COMBO_DURATION == 0)
        {
            PSM.ChangeState(PSM.fallingState);
        }
        PSM.pdl.PREV_Y_POS = PSM.RB2D.position.y;
    }
}
