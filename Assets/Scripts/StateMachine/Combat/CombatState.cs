using UnityEngine;

public class CombatState : ContainerState
{
    public CombatState(string name, string animName, PlayerSM stateMachine) : base(name, animName, stateMachine) { }

    public override void OnEnter()
    {
        base.OnEnter();
        _psm.psl.jumpCooldown = _psm.psl.defaultJumpCooldown; // jump cooldown prevents awkward animation canceling
        
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
