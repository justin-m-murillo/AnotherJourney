using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public BaseState currentState;

    [Tooltip("Character transform")]
    [SerializeField] protected Transform _characterTransform;
    [Tooltip("Ground layer mask")]
    [SerializeField] protected LayerMask _groundLayer;
    [Tooltip("Character rigidbody")]
    [SerializeField] protected Rigidbody2D _rb;
    [Tooltip("Character AnimController script (for animation control)")]
    [SerializeField] protected AnimController _anim;

    /// <summary>
    /// Character Transform property
    /// </summary>
    public Transform CharacterTransform { get; protected set; }

    /// <summary>
    /// Character's Rigidbody2D property
    /// </summary>
    public Rigidbody2D RigBody { get; protected set; }

    /// <summary>
    /// Character's AnimController script object (for animation control)
    /// </summary>
    public AnimController Anim { get; protected set; }

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
