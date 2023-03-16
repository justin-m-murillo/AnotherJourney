using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSM : StateMachine
{
    [HideInInspector]
    public CombatIdle combatIdleState;
    [HideInInspector]
    public AttackState attackOneState;
    [HideInInspector]
    public AttackState attackTwoState;
    [HideInInspector]
    public AttackState attackThreeState;
    [HideInInspector]
    public AttackState attackFourState;
    [HideInInspector]
    public AttackState attackFiveState;

    [HideInInspector]
    public CombatState[] attackStates;

    private void Awake()
    {
        combatIdleState = new (this);
        attackOneState = new (this, combatIdleState.Index() + 1, true);
        attackTwoState = new (this, combatIdleState.Index() + 2, false);
        attackThreeState = new(this, combatIdleState.Index() + 3, false);
        attackFourState = new(this, combatIdleState.Index() + 4, false);
        attackFiveState = new(this, combatIdleState.Index() + 5, false);

        attackStates = new CombatState[]
        {
            combatIdleState,
            attackOneState,
            attackTwoState,
            attackThreeState,
            attackFourState,
            attackFiveState
        };

        CharacterTransform = _characterTransform;
        RigBody = _rb;
        Anim = _anim;
    }

    /// <summary>
    /// Returns FSM to initial state
    /// </summary>
    /// <returns><typeparam name="CombatIdle"></typeparam>combatIdleState</returns>
    protected override BaseState GetInitialState()
    {
        return combatIdleState;
    }

    private void OnGUI()
    {
        string content = currentState != null ? currentState.name : "(no current state)";
        GUILayout.Label($"<color='black'><size=40>{content}</size></color>");
    }

}
