using UnityEngine;

public class Jump : MovementState
{
    public Jump(string stateName, string animName, PlayerSM stateMachine) :
        base(stateName, animName, stateMachine)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();

        Vector2 vel = PSM.RB2D.velocity;
        vel.y += PSM.pdl.BASE_JUMP_FORCE;
        PSM.RB2D.velocity = vel;

        PSM.Anim.ChangeAnimationState(AnimName);
    }
}
