using UnityEngine;

interface IDamageable
{
    float MaxHealth { get; set; }
    float Health { get; set; }

    Transform MeleePoint { get; set; }
    float MeleeRange { get; set; }
    LayerMask AttackLayer { get; set; }

    /// <summary>
    /// Applies an attack on a character. The damage parameter must be a positive number.
    /// </summary>
    /// <param name="damage">The amount of damage to inflict (positive value)</param>
    void ApplyMeleeDamage(float damage);

    /// <summary>
    /// Modifies the health property of this character. 
    /// Use positive values to increase Health and vice-versa.
    /// </summary>
    /// <param name="value">The amount to change in Health</param>
    void ReceiveDamage(float value);
}
