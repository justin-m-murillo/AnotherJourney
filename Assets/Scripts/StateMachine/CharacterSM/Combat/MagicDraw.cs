using UnityEngine;

public class MagicDraw : CombatState
{
    public MagicDraw(string stateName, string animName, PlayerSM stateMachine) :
        base(stateName, animName, stateMachine)
    { 
    }

    public override void OnEnter()
    {
        base.OnEnter();

        PSM.Anim.ChangeAnimationState(AnimName);

        PSM.pdl.CAN_MAGIC = false;
        PSM.pdl.MAGIC_DRAWN = true;

        PSM.pdl.MAGIC_CHARGE_TIMER = PSM.pdl.BASE_MAGIC_CHARGE_TIMER;

        PSM.LoadedProjectile = Object.Instantiate(
            PSM.magicPrefab,
            PSM.magicSpawnPosition);

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

        PSM.pdl.MAGIC_CHARGE_TIMER = 0f;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        PSM.pdl.CAN_MAGIC = Timer.StateTimer(ref PSM.pdl.MAGIC_CHARGE_TIMER, 0, true);

        if (PSM.pdl.MAGIC_DRAWN) return;
        PSM.ChangeState(PSM.magicRelease);
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();

        if (!PSM.pdl.INVOKE_IS_GROUNDED(PSM.RB2D, PSM.GroundLayer)) return;
        PSM.pdl.INVOKE_SET_MODIFIED_MOVE_SPEED(PSM.RB2D, PSM.pdl.MAGIC_WALK_SPEED);
    }
}
