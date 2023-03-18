using UnityEngine;

public class CombatState : ContainerState
{
    public override void Init(string stateName, string animName, PlayerSM stateMachine)
    {
        base.Init(stateName, animName, stateMachine);
    }

    public override void OnEnter()
    {
        base.OnEnter();
        _psm.pdl.JUMP_COOLDOWN = _psm.pdl.DEFAULT_JUMP_COOLDOWN; // jump cooldown prevents awkward animation canceling
        
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }
}
