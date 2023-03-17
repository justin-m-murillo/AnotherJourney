using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Player Static Library")]

public class PlayerStatics : ScriptableObject
{
    /// <summary>
    /// MOVEMENT STATIC VARIABLES
    /// </summary>

    public bool jumped;
    public float defaultJumpCooldown;
    public float jumpCooldown; // to prevent double jump glitches
    public float horizontalInput;
    public bool isFacingRight;

    /////////////////////////////////////////////////////////////////////

    /// <summary>
    /// COMBAT STATIC VARIABLES
    /// </summary>
    
    public float defaultComboDuration; // default length of time before combo terminates (used for resetting comboDuration)
    public float comboDuration; // length of time before combo terminates
    public float defaultComboDelay; // default length of time before executing another attack (used for resetting comboDuration)
    public float comboDelay; // length of time before executing another attack
    public bool canAttack; // if the player is permitted to execute an attack
    public int comboIndex; // shows how many attacks have been executed and determines the next attack in the combo

    public bool canBow; // if the player can execute a bow attack 
    public bool bowDrawn; // if the player currently has their bow drawn
    public float bowWalkSpeed; // player movement speed while bow is drawn
    public float bowReleaseAnimTimer; // the time given for the bow release animation to complete
    public float defaultBowFireDelay; // default duration to charge successful shot 
    public float bowFireDelay; // duration to charge successful shot


    /// <summary>
    /// Resets attack-related parameters once the player exits combat state
    /// </summary>
    public void ResetAttackParams()
    {
        comboDuration = defaultComboDuration;
        comboDelay = defaultComboDelay;
        canAttack = true;
        comboIndex = 0;

        bowFireDelay = defaultBowFireDelay;
        canBow = true;
    }

    /// <summary>
    /// Checks if the character's collider is touching the ground layer
    /// </summary>
    /// <returns>True if touching a ground layer, false otherwise</returns>
    public bool IsGrounded(Rigidbody2D rb, LayerMask ground)
    {
        return rb.IsTouchingLayers(ground);
    }

    /// <summary>
    /// Apply additional ground drag
    /// </summary>
    /// <param name="rb">object's rigidbody</param>
    /// <param name="dragFactor">how much of the rigidbody's velocity is used to apply drag in the opposite of moving direction</param>
    /// <param name="mult">optional drag factor multiplier for special cases (defaults to 1f if parameter is not supplied)</param>
    public void ApplyGroundDrag(Rigidbody2D rb, float dragFactor, float mult = 1f)
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
    public void InvokeGravityScalar(Rigidbody2D rb, float newGravityScale, float mult = 1f)
    {
        rb.gravityScale = newGravityScale * mult;
    }
}
