public class BaseState : IState
{
    public string Name { get; protected set; }
    public string AnimName { get; protected set; }
    public StateMachine SMachine { get; protected set; }

    public BaseState(string stateName, string animName, StateMachine sMachine)
    {
        Name = stateName;
        AnimName = animName;
        SMachine = sMachine;
    }

    public virtual void OnEnter() { }
    public virtual void OnExit() { }
    public virtual void OnUpdate() { }
    public virtual void OnFixedUpdate() { }
    public virtual void OnLateUpdate() { }
}
