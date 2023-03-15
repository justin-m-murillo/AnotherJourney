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

    [Tooltip("Character transform")]
    [SerializeField] protected Transform _characterTransform;
    [Tooltip("Ground layer mask")]
    [SerializeField] protected LayerMask _groundLayer;
    [Tooltip("Character rigidbody")]
    [SerializeField] protected Rigidbody2D _rb;
    [Tooltip("Character AnimController script (for animation control)")]
    [SerializeField] protected AnimController _anim;

    [Tooltip("Character's default movement speed")]
    [SerializeField] float _defaultMovementSpeed;
    [Tooltip("Charater's default horizontal drag (grounded)")]
    [SerializeField] float _defaultDragFactor;
    [Tooltip("Character's default jump force (affects jump height)")]
    [SerializeField] float _defaultJumpForce;
    [Tooltip("Character's default gravity scale when falling (to fall faster)")]
    [SerializeField] float _defaultGravityFall;

    /// <summary>
    /// Character Transform property
    /// </summary>
    public Transform CharacterTransform { get; private set; }
    
    /// <summary>
    /// Character's Rigidbody2D property
    /// </summary>
    public Rigidbody2D RigBody { get; private set; }

    /// <summary>
    /// Character's AnimController script object (for animation control)
    /// </summary>
    public AnimController Anim { get; private set; }

    /// <summary>
    /// Horizontal input used to affect character's movement
    /// </summary>
    public float HorizontalInput { get; set; }

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


    void Awake()
    {
        idleState = new Idle(this);
        movingState = new Moving(this);
        jumpState = new Jump(this);
        fallingState = new Falling(this);

        CharacterTransform = _characterTransform;
        RigBody = _rb;
        Anim = _anim;

        HorizontalInput = 0f;
        MovementSpeed = _defaultMovementSpeed;
        DragFactor = _defaultDragFactor;

        JumpForce = _defaultJumpForce;
        JumpPerformed = false;

        GravityStored = RigBody.gravityScale;
        GravityFall = _defaultGravityFall;
    }

    /// <summary>
    /// Returns FSM to initial state
    /// </summary>
    /// <returns><typeparam name="Idle"></typeparam>idleState</returns>
    protected override BaseState GetInitialState()
    {
        return idleState;
    }

    /// <summary>
    /// Sets the horizontal input used to control the character's horizontal movement
    /// </summary>
    /// <param name="horizontalInput"></param>
    public void SetHorizontalInput(float horizontalInput)
    {
        //if (!IsGrounded()) return;
        HorizontalInput = horizontalInput;
    }

    /// <summary>
    /// Adjusts the Rigidbody2D's gravityScale to GravityFall's value
    /// </summary>
    public void InvokeGravityScaler()
    {
        RigBody.gravityScale = GravityFall;
    }

    /// <summary>
    /// Checks if the character's collider is touching the ground layer
    /// </summary>
    /// <returns>True if touching a ground layer, false otherwise</returns>
    public bool IsGrounded()
    {
        return RigBody.IsTouchingLayers(_groundLayer);
    }
}
