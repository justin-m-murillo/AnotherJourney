using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementState : ContainerState
{
    protected static bool _jumped;

    public MovementState(string name, PlayerSM stateMachine) : base(name, stateMachine)
    {
        _psm = (PlayerSM)stateMachine;
        _jumped = false;

        playerControls.PlayerControlsMap.Attack.started += AttackStarted;
        playerControls.PlayerControlsMap.Jump.started += JumpStarted;
        playerControls.PlayerControlsMap.Jump.performed += JumpPerformed;
        playerControls.PlayerControlsMap.Jump.canceled += JumpCanceled;

    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (Grounded.IsGrounded())
            _jumped = false;
    }

    public void AttackStarted(InputAction.CallbackContext context)
    {
        if (!CombatState.static_canAttack) return;
        if (CombatState.static_comboIndex > _psm.attackStates.Length - 1)
        {
            stateMachine.ChangeState(_psm.idleState);
            return;
        }

        CombatState.static_canAttack = false;
        stateMachine.ChangeState(_psm.attackStates[CombatState.static_comboIndex]);
    }

    public void JumpStarted(InputAction.CallbackContext context)
    {
        if (_jumped) return;
        if (Grounded.static_jumpCooldown > 0f) return;
        if (!Grounded.IsGrounded()) return;

        _jumped = true;
        stateMachine.ChangeState(_psm.jumpState);
    }

    public void JumpPerformed(InputAction.CallbackContext context)
    {
        if (context.started)
            _psm.JumpPerformed = true;
    }

    public void JumpCanceled(InputAction.CallbackContext context)
    {
        if (!context.performed)
            Falling.InvokeGravityScalar();
    }
}
