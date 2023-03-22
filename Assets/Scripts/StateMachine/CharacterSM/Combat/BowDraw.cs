using System;
using UnityEngine;

public class BowDraw : CombatState
{
    public BowDraw(string stateName, string animName, PlayerSM stateMachine) :
        base(stateName, animName, stateMachine)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();

        PSM.Anim.ChangeAnimationState(AnimName);

        PSM.pdl.CAN_BOW = false;
        PSM.pdl.BOW_DRAWN = true;

        PSM.pdl.BOW_CHARGE_TIMER = PSM.pdl.BASE_BOW_CHARGE_TIMER;

        PSM.LoadedProjectile = UnityEngine.Object.Instantiate(
            PSM.arrowPrefab, 
            PSM.arrowSpawnPosition);

        if (!PSM.pdl.INVOKE_IS_GROUNDED(
            PSM.RB2D, 
            PSM.GroundLayer)) 
            return;

        Vector2 vel = PSM.RB2D.velocity;
        vel.x = PSM.pdl.BOW_WALK_SPEED * PSM.pdl.HORIZONTAL_INPUT;
        PSM.RB2D.velocity = vel;
    }

    public override void OnExit()
    {
        base.OnExit();

        PSM.pdl.BOW_CHARGE_TIMER = 0f;
    }

    public override void OnUpdate()
    { 
        base.OnUpdate();

        PSM.pdl.CAN_BOW = Timer.StateTimer(ref PSM.pdl.BOW_CHARGE_TIMER, 0, true);

        if (PSM.pdl.BOW_DRAWN) return;
        PSM.ChangeState(PSM.bowRelease);
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();

        if (!PSM.pdl.INVOKE_IS_GROUNDED(PSM.RB2D, PSM.GroundLayer)) return;
        PSM.pdl.INVOKE_SET_MODIFIED_MOVE_SPEED(PSM.RB2D, PSM.pdl.BOW_WALK_SPEED);
    }
}
