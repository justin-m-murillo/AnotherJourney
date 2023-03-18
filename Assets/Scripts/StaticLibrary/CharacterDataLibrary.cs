using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDataLibrary : ScriptableObject
{
    [Header("MOVEMENT DATA")]
    [Space(8)]

    public bool IS_JUMP; // did the character jump
    public float DEFAULT_JUMP_COOLDOWN; // default jump cooldown
    public float JUMP_COOLDOWN; // to prevent double jump glitches

    public bool IS_GROUNDED; // if the character is touching a ground tile

    public float PREV_Y_POS; // saves the y position before next frame
    public float DIFF_Y; // the difference in y position between current frame and previous frame

    public float HORIZONTAL_INPUT; // user horizontal input value from input controller
    public bool IS_FACING_RIGHT; // if the sprite is facing right

    [Header("COMBAT DATA")]
    [Space(8)]

    // BASIC ATTACKS
    public float DEFAULT_COMBO_DURATION; // default length of time before combo terminates (used for resetting comboDuration)
    public float COMBO_DURATION; // length of time before combo terminates
    public float DEFAULT_ATTACK_DURATION; // default length of time before executing another attack (used for resetting comboDuration)
    public float ATTACK_DURATION; // length of time before executing another attack
    public bool CAN_ATTACK; // if the player is permitted to execute an attack
    public int COMBO_INDEX; // shows how many attacks have been executed and determines the next attack in the combo
}
