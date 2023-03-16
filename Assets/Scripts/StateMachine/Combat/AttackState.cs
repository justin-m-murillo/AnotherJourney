using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackState : CombatState
{
    public AttackState(CombatSM stateMachine, int index, bool hasNext) : base("Attack" + index, stateMachine)
    {
        _combatSM = (CombatSM)stateMachine;
        hasNextCombo = hasNext;
        comboIndex = index;
    }

    public override void OnEnter()
    {
        base.OnEnter();

        comboDuration = defaultComboDuration;
        _combatSM.Anim.TriggerAttack(name);
    }
}
