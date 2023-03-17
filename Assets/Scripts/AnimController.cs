using UnityEngine;

public class AnimController : ScriptableObject
{
    private Animator _anim;
    
    public void SetAnimator(Animator anim) { _anim = anim; }

    public void TriggerIdle() { _anim.SetTrigger("Idle"); }

    public void TriggerMove() { _anim.SetTrigger("Moving"); }

    public void TriggerJump() { _anim.SetTrigger("Jump"); }

    public void TriggerFalling() { _anim.SetTrigger("Falling"); }

    public void TriggerAttack(string attackName)
    {
        _anim.SetTrigger(attackName);
    }

    public void TriggerBowDraw() { _anim.SetTrigger("BowDraw"); }

    public void TriggerBowRelease() { _anim.SetTrigger("BowRelease"); }
}
