using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Animator))]

public class Projectile : MonoBehaviour
{
    [SerializeField] protected ProjectileDataLibrary projdl; 

    public float Speed { get; set; }
    public float Damage { get; set; }
    public float ChargeTime { get; set; }
    public bool IsCharged { get; set; }

    public AnimStateManager Anim { get; private set; }

    protected Rigidbody2D _rb;

    private bool _playedChargedAnim;
    private bool _playedExplosionAnim;
    private bool _fired;
    protected bool _collided;
    protected string _parentTag;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Speed = projdl.BASE_SPEED;
        Damage = projdl.BASE_DAMAGE;
        ChargeTime = 0f;
        IsCharged = false;
        _playedChargedAnim = false;
        _playedExplosionAnim = false;
        _fired = false;
        _collided = false;
        _parentTag = transform.parent.tag;

        gameObject.GetComponent<SpriteRenderer>().enabled = projdl.VISIBLE_ON_START;

        Anim = ScriptableObject.CreateInstance<AnimStateManager>();
        Anim.SetAnimator(GetComponent<Animator>());
    }

    private void Update()
    {
        transform.position = transform.parent != null ? 
            transform.parent.position : 
            transform.position;

        IsCharged = ChargeProjectile();
        
        if (IsCharged && !_playedChargedAnim)
        {
            Anim.ChangeAnimationState(projdl.CHARGED_NAME);
            _playedChargedAnim = true;
        }
    }

    private void LateUpdate()
    {
        if (!_playedExplosionAnim) return;
        Destroy(gameObject);
    }

    private bool ChargeProjectile()
    {
        if (_fired) return false;
        ChargeTime = ChargeTime < projdl.BASE_CHARGE_TIME ?
            ChargeTime + Time.deltaTime :
            projdl.BASE_CHARGE_TIME;

        return ChargeTime == projdl.BASE_CHARGE_TIME;
    }

    public void FireProjectile(bool facingRight)
    {
        if (!projdl.VISIBLE_ON_START)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = !projdl.VISIBLE_ON_START;
        }

        Anim.ChangeAnimationState(projdl.RELEASE_NAME);
        _fired = true;
        transform.parent = null;
        int dir = facingRight ? 1 : -1;
        Speed = dir * Speed * (ChargeTime / projdl.BASE_CHARGE_TIME);
        _rb.AddForce(new Vector2( Speed, 0 ), ForceMode2D.Impulse);
    }

    public void SetExplAnim() 
    {
        _playedExplosionAnim = true; 
    }
}
