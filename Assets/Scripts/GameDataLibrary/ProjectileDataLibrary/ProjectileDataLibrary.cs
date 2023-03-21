using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Projectile Data Library")]

public class ProjectileDataLibrary : ScriptableObject
{
    [Tooltip("If this projectile's visibility is enabled upon instantiation")]
    public bool VISIBLE_ON_START;
    [Tooltip("Spawn state name")]
    public string SPAWN_NAME;
    [Tooltip("Charged state name")]
    public string CHARGED_NAME;
    [Tooltip("Release state name")]
    public string RELEASE_NAME;
    [Tooltip("Explosion anim name")]
    public string EXPLOSION_NAME;

    [Tooltip("Base speed of the projectile. Parameter to AddForce.Impulse")]
    public float BASE_SPEED;
    [Tooltip("Base damage of the projectile.")]
    public float BASE_DAMAGE;
    [Tooltip("Base charge time of the projectile")]
    public float BASE_CHARGE_TIME;
    [Tooltip("True if the projectile is fully charged, false otherwise")]
    public bool IS_CHARGED;
}
