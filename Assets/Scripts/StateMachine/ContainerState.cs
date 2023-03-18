public class ContainerState : BaseState
{
    protected PlayerSM _psm;
    protected string _animName;

    public ContainerState(string name, string animName, PlayerSM stateMachine) : base(name, stateMachine)
    {
        _psm = stateMachine;
        _animName = animName;
    }
}
