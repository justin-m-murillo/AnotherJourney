using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public BaseState currentState;

    // Start is called before the first frame update
    void Start()
    {
        currentState = GetInitialState();
        if (currentState == null) return;
        currentState.OnEnter();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == null) return;
        currentState.OnUpdate();
    }

    void LateUpdate()
    {
        if (currentState == null) return;
        currentState.OnLateUpdate();
    }

    void FixedUpdate()
    {
        if (currentState == null) return;
        currentState.OnFixedUpdate();    
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

    private void OnGUI()
    {
        string content = currentState != null ? currentState.Name : "(no current state)";
        GUILayout.Label($"<color='black'><size=40>{content}</size></color>");
    }
}
