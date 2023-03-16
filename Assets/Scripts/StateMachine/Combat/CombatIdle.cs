using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CombatIdle : CombatState
{
    public CombatIdle(CombatSM stateMachine) : base("Combat-Idle", stateMachine)
    { 
        _combatSM = (CombatSM)stateMachine;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        AnimComplete = true;
    }

    /*public override void AttackStarted(InputAction.CallbackContext context)
    {
        base.AttackStarted(context);

        stateMachine.ChangeState(_combatSM.attackStates[comboIndex]);
    }*/
}
