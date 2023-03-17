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

    /// <summary>
    /// Resets attack-related parameters once the player exits combat state
    /// </summary>
    public void ResetAttackParams()
    {
        comboDuration = defaultComboDuration;
        comboDelay = defaultComboDelay;
        canAttack = true;
        comboIndex = 0;
    }
}
