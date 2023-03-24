using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used for cases when one of the colliding objects is set to IsTrigger
/// or some setting that disables normal physics
/// </summary>
interface IMoveable
{
    Rigidbody2D RB2D { get; set; }

    /// <summary>
    /// Object that collides with this gameObject calls this function
    /// to apply "push" force on this gameObject
    /// </summary>
    /// <param name="force">Force to be applied</param>
    /// <param name="direction">Direction of source</param>
    void ReceivePush(float force);
}
