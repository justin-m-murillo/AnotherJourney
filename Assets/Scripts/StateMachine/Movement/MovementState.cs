public class MovementState : ContainerState
{
    public override void Init(string stateName, string animName, PlayerSM stateMachine)
    {
        base.Init(stateName, animName, stateMachine);
        _psm.psl.jumped = false;
    }

    public override void OnEnter()
    {
        base.OnEnter();

        _psm.psl.ResetAttackParams();
        _psm.psl.previousYPosition = _psm.RigBody.position.y;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (_psm.psl.IsGrounded(_psm.RigBody, _psm.GroundLayer))
            _psm.psl.jumped = false;
    }

    public override void OnLateUpdate()
    {
        base.OnLateUpdate();

        _psm.psl.diffYPosition = _psm.RigBody.position.y - _psm.psl.previousYPosition;
        if (_psm.psl.diffYPosition < 0 && _psm.psl.comboDuration == 0)
        {
            stateMachine.ChangeState(_psm.fallingState);
        }
        _psm.psl.previousYPosition = _psm.RigBody.position.y;
    }


}
