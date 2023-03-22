public class ContainerState : BaseState
{
    public PlayerSM PSM { get; protected set; }
    
    public ContainerState(string stateName, string animName, PlayerSM stateMachine) :
        base(stateName, animName, stateMachine)
    {
        PSM = stateMachine;
    }
}
