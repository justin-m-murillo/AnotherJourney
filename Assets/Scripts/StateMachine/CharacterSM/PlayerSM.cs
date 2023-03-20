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

    [HideInInspector]
    public Block blockState;

    [Tooltip("Player Data Library contains all variables required for this state machine")]
    public PlayerDataLibrary pdl;
    [Tooltip("Local position to instantiate an arrow")]
    public Transform arrowSpawnPosition;
    [Tooltip("Arrow Prefab")]
    public GameObject arrowPrefab;
    [Tooltip("Ground layer mask")]
    [SerializeField] LayerMask _groundLayer;

    /// <summary>
    /// Character Transform property
    /// </summary>
    public Transform CharacterTransform { get; private set; }

    /// <summary>
    /// World ground layer
    /// </summary>
    public LayerMask GroundLayer { get; private set; }

    /// <summary>
    /// Character's Rigidbody2D property
    /// </summary>
    public Rigidbody2D RigBody { get; private set; }

    /// <summary>
    /// Character's AnimController script object (for animation control)
    /// </summary>
    public AnimStateManager Anim { get; private set; }

    /// <summary>
    /// The projectile loaded and prepped to fire
    /// </summary>
    public GameObject LoadedProjectile { get; set; }


    void Awake()
    {
        idleState   = ScriptableObject.CreateInstance<Idle>();
        movingState = ScriptableObject.CreateInstance<Moving>();
        jumpState   = ScriptableObject.CreateInstance<Jump>();
        fallingState= ScriptableObject.CreateInstance<Falling>();

        attackOne   = ScriptableObject.CreateInstance<AttackState>();
        attackTwo   = ScriptableObject.CreateInstance<AttackState>();
        attackThree = ScriptableObject.CreateInstance<AttackState>();
        attackFour  = ScriptableObject.CreateInstance<AttackState>();
        attackFive  = ScriptableObject.CreateInstance<AttackState>();

        bowDraw     = ScriptableObject.CreateInstance<BowDraw>();
        bowRelease  = ScriptableObject.CreateInstance<BowRelease>();

        blockState  = ScriptableObject.CreateInstance<Block>(); 

        idleState
            .Init("Idle", "P_Idle", this);
        movingState
            .Init("Moving", "P_Moving", this);
        jumpState
            .Init("Jump", "P_Jump", this);
        fallingState
            .Init("Falling", "P_Falling", this);

        attackOne
            .Init("Attack1", "P_Attack1", this);
        attackTwo
            .Init("Attack2", "P_Attack2", this);
        attackThree
            .Init("Attack3", "P_Attack3", this);
        attackFour
            .Init("Attack4", "P_Attack4", this);
        attackFive
            .Init("Attack5", "P_Attack5", this);

        bowDraw
            .Init("BowDraw", "P_BowDraw", this);
        bowRelease
            .Init("BowRelease", "P_BowRelease", this);
        blockState
            .Init("Block", "P_Block", this);

        attackStates = new AttackState[]
        {
            attackOne, 
            attackTwo, 
            attackThree, 
            attackFour, 
            attackFive
        };

        CharacterTransform = transform;
        GroundLayer = _groundLayer;
        RigBody = GetComponent<Rigidbody2D>();
        Anim = ScriptableObject.CreateInstance<AnimStateManager>();
        Anim.SetAnimator(GetComponentInChildren<Animator>());

        pdl.STORED_GRAVITY_SCALE = RigBody.gravityScale;

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
