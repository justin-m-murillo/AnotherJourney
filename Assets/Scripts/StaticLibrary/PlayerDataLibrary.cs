using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Player Static Library")]

public class PlayerDataLibrary : CharacterDataLibrary
{   
    [Space(8)]
    // BOW DATA
    public bool CAN_BOW; // if the player can execute a bow attack 
    public bool BOW_DRAWN; // if the player currently has their bow drawn
    public float BOW_WALK_SPEED; // player movement speed while bow is drawn
    public float BOW_RELEASE_ANIM_DURATION; // the time given for the bow release animation to complete
    public float DEFAULT_BOW_CHARGE_TIMER; // default duration to charge successful shot 
    public float BOW_CHARGE_TIMER; // duration to charge successful shot

    [Space(8)]
    // BLOCK DATA
    public bool IS_BLOCKING; // if the player is currently blocking with shield
    public float BLOCK_WALK_SPEED; // player movement speed while blocking

    [Space(8)]
    // MISC.
    public float ATTACK_PUSH_VALUE; // Amount the player moves forward while executing basic attacks



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
