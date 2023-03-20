public class Falling : MovementState
{
    public override void Init(string stateName, string animName, PlayerSM stateMachine)
    {
        base.Init(stateName, animName, stateMachine);
    }

    public override void OnEnter()
    {
        base.OnEnter();

        _psm.Anim.ChangeAnimationState(_animName);

        _psm.pdl.INVOKE_GRAVITY_SCALAR(_psm.RigBody, _psm.pdl.BASE_GRAVITY_SCALE);
    }

    public override void OnExit()
    {
        base.OnExit();

        _psm.pdl.JUMP_COOLDOWN = _psm.pdl.BASE_JUMP_COOLDOWN;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (!_psm.pdl.INVOKE_IS_GROUNDED(_psm.RigBody, _psm.GroundLayer)) return;
        stateMachine.ChangeState(_psm.idleState);
    }
}
