using UnityEngine;

public class CombatState : ContainerState
{
    public CombatState(string stateName, string animName, PlayerSM stateMachine) :
        base(stateName, animName, stateMachine)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        PSM.pdl.JUMP_COOLDOWN = PSM.pdl.BASE_JUMP_COOLDOWN; // jump cooldown prevents awkward animation canceling
    }
}
