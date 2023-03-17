using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSM : StateMachine
{ 
    [HideInInspector]
    public Idle idleState;
    [HideInInspector]
    public Moving movingState;
    [HideInInspector]
    public Jump jumpState;
    [HideInInspector]
    public Falling fallingState;

    [HideInInspector]
    public AttackState attackOne;
    [HideInInspector]
    public AttackState attackTwo;
    [HideInInspector]
    public AttackState attackThree;
    [HideInInspector]
    public AttackState attackFour;
    [HideInInspector]
    public AttackState attackFive;

    [HideInInspector]
    public AttackState[] attackStates;

    [HideInInspector]
    public BowDraw bowDraw;
    [HideInInspector]
    public BowRelease bowRelease;

    [Tooltip("Player Static Library contains all static variables required for this state machine")]
    public PlayerStatics psl;
    [Tooltip("Character transform")]
    [SerializeField] Transform _characterTransform;
    [Tooltip("Ground layer mask")]
    [SerializeField] LayerMask _groundLayer;
    [Tooltip("Character rigidbody")]
    [SerializeField] Rigidbody2D _rb;

    [Tooltip("Character's default movement speed")]
    [SerializeField] float _defaultMovementSpeed;
    [Tooltip("Charater's default horizontal drag (grounded)")]
    [SerializeField] float _defaultDragFactor;
    [Tooltip("Character's default jump force (affects jump height)")]
    [SerializeField] float _defaultJumpForce;
    [Tooltip("Character's default gravity scale when falling (to fall faster)")]
    [SerializeField] float _defaultGravityFall;
    [Tooltip("Amount to nudge the character forward when attacking")]
    [SerializeField] float _attackPush;

    /// <summary>
    /// Horizontal input used to affect character's movement
    /// </summary>
    //public float HorizontalInput { get; set; }

    /// <summary>
    /// Character Transform property
    /// </summary>
    public Transform CharacterTransform { get; protected set; }

    /// <summary>
    /// World ground layer
    /// </summary>
    public LayerMask GroundLayer { get; protected set; }

    /// <summary>
    /// Character's Rigidbody2D property
    /// </summary>
    public Rigidbody2D RigBody { get; protected set; }

    /// <summary>
    /// Character's AnimController script object (for animation control)
    /// </summary>
    public AnimController Anim { get; protected set; }

    /// <summary>
    /// Character's movement speed (horizontally on ground)
    /// </summary>
    public float MovementSpeed { get; set; }

    /// <summary>
    /// Horizontal drag (grounded). Intended to be a multiplier for MovementSpeed
    /// </summary>
    public float DragFactor { get; set; }

    /// <summary>
    /// Character's jump force directly affects jump height
    /// </summary>
    public float JumpForce { get; set; }

    /// <summary>
    /// If the character's jump input action has been completed entirely, returns true. False otherwise
    /// </summary>
    public bool JumpPerformed { get; set; }

    /// <summary>
    /// The Rigidbody2D's original gravityScale is stored here.
    /// Used for resetting the original gravityScale after Falling state
    /// </summary>
    public float GravityStored { get; private set; }

    /// <summary>
    /// The modified gravityScale for increasing the character's fall speed
    /// </summary>
    public float GravityFall { get; set; }

    /// <summary>
    /// Amount to nudge the character forward while attacking
    /// </summary>
    public float AttackPushValue { get; set; }


    void Awake()
    {
        idleState = new Idle(this);
        movingState = new Moving(this);
        jumpState = new Jump(this);
        fallingState = new Falling(this);

        attackOne   = new(this, 0);
        attackTwo   = new(this, 1);
        attackThree = new(this, 2);
        attackFour  = new(this, 3);
        attackFive  = new(this, 4);

        bowDraw = new(this);
        bowRelease = new(this);

        attackStates = new AttackState[]
        {
            attackOne, 
            attackTwo, 
            attackThree, 
            attackFour, 
            attackFive
        };

        CharacterTransform = _characterTransform;
        GroundLayer = _groundLayer;
        RigBody = _rb;
        Anim = ScriptableObject.CreateInstance<AnimController>();
        Anim.SetAnimator(GetComponentInChildren<Animator>());

        //HorizontalInput = 0f;
        MovementSpeed = _defaultMovementSpeed;
        DragFactor = _defaultDragFactor;

        JumpForce = _defaultJumpForce;
        JumpPerformed = false;

        GravityStored = RigBody.gravityScale;
        GravityFall = _defaultGravityFall;

        AttackPushValue = _attackPush;
    }

    /// <summary>
    /// Returns FSM to initial state
    /// </summary>
    /// <returns><typeparam name="Idle"></typeparam>idleState</returns>
    protected override BaseState GetInitialState()
    {
        return idleState;
    }  
}
