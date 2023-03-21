using UnityEngine;

public class AnimStateManager : ScriptableObject
{
    private Animator _anim;
    private string currentState;

    public void SetAnimator(Animator anim) { _anim = anim; }

    public void ChangeAnimationState(string nextState)
    {
        // stop animation from interrupting self
        if (currentState == nextState) return;
        if (nextState.CompareTo("") == 0) return;
        // player next animation
        _anim.enabled = false;
        _anim.enabled = true;
        _anim.Play(nextState);
        // set current animation state to next animation
        currentState = nextState;
    }
}
