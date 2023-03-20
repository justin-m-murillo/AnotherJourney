using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileState : BaseState
{
    protected ProjSM _projsm;
    protected string _animName;

    public virtual void Init(string stateName, string animName, ProjSM stateMachine)
    {
        base.Init(stateName, stateMachine);
        _projsm = stateMachine;
        _animName = animName;
    }
}
