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
        playerControls.PlayerControlsMap.Jump.started += Jump_started;
        playerControls.PlayerControlsMap.Jump.performed += Jump_performed;
        playerControls.PlayerControlsMap.Jump.canceled += Jump_canceled;

        playerControls.PlayerControlsMap.Attack.started += Attack_started;
        
        playerControls.PlayerControlsMap.Bow.started += Bow_started;
        playerControls.PlayerControlsMap.Bow.canceled += Bow_canceled;

        playerControls.PlayerControlsMap.Magic.started += Magic_started;

        playerControls.PlayerControlsMap.Block.started += Block_started;
        playerControls.PlayerControlsMap.Block.canceled += Block_canceled;
    }

    private void Update()
    {
       _psm.pdl.HORIZONTAL_INPUT = playerControls.PlayerControlsMap.Move.ReadValue<Vector2>().x;
    }

    public void Jump_started(InputAction.CallbackContext context)
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

    public void Jump_performed(InputAction.CallbackContext context)
    {
        _jumpPerformed = true;
    }

    public void Jump_canceled(InputAction.CallbackContext context)
    {
        // BREAK CONDITIONS
        if (_jumpPerformed) return;
        /////////////////////////////////////////////////////////////////

        _psm.pdl.INVOKE_GRAVITY_SCALAR(_psm.RigBody, _psm.pdl.BASE_GRAVITY_SCALE, 1.5f);
    }

    public void Attack_started(InputAction.CallbackContext context)
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

    public void Bow_started(InputAction.CallbackContext context)
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

    public void Bow_canceled(InputAction.CallbackContext context)
    {
        _psm.pdl.BOW_DRAWN = false;
    }

    public void Magic_started(InputAction.CallbackContext context)
    {
        // BREAK CONDITIONS
        if (!_psm.pdl.CAN_MAGIC) return;
        //////////////////////////////////////////////////////////////////

        _psm.currentState
            .GetStateMachine()
            .ChangeState(_psm.magicState);
    }
    
    public void Block_started(InputAction.CallbackContext context)
    {
        // BREAK CONDITIONS
        if (_psm.pdl.IS_BLOCKING) return;
        //////////////////////////////////////////////////////////////////

        _psm.pdl.IS_BLOCKING = true;
        _psm.currentState
            .GetStateMachine()
            .ChangeState(_psm.blockState);
    }

    public void Block_canceled(InputAction.CallbackContext context)
    {
        _psm.pdl.IS_BLOCKING = false;
    }
}
