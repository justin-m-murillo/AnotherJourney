public class ContainerState : BaseState
{
    protected PlayerSM _psm;
    protected string _animName;

    public virtual void Init(string stateName, string animName, PlayerSM stateMachine)
    {
        base.Init(stateName, stateMachine);
        _psm = stateMachine;
        _animName = animName;
    }
}
