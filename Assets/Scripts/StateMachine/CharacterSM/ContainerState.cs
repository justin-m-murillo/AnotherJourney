using UnityEngine;

public class ContainerState : BaseState
{
    protected PlayerSM _psm;
    protected string _animName;

    public virtual void Init(string stateName, string animName, PlayerSM stateMachine)
    {
        base.Init(stateName, stateMachine);
        _psm = stateMachine;
        _animName = animName;
    }

    /// <summary>
    /// A multipurpose timer. Value will either increment or decrement (depending on isNegative)
    /// over time until it reaches its target. If isNegative, we want the value to count down to the target.
    /// If isNegative is false, we want the value to count up to the target.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="target"></param>
    /// <param name="isNegative"></param>
    /// <returns>True if value == target, false otherwise</returns>
    protected bool StateTimer(ref float value, float target, bool isNegative)
    {
        if (isNegative)
        {
            // if negative, we count down to target
            value = value > target ?
                value - Time.deltaTime :
                target;
        }
        else
        {
            // if positive, we count up to target
            value = value < target ?
                value + Time.deltaTime :
                target;
        }

        return value == target;
    }
}
