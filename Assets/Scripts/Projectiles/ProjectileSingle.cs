using UnityEngine;

public class ProjectileSingle : Projectile
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_collided) return;
        if (collision.gameObject.CompareTag(_parentTag)) return;
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Projectile") return;

        if (collision.gameObject.TryGetComponent(out IDamageable dmg))
        {
            dmg.ReceiveDamage(Damage);
        }

        if (collision.gameObject.TryGetComponent(out IMoveable move))
        {
            move.ReceivePush(_rb.mass * Speed);
        }

        _collided = true;
        _rb.velocity = Vector2.zero;
        Anim.ChangeAnimationState(projdl.EXPLOSION_NAME);
    }
}
