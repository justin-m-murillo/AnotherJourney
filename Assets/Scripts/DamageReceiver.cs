using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The EffectReceiver is responsible for linking damage and effects inflicted on the
/// GameObject from external sources.
/// 
/// The EffectReceiver is capable of:
///     - transmitting direct (single frame) damage
///     - applying DOT via Time.deltaTime
/// </summary>

public class DamageReceiver : MonoBehaviour
{
    // int is a placeholder, must replace with actual damage effect class
    // holds all DOT-related damage effects and applies them via Update
    // dotList will remove effects that have expired determined via Time.deltaTime
    private List<int> dotList; 
        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplySingleFrameDamage(float damageToSend, out string outputMessage)
    {

        outputMessage = damageToSend + " - Hit (Requires implementation)";
    }
}
