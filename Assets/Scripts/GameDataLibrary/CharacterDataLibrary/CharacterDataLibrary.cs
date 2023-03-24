using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character Data Library")]
public class CharacterDataLibrary : ScriptableObject
{
    [Header("CHARACTER ATTRIBUTES")]
    [Space(8)]

    [Tooltip("The character's max health")]
    public int BASE_MAX_HEALTH;
    [Tooltip("The character's current health")]
    public int BASE_HEALTH;
    [Tooltip("Character movement speed (x-axis)")]
    public float BASE_MOVE_SPEED;
    [Tooltip("Modified gravityScale for increasing the character's fall speed.")]
    public float BASE_GRAVITY_SCALE;
    [Tooltip("Stored gravityScale from Rigidbody. Used for resetting the original gravityScale after Falling state")]
    public float STORED_GRAVITY_SCALE;

    [Header("MOVEMENT DATA")]

    [Header("Basic Data")]
    [Space(8)]

    [Tooltip("User horizontal input value from input controller.")]
    public float HORIZONTAL_INPUT;
    [Tooltip("Ground drag")]
    public float BASE_GROUND_DRAG;
    [Tooltip("If the sprite is facing right.")]
    public bool IS_FACING_RIGHT;

    [Header("Jump Data")]
    [Space(8)]
    
    [Tooltip("Did the character jump")]
    public bool IS_JUMP;
    [Tooltip("Base jump force")]
    public float BASE_JUMP_FORCE;
    [Tooltip("Base jump cooldown")]
    public float BASE_JUMP_COOLDOWN;
    [Tooltip("To prevent double jump glitches")]
    public float JUMP_COOLDOWN;
    [Tooltip("If the character is touching a ground tile")]
    public bool IS_GROUNDED;
    [Tooltip("The character's y-position in previous frame")]
    public float PREV_Y_POS;
    [Tooltip("The difference in y-position between current frame and previous frame")]
    public float DIFF_Y;

    [Header("COMBAT DATA")]
    [Space(8)]

    [Header("Basic Attack")]
    [Space(8)]

    [Tooltip("How much damage this character can inflict")]
    public float ATTACK_DAMAGE;
    [Tooltip("Default length of time before combo terminates (used for resetting comboDuration)")]
    public float BASE_COMBO_DURATION;
    [Tooltip("Length of time before combo terminates")]
    public float COMBO_DURATION;
    [Tooltip("Default length of time before executing another attack (used for resetting comboDuration)")]
    public float BASE_ATTACK_DURATION;
    [Tooltip("Length of time before executing another attack")]
    public float ATTACK_DURATION;
    [Tooltip("If the player is permitted to execute an attack")]
    public bool CAN_ATTACK;
    [Tooltip("Shows how many attacks have been executed and determines the next attack in the combo.")]
    public int COMBO_INDEX;
    [Tooltip("How much to push the object receiving an attack")]
    public float ATTACK_PUSH;
}
