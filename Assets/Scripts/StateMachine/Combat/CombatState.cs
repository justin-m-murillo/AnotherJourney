using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CombatState : BaseState
{
    protected CombatSM _combatSM;

    protected static float defaultComboDuration = 0.7f;
    protected static float comboDuration = defaultComboDuration;
    
    protected int comboIndex;

    protected bool hasNextCombo;

    public bool AnimComplete { get; set; }

    public CombatState(string name, CombatSM stateMachine) : base(name, stateMachine)
    {
        _combatSM = (CombatSM)stateMachine;

        controls.PlayerControlsMap.Attack.started += AttackStarted;
        //controls.PlayerControlsMap.Attack.performed += AttackPerformed;
        //controls.PlayerControlsMap.Attack.canceled += AttackCanceled;
    }

    public override void OnEnter()
    {
        base.OnEnter();

        AnimComplete = false;
    }

    public override void OnExit()
    {
        base.OnExit();

        AnimComplete = false;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        comboDuration = comboDuration > 0 ?
            comboDuration - Time.deltaTime
            : 0;

        if (comboDuration == 0)
        {
            stateMachine.ChangeState(_combatSM.combatIdleState);
        }
    }

    public int Index() { return comboIndex; }

    public void AttackStarted(InputAction.CallbackContext context) 
    {
        if (!AnimComplete) return;
        if (comboIndex+1 > _combatSM.attackStates.Length - 1) return;

        stateMachine.ChangeState(_combatSM.attackStates[comboIndex+1]);
    }
    //public void AttackPerformed(InputAction.CallbackContext context) { }
    //public virtual void AttackCanceled(InputAction.CallbackContext context) { }


}
