using UnityEngine;

public class Idle : Grounded
{
    public Idle(string stateName, string animName, PlayerSM stateMachine) : 
        base(stateName, animName, stateMachine)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();

        PSM.Anim.ChangeAnimationState(AnimName);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (Mathf.Abs(PSM.pdl.HORIZONTAL_INPUT) < Mathf.Epsilon) return;
        PSM.ChangeState(PSM.movingState);
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();
        PSM.pdl.INVOKE_GROUND_DRAG(PSM.RB2D, PSM.pdl.BASE_GROUND_DRAG);
    }
}
