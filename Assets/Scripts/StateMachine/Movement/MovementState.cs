public class MovementState : ContainerState
{
    public override void Init(string stateName, string animName, PlayerSM stateMachine)
    {
        base.Init(stateName, animName, stateMachine);
        _psm.pdl.IS_JUMP = false;
    }

    public override void OnEnter()
    {
        base.OnEnter();

        _psm.pdl.INVOKE_RESET_ATTACK_PARAMS();
        _psm.pdl.PREV_Y_POS = _psm.RigBody.position.y;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (_psm.pdl.INVOKE_IS_GROUNDED(_psm.RigBody, _psm.GroundLayer))
            _psm.pdl.IS_JUMP = false;
    }

    public override void OnLateUpdate()
    {
        base.OnLateUpdate();

        _psm.pdl.DIFF_Y = _psm.RigBody.position.y - _psm.pdl.PREV_Y_POS;
        if (_psm.pdl.DIFF_Y < 0 && _psm.pdl.COMBO_DURATION == 0)
        {
            stateMachine.ChangeState(_psm.fallingState);
        }
        _psm.pdl.PREV_Y_POS = _psm.RigBody.position.y;
    }


}
