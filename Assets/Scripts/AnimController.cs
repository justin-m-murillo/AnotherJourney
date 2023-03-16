using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    //[SerializeField] CharMoveController _cmc;

    [SerializeField] Animator _anim;
    
    public void TriggerIdle() { _anim.SetTrigger("Idle"); }

    public void TriggerMove() { _anim.SetTrigger("Moving"); }

    public void TriggerJump() { _anim.SetTrigger("Jump"); }

    public void TriggerFalling() { _anim.SetTrigger("Falling"); }

    public void TriggerAttack(string attackName)
    {
        Debug.Log(attackName); 
        _anim.SetTrigger(attackName);
    }
}
