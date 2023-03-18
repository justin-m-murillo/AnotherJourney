using UnityEngine;

public class BaseState : ScriptableObject
{
    public string stateName;
    protected StateMachine stateMachine;

    public virtual void Init(
        string stateName, 
        StateMachine stateMachine) 
    { 
        this.stateName = stateName;
        this.stateMachine = stateMachine;
    }
    public virtual void OnEnter() { }
    public virtual void OnFixedUpdate() { }
    public virtual void OnUpdate() { }
    public virtual void OnLateUpdate() { }
    public virtual void OnExit() { }

    public StateMachine GetStateMachine() { return stateMachine; }
}
