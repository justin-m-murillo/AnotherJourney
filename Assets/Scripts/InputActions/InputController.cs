using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    [SerializeField] PlayerSM psm;

    private static PlayerControls playerControls;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        playerControls.PlayerControlsMap.Jump.started += JumpStarted;
        playerControls.PlayerControlsMap.Jump.performed += JumpPerformed;
        playerControls.PlayerControlsMap.Jump.canceled += JumpCanceled;
        playerControls.PlayerControlsMap.Attack.started += AttackStarted;
        playerControls.PlayerControlsMap.Bow.started += BowStarted;
        playerControls.PlayerControlsMap.Bow.canceled += BowCanceled;
    }

    private void Update()
    {
        psm.psl.horizontalInput = playerControls.PlayerControlsMap.Move.ReadValue<Vector2>().x;
    }

    public void JumpStarted(InputAction.CallbackContext context)
    {
        if (psm.psl.jumped) return;
        if (psm.psl.jumpCooldown > 0f) return;
        if (!psm.psl.IsGrounded(psm.RigBody, psm.GroundLayer)) return;

        psm.psl.jumped = true;
        psm.currentState
            .GetStateMachine()
            .ChangeState(psm.jumpState);
    }

    public void JumpPerformed(InputAction.CallbackContext context)
    {
        if (context.started)
            psm.JumpPerformed = true;
    }

    public void JumpCanceled(InputAction.CallbackContext context)
    {
        if (!context.performed)
            Falling.InvokeGravityScalar();
    }

    public void AttackStarted(InputAction.CallbackContext context)
    {
        if (!psm.psl.canAttack) return;
        if (psm.psl.comboIndex > psm.attackStates.Length - 1)
        {
            psm.currentState
                .GetStateMachine()
                .ChangeState(psm.idleState);
            return;
        }

        psm.psl.canAttack = false;
        psm.currentState
            .GetStateMachine()
            .ChangeState(psm.attackStates[psm.psl.comboIndex]);
    }

    public void BowStarted(InputAction.CallbackContext context)
    {
        if (!psm.psl.canBow) return;
        
        psm.psl.canBow = false;
        psm.psl.bowDrawn = true;
        psm.currentState
            .GetStateMachine()
            .ChangeState(psm.bowDraw);
        Debug.Log("Bow drawn");
    }

    public void BowCanceled(InputAction.CallbackContext context)
    {
        psm.psl.bowDrawn = false;
        Debug.Log("bow released");
    }
}
