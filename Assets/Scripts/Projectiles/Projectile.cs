using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] ProjectileDataLibrary projdl; 

    public float Speed { get; set; }
    public float Damage { get; set; }
    public float ChargeTime { get; set; }
    public bool IsCharged { get; set; }

    public AnimStateManager Anim { get; private set; }

    private Rigidbody2D _rb;

    private bool _playedChargedAnim;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Speed = projdl.BASE_SPEED;
        Damage = projdl.BASE_DAMAGE;
        ChargeTime = 0f;
        IsCharged = false;
        _playedChargedAnim = false;

        Anim = ScriptableObject.CreateInstance<AnimStateManager>();
        Anim.SetAnimator(GetComponentInChildren<Animator>());
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) return;
        Destroy(gameObject);
    }

    private bool ChargeProjectile()
    {
        ChargeTime = ChargeTime < projdl.BASE_CHARGE_TIME ?
            ChargeTime + Time.deltaTime :
            projdl.BASE_CHARGE_TIME;

        return ChargeTime == projdl.BASE_CHARGE_TIME;
    }

    public void FireProjectile(bool facingRight)
    {
        transform.parent = null;
        int dir = facingRight ? 1 : -1;
        float speed = dir * Speed * (ChargeTime / projdl.BASE_CHARGE_TIME);
        _rb.AddForce(new Vector2( speed, 0 ), ForceMode2D.Impulse);
        Anim.ChangeAnimationState(projdl.RELEASE_NAME);
    }
}
