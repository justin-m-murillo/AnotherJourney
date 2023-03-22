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
        spawnState   = new(projdl.SPAWN_NAME, projdl.SPAWN_NAME, this);
        chargedState = new(projdl.CHARGED_NAME, projdl.CHARGED_NAME, this);
        releaseState = new(projdl.RELEASE_NAME, projdl.RELEASE_NAME, this);

        Anim = ScriptableObject.CreateInstance<AnimStateManager>();
        Anim.SetAnimator(GetComponentInChildren<Animator>());
        Proj = GetComponent<Projectile>();
    }

    protected override BaseState GetInitialState()
    {
        return spawnState;
    }
}
