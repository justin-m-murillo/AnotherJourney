using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    [SerializeField] PlayerSM _psm;

    private bool _jumpPerformed;

    private static PlayerControls playerControls;

    private GameObject _projectile;

    private void Awake()
    {
        playerControls = new PlayerControls();
        _jumpPerformed = false;
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
       _psm.pdl.HORIZONTAL_INPUT = playerControls.PlayerControlsMap.Move.ReadValue<Vector2>().x;
    }

    public void JumpStarted(InputAction.CallbackContext context)
    {
        // BREAK CONDITIONS
        if (_psm.pdl.IS_JUMP) return;
        if (_psm.pdl.JUMP_COOLDOWN > 0f) return;
        if (_psm.pdl.BOW_DRAWN) return;
        if (!_psm.pdl.INVOKE_IS_GROUNDED(_psm.RigBody, _psm.GroundLayer)) return;
        /////////////////////////////////////////////////////////////////
        
        _psm.pdl.IS_JUMP = true;
        _jumpPerformed = false;
        _psm.currentState
            .GetStateMachine()
            .ChangeState(_psm.jumpState);
    }

    public void JumpPerformed(InputAction.CallbackContext context)
    {
        _jumpPerformed = true;
    }

    public void JumpCanceled(InputAction.CallbackContext context)
    {
        // BREAK CONDITIONS
        if (_jumpPerformed) return;
        /////////////////////////////////////////////////////////////////

        _psm.pdl.INVOKE_GRAVITY_SCALAR(_psm.RigBody, _psm.pdl.BASE_GRAVITY_SCALE, 1.5f);
    }

    public void AttackStarted(InputAction.CallbackContext context)
    {
        // BREAK CONDITIONS
        if (!_psm.pdl.CAN_ATTACK) return;
        /////////////////////////////////////////////////////////////////

        if (_psm.pdl.COMBO_INDEX > _psm.attackStates.Length - 1)
        {
            _psm.pdl.COMBO_INDEX = 0;
        }

        _psm.pdl.CAN_ATTACK = false;
        _psm.currentState
            .GetStateMachine()
            .ChangeState(_psm.attackStates[_psm.pdl.COMBO_INDEX]);
    }

    public void BowStarted(InputAction.CallbackContext context)
    {
        // BREAK CONDITIONS
        if (!_psm.pdl.CAN_BOW) return;
        /////////////////////////////////////////////////////////////////

        _psm.pdl.CAN_BOW = false;
        _psm.pdl.BOW_DRAWN = true;
        _psm.currentState
            .GetStateMachine()
            .ChangeState(_psm.bowDraw);
    }

    public void BowCanceled(InputAction.CallbackContext context)
    {
        _psm.pdl.BOW_DRAWN = false;
    }
    
    public void BlockStarted(InputAction.CallbackContext context)
    {
        // BREAK CONDITIONS
        if (_psm.pdl.IS_BLOCKING) return;
        //////////////////////////////////////////////////////////////////

        _psm.pdl.IS_BLOCKING = true;
        _psm.currentState
            .GetStateMachine()
            .ChangeState(_psm.blockState);
    }

    public void BlockCanceled(InputAction.CallbackContext context)
    {
        _psm.pdl.IS_BLOCKING = false;
    }
}
