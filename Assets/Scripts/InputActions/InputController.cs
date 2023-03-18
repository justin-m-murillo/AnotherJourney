using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    [SerializeField] PlayerSM _psm;

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
        playerControls.PlayerControlsMap.Block.started += BlockStarted;
        playerControls.PlayerControlsMap.Block.canceled += BlockCanceled;
    }

    private void Update()
    {
        _psm.psl.horizontalInput = playerControls.PlayerControlsMap.Move.ReadValue<Vector2>().x;
    }

    public void JumpStarted(InputAction.CallbackContext context)
    {
        // BREAK CONDITIONS
        if (_psm.psl.jumped) return;
        if (_psm.psl.jumpCooldown > 0f) return;
        if (_psm.psl.bowDrawn) return;
        if (!_psm.psl.IsGrounded(_psm.RigBody, _psm.GroundLayer)) return;
        /////////////////////////////////////////////////////////////////
        
        _psm.psl.jumped = true;
        _psm.JumpPerformed = false;
        _psm.currentState
            .GetStateMachine()
            .ChangeState(_psm.jumpState);
    }

    public void JumpPerformed(InputAction.CallbackContext context)
    {
        _psm.JumpPerformed = true;
    }

    public void JumpCanceled(InputAction.CallbackContext context)
    {
        // BREAK CONDITIONS
        if (_psm.JumpPerformed) return;
        /////////////////////////////////////////////////////////////////

        _psm.psl.InvokeGravityScalar(_psm.RigBody, _psm.GravityFall);
    }

    public void AttackStarted(InputAction.CallbackContext context)
    {
        // BREAK CONDITIONS
        if (!_psm.psl.canAttack) return;
        /////////////////////////////////////////////////////////////////

        if (_psm.psl.comboIndex > _psm.attackStates.Length - 1)
        {
            _psm.psl.comboIndex = 0;
        }

        _psm.psl.canAttack = false;
        _psm.currentState
            .GetStateMachine()
            .ChangeState(_psm.attackStates[_psm.psl.comboIndex]);
    }

    public void BowStarted(InputAction.CallbackContext context)
    {
        // BREAK CONDITIONS
        if (!_psm.psl.canBow) return;
        /////////////////////////////////////////////////////////////////

        _psm.psl.canBow = false;
        _psm.psl.bowDrawn = true;
        _psm.currentState
            .GetStateMachine()
            .ChangeState(_psm.bowDraw);
    }

    public void BowCanceled(InputAction.CallbackContext context)
    {
        _psm.psl.bowDrawn = false;
    }
    
    public void BlockStarted(InputAction.CallbackContext context)
    {
        // BREAK CONDITIONS
        if (_psm.psl.isBlocking) return;
        //////////////////////////////////////////////////////////////////

        _psm.psl.isBlocking = true;
        _psm.currentState
            .GetStateMachine()
            .ChangeState(_psm.blockState);
    }

    public void BlockCanceled(InputAction.CallbackContext context)
    {
        _psm.psl.isBlocking = false;
    }
}
