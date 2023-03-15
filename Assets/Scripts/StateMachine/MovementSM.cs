using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSM : StateMachine
{
    [HideInInspector]
    public Idle idleState;
    [HideInInspector]
    public Moving movingState;
    [HideInInspector]
    public Jump jumpState;
    [HideInInspector]
    public Falling fallingState;

    [SerializeField] protected Transform _characterTransform;
    [SerializeField] protected Transform _groundCheck;
    [SerializeField] protected LayerMask _groundLayer;
    [SerializeField] protected Rigidbody2D _rb;
    [SerializeField] protected AnimController _anim;

    [SerializeField] float _defaultMovementSpeed;
    [SerializeField] float _defaultJumpForce;
    [SerializeField] float _defualtJumpFactor;
    [SerializeField] float _defaultGravityFactor;

    public Transform CharacterTransform { get; private set; }

    public Transform GroundCheck { get; private set; }
    public LayerMask GroundLayer { get; private set; }
    public Rigidbody2D RBody { get; private set; }
    public AnimController Anim { get; private set; }
    public float HorizontalInput { get; set; }
    public float MovementSpeed { get; set; }

    public bool Jumped { get; set; }
    public float JumpForce { get; set; }
    public bool JumpPerformed { get; set; }
    public float JumpMultiplier { get; set; }

    public float GravityStored { get; set; }
    public float GravityFactor { get; set; }


    void Awake()
    {
        idleState = new Idle(this);
        movingState = new Moving(this);
        jumpState = new Jump(this);
        fallingState = new Falling(this);

        CharacterTransform = _characterTransform;
        GroundCheck = _groundCheck;
        GroundLayer = _groundLayer;
        RBody = _rb;
        Anim = _anim;

        HorizontalInput = 0f;
        MovementSpeed = _defaultMovementSpeed;
        Jumped = false;
        JumpForce = _defaultJumpForce;
        JumpPerformed = false;
        JumpMultiplier = _defualtJumpFactor;
        GravityStored = RBody.gravityScale;
        GravityFactor = _defaultGravityFactor;
    }

    protected override BaseState GetInitialState()
    {
        return idleState;
    }

    public void SetHorizontalInput(float horizontalInput)
    {
        if (!IsGrounded()) return;
        HorizontalInput = horizontalInput;
    }

    public void InvokeJump() 
    {
        if (!IsGrounded()) return;
        Jumped = true;
    }

    public void InvokeGravityScaler()
    {
        RBody.gravityScale = GravityStored * GravityFactor;
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(GroundCheck.position, 0.2f, GroundLayer);
    }
}
