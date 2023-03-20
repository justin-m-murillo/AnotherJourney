using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Player Static Library")]

public class PlayerDataLibrary : CharacterDataLibrary
{
    [Header("Bow Attack")]
    [Space(8)]
    
    [Tooltip("If the player can execute a bow attack")]
    public bool CAN_BOW;
    [Tooltip("If the player currently has their bow drawn")]
    public bool BOW_DRAWN;
    [Tooltip("Player movement speed while bow is drawn")]
    public float BOW_WALK_SPEED;
    [Tooltip("The time given for the bow release animation to complete")]
    public float BOW_RELEASE_ANIM_DURATION;
    [Tooltip("Base duration to charge successful shot")]
    public float BASE_BOW_CHARGE_TIMER;
    [Tooltip("Duration to charge successful shot")]
    public float BOW_CHARGE_TIMER;

    [Header("Shield Block")]
    [Space(8)]
    
    [Tooltip("If the player is currently blocking with shield")]
    public bool IS_BLOCKING;
    [Tooltip("Player movement speed while blocking")]
    public float BLOCK_WALK_SPEED;

    [Header("Miscellaneous")]
    [Space(8)]
    
    [Tooltip("Amount the player moves forward while executing basic attacks")]
    public float ATTACK_PUSH_VALUE;



    /// <summary>
    /// Resets attack-related parameters once the player exits combat state
    /// </summary>
    public void INVOKE_RESET_ATTACK_PARAMS()
    {
        COMBO_DURATION = 0;
        ATTACK_DURATION = 0;
        CAN_ATTACK = true;
        COMBO_INDEX = 0;

        BOW_CHARGE_TIMER = 0;
        BOW_DRAWN = false;
        CAN_BOW = true;

        IS_BLOCKING = false;
    }

    /// <summary>
    /// Checks if the character's collider is touching the ground layer
    /// </summary>
    /// <returns>True if touching a ground layer, false otherwise</returns>
    public bool INVOKE_IS_GROUNDED(Rigidbody2D rb, LayerMask ground)
    {
        IS_GROUNDED = rb.IsTouchingLayers(ground);
        return rb.IsTouchingLayers(ground);
    }

    /// <summary>
    /// Apply additional ground drag
    /// </summary>
    /// <param name="rb">object's rigidbody</param>
    /// <param name="dragFactor">how much of the rigidbody's velocity is used to apply drag in the opposite of moving direction</param>
    /// <param name="mult">optional drag factor multiplier for special cases (defaults to 1f if parameter is not supplied)</param>
    public void INVOKE_GROUND_DRAG(Rigidbody2D rb, float dragFactor, float mult = 1f)
    {
        // To eliminate sliding when approaching rest
        rb.AddForce(new Vector2
            (-(rb.velocity.x * (dragFactor * mult)), 0),
            ForceMode2D.Force
        );
    }

    /// <summary>
    /// Temporarily sets the Rigidbody2D's gravityScale to GravityFall's value multiplied by third parameter if provided
    /// </summary>
    public void INVOKE_GRAVITY_SCALAR(Rigidbody2D rb, float newGravityScale, float mult = 1f)
    {
        rb.gravityScale = newGravityScale * mult;
    }

    /// <summary>
    /// Temporarily sets the Rigidbody2D's velocity to a different speed than normal movement 
    /// </summary>
    public void INVOKE_SET_MODIFIED_MOVE_SPEED(Rigidbody2D rb, float newSpeed)
    {
        Vector2 vel = rb.velocity;
        vel.x = newSpeed * HORIZONTAL_INPUT;
        rb.velocity = vel;
    }
}
