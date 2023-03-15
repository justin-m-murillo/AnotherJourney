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
    public JumpShort jumpShortState;
    [HideInInspector]
    public Falling fallingState;

    [SerializeField] protected Transform _characterTransform;
    [SerializeField] protected Transform _groundCheck;
    [SerializeField] protected LayerMask _groundLayer;
    [SerializeField] protected Rigidbody2D _rb;
    [SerializeField] protected AnimController _anim;

    [SerializeField] float _defaultMovementSpeed;
    [SerializeField] float _defaultJumpForce;
    [SerializeField] float _gravityFactor;

    public Transform CharacterTransform { get; private set; }

    public Transform GroundCheck { get; private set; }
    public LayerMask GroundLayer { get; private set; }
    public Rigidbody2D RBody { get; private set; }
    public AnimController Anim { get; private set; }
    public float HorizontalInput { get; set; }
    public float MovementSpeed { get; set; }

    public bool Jumped { get; set; }
    public float JumpForce { get; set; }
    public float JumpMultiplier { get; set; }

    public float GravityFactor { get; set; }

    void Awake()
    {
        idleState = new Idle(this);
        movingState = new Moving(this);
        jumpState = new Jump(this);
        jumpShortState = new JumpShort(this);
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
        JumpMultiplier = 0f;
        GravityFactor = _gravityFactor;
    }

    protected override BaseState GetInitialState()
    {
        return idleState;
    }

    public void InvokeJump(bool status, float mult) 
    { 
        JumpMultiplier += mult;

        Vector2 force = JumpForce * JumpMultiplier * Vector2.up;

        Vector2 vel = RBody.velocity;
        vel.y += JumpForce * JumpMultiplier;
        RBody.velocity = vel;

        Jumped = status;
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(GroundCheck.position, 0.2f, GroundLayer);
    }
}
