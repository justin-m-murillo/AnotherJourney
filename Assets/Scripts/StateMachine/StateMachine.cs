using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public BaseState currentState;

    // Start is called before the first frame update
    void Start()
    {
        currentState = GetInitialState();
        currentState?.OnEnter();
    }

    // Update is called once per frame
    void Update()
    {
        currentState?.OnUpdate();
    }

    void LateUpdate()
    {
        currentState?.OnLateUpdate();
    }

    void FixedUpdate()
    {
        currentState?.OnFixedUpdate();    
    }

    public void ChangeState(BaseState newState)
    {
        currentState.OnExit();

        currentState = newState;
        currentState.OnEnter();
    }

    protected virtual BaseState GetInitialState()
    {
        return null;
    }

    /*private void OnGUI()
    {
        string content = currentState != null ? currentState.name : "(no current state)";
        GUILayout.Label($"<color='black'><size=40>{content}</size></color>");
    }*/
}
