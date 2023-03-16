using System.Diagnostics;
using UnityEngine.InputSystem;

public class ContainerState : BaseState
{
    protected static float static_defaultComboDuration = 0.7f;
    protected static float static_comboDuration = static_defaultComboDuration;

    protected static float static_defaultComboDelay = 0.3f;
    protected static float static_comboDelay = static_defaultComboDelay;
    protected static bool static_canAttack = true;

    protected static int static_comboIndex = 0;

    protected PlayerSM _psm;
    protected PlayerControls playerControls = new();

    public ContainerState(string name, PlayerSM stateMachine) : base(name, stateMachine)
    {
        _psm = stateMachine;
        playerControls.Enable();

        playerControls.PlayerControlsMap.Attack.started += AttackStarted;
    }

    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();
    }

    public override void OnLateUpdate()
    {
        base.OnLateUpdate();
    }

    public void AttackStarted(InputAction.CallbackContext context)
    {
        if (!static_canAttack) return;
        if (static_comboIndex > _psm.attackStates.Length - 1) return;

        stateMachine.ChangeState(_psm.attackStates[static_comboIndex]);
    }
}
