using UnityEngine;

public class ProjSM : StateMachine
{
    [HideInInspector]
    public SpawnProj spawnState;
    [HideInInspector]
    public ChargedProj chargedState;
    [HideInInspector]
    public ReleaseProj releaseState;

    [Tooltip("Projectile Data Library. Treat as a template for parameters")]
    public ProjectileDataLibrary projdl;
    public AnimStateManager Anim { get; private set; }
    public Projectile Proj { get; private set; }

    private void Awake()
    {
        spawnState   = ScriptableObject.CreateInstance<SpawnProj>();
        chargedState = ScriptableObject.CreateInstance<ChargedProj>();
        releaseState = ScriptableObject.CreateInstance<ReleaseProj>();

        spawnState.Init(projdl.SPAWN_NAME, projdl.SPAWN_NAME, this);
        chargedState.Init(projdl.CHARGED_NAME, projdl.CHARGED_NAME, this);
        releaseState.Init(projdl.RELEASE_NAME, projdl.RELEASE_NAME, this);

        Anim = ScriptableObject.CreateInstance<AnimStateManager>();
        Anim.SetAnimator(GetComponentInChildren<Animator>());
        Proj = GetComponent<Projectile>();
    }

    protected override BaseState GetInitialState()
    {
        return spawnState;
    }


}
