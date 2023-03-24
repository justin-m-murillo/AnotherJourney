using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Character))]

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
    public MagicDraw magicDraw;
    [HideInInspector]
    public MagicRelease magicRelease;

    [HideInInspector]
    public Block blockState;

    [Tooltip("Player Data Library contains all variables required for this state machine")]
    public PlayerDataLibrary pdl;

    [Tooltip("Local position to instantiate an arrow")]
    public Transform arrowSpawnPosition;
    [Tooltip("Arrow Prefab")]
    public GameObject arrowPrefab;

    [Tooltip("Local position to instantiate magic object")]
    public Transform magicSpawnPosition;
    [Tooltip("Magic Prefab")]
    public GameObject magicPrefab;

    [Tooltip("Ground layer mask")]
    [SerializeField] LayerMask _groundLayer;

    private Rigidbody2D _rb;

    /// <summary>
    /// Character Transform property
    /// </summary>
    public Transform CharacterTransform { get { return transform; } }

    /// <summary>
    /// World ground layer
    /// </summary>
    public LayerMask GroundLayer { get { return _groundLayer; } }

    /// <summary>
    /// Character's Rigidbody2D property
    /// </summary>
    public Rigidbody2D RB2D { get { return _rb; } private set { _rb = value; } }

    /// <summary>
    /// Character's AnimController script object (for animation control)
    /// </summary>
    public AnimStateManager Anim { get; private set; }

    /// <summary>
    /// Character script of the gameObject this FSM is attached to
    /// </summary>
    public Character Char { get; private set; }

    /// <summary>
    /// The projectile loaded and prepped to fire
    /// </summary>
    public GameObject LoadedProjectile { get; set; }


    void Awake()
    {
        idleState   = new("Idle", "P_Idle", this);
        movingState = new("Moving", "P_Moving", this);
        jumpState   = new("Jump", "P_Jump", this);
        fallingState= new("Falling", "P_Falling", this);

        attackOne   = new("Attack1", "P_Attack1", this);
        attackTwo   = new("Attack2", "P_Attack2", this);
        attackThree = new("Attack3", "P_Attack3", this);
        attackFour  = new("Attack4", "P_Attack4", this);
        attackFive  = new("Attack5", "P_Attack5", this);

        bowDraw     = new("BowDraw", "P_BowDraw", this);
        bowRelease  = new("BowRelease", "P_BowRelease", this);

        magicDraw   = new("MagicDraw", "P_MagicDraw", this);
        magicRelease= new("MagicRelease", "P_MagicRelease", this);

        blockState  = new("Block", "P_Block", this); 

        attackStates = new AttackState[]
        {
            attackOne, 
            attackTwo, 
            attackThree, 
            attackFour, 
            attackFive
        };

        RB2D = GetComponent<Rigidbody2D>();
        Anim = ScriptableObject.CreateInstance<AnimStateManager>();
        Anim.SetAnimator(GetComponentInChildren<Animator>());
        Char = GetComponent<Character>();

        pdl.STORED_GRAVITY_SCALE = RB2D.gravityScale;

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
