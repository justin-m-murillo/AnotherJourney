public class Falling : MovementState
{
    public Falling(PlayerSM stateMachine) : base("Falling", "P_Falling", stateMachine) { }

    public override void OnEnter()
    {
        base.OnEnter();
        _psm.psl.InvokeGravityScalar(_psm.RigBody, _psm.GravityFall);
        _psm.Anim.ChangeAnimationState(_animName);
    }

    public override void OnExit()
    {
        base.OnExit();

        _psm.psl.jumpCooldown = _psm.psl.defaultJumpCooldown;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (_psm.psl.IsGrounded(_psm.RigBody, _psm.GroundLayer))
        {
            stateMachine.ChangeState(_psm.idleState);
        }
    }
}
