using UnityEngine;

public class CombatState : ContainerState
{
    public CombatState(string name, PlayerSM stateMachine) : base(name, stateMachine) { }

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
