using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackState : CombatState
{
    public AttackState(PlayerSM stateMachine, int index) : base("Attack" + (index + 1), stateMachine)
    {
        _psm = (PlayerSM)stateMachine;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        
        static_comboDuration = static_defaultComboDuration;
        _psm.Anim.TriggerAttack(name);
        static_comboIndex++;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

    }

    private void AttackPush()
    {

    }
}
