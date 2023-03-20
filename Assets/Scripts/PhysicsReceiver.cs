using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used for cases when one of the colliding objects is set to IsTrigger
/// or some setting that disables normal physics
/// </summary>

public class PhysicsReceiver : MonoBehaviour
{
    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();    
    }

    /// <summary>
    /// Object that collides with this gameObject calls this function
    /// to apply "push" force on this gameObject
    /// </summary>
    /// <param name="force">Force to be applied</param>
    /// <param name="direction">Direction of source</param>
    public void ApplyPush(float force, int direction)
    {
        _rb.AddForce(new Vector2(force * direction, 0), ForceMode2D.Impulse);
        
    }
}
