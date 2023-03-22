public class ProjectileState : BaseState
{
    public ProjSM PrSM { get; protected set; }

    public ProjectileState(string stateName, string animName, ProjSM stateMachine) :
        base(stateName, animName, stateMachine)
    {
        PrSM = stateMachine;
    }
}
