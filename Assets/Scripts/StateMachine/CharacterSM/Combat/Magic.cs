public class Magic : CombatState
{
    private float _animationTimer;

    public override void Init(string stateName, string animName, PlayerSM stateMachine)
    {
        base.Init(stateName, animName, stateMachine);
    }

    public override void OnEnter()
    {
        base.OnEnter();

        _psm.Anim.ChangeAnimationState(_animName);
        _psm.pdl.CAN_MAGIC = false;

        _animationTimer = _psm.pdl.MAGIC_ANIM_DURATION;

        if (!_psm.pdl.INVOKE_IS_GROUNDED(
            _psm.RigBody,
            _psm.GroundLayer))
            return;

        _psm.pdl.INVOKE_GROUND_DRAG(
            _psm.RigBody, 
            _psm.pdl.BASE_GROUND_DRAG);
    }

    public override void OnExit()
    {
        base.OnExit();

        _psm.pdl.CAN_MAGIC = true;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (!StateTimer(ref _animationTimer, 0, true)) return;
        stateMachine.ChangeState(_psm.idleState);
    }
}
