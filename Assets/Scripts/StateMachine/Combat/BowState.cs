using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowState : CombatState
{

    public BowState(string name, PlayerSM stateMachine) : base(name, stateMachine)
    {
        _psm = stateMachine;
    }

    public override void OnEnter()
    {
        base.OnEnter();

        _psm.Anim.TriggerBow();
    }

}
