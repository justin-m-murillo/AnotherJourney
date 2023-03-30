public class BaseState
{
    public string Name { get; set; }
    public string AnimName { get; set; }
    public StateMachine SMachine { get; set; }

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
