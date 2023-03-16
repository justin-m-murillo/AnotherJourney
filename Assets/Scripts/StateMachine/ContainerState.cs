using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

public class ContainerState : BaseState
{
    protected static float static_defaultComboDuration = 0.7f;
    protected static float static_comboDuration = static_defaultComboDuration;

    protected static float static_defaultComboDelay = 0.3f;
    protected static float static_comboDelay = static_defaultComboDelay;
    protected static bool static_canAttack = true;

    protected static int static_comboIndex = 0;

    protected float static_horizontalInput;
    protected static bool static_isFacingRight;

    protected PlayerSM _psm;
    protected PlayerControls playerControls = new();

    public ContainerState(string name, PlayerSM stateMachine) : base(name, stateMachine)
    {
        _psm = stateMachine;
        static_isFacingRight = true;

        playerControls.Enable();

        playerControls.PlayerControlsMap.Attack.started += AttackStarted;
    }

    protected void ApplyGroundDrag(float mult = 1f)
    {
        // To eliminate sliding when approaching rest
        _psm.RigBody.AddForce(new Vector2
            (-(_psm.RigBody.velocity.x * (_psm.DragFactor * mult)), 0),
            ForceMode2D.Force
        );
    }

    public void AttackStarted(InputAction.CallbackContext context)
    {
        if (!static_canAttack) return;
        if (static_comboIndex > _psm.attackStates.Length - 1) return;

        stateMachine.ChangeState(_psm.attackStates[static_comboIndex]);
    }
}
