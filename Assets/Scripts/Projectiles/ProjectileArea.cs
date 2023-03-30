using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileArea : Projectile
{
    [SerializeField] Transform _damagePoint;
    [SerializeField] float _damageRange;
    [SerializeField] LayerMask _damageLayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_collided) return;
        if (collision.gameObject.CompareTag(transform.tag)) return;
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Projectile") return;

        Collider2D[] objs = Physics2D.OverlapCircleAll(
            _damagePoint.position,
            _damageRange,
            _damageLayer);

        foreach (Collider2D obj in objs)
        {
            if (!obj.TryGetComponent(out IDamageable dmg))
                continue;

            dmg.ReceiveDamage(Damage);

            if (!obj.TryGetComponent(out IMoveable move))
                continue;
            
            move.ReceivePush(_rb.mass * Speed);
        }

        _collided = true;
        _rb.velocity = Vector2.zero;
        Anim.ChangeAnimationState(projdl.EXPLOSION_NAME);
    }
}
