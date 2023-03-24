using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, 
    IDamageable,
    IMoveable
{
    [SerializeField] Transform _attackPoint;
    [SerializeField] float _attackRange;
    [SerializeField] LayerMask _attackMask;
    [SerializeField] CharacterDataLibrary cdl;

    private float _attackForce;

    public float MaxHealth { get; set; }
    public float Health { get; set; }
    public Transform MeleePoint { get; set; }
    public float MeleeRange { get; set; }
    public LayerMask AttackLayer { get; set; }
    public Rigidbody2D RB2D { get; set; }

    
    public void ResetHealth() { Health = MaxHealth; }

    void Awake()
    {
        MeleePoint = _attackPoint;
        MeleeRange = _attackRange;
        AttackLayer = _attackMask;
        RB2D = GetComponent<Rigidbody2D>();

        _attackForce = cdl.ATTACK_PUSH;
    }

    public void ApplyMeleeDamage(float damage)
    {
        Collider2D[] objs = Physics2D
            .OverlapCircleAll(
            MeleePoint.position, 
            MeleeRange, 
            AttackLayer);

        foreach (var obj in objs)
        {
            if (!obj.TryGetComponent(out IDamageable dmg))
                continue;

            dmg.ReceiveDamage(damage);

            if (!obj.TryGetComponent(out IMoveable move))
                continue;

            move.ReceivePush(_attackForce);
        }
    }

    public void ReceiveDamage(float value) { Health -= value; }

    public void ReceivePush(float force)
    {
        RB2D.AddForce(new Vector2(force, 0), ForceMode2D.Impulse);
    }

    
}
