using UnityEngine;

public class AttackState : CombatState
{
    //public AttackState(PlayerSM stateMachine, int index) : base("Attack" + (index + 1), "P_Attack" + (index + 1), stateMachine) { }
    public AttackState(string stateName, string animName, PlayerSM stateMachine) :
        base(stateName, animName, stateMachine)
    { 
    }

    public override void OnEnter()
    {
        base.OnEnter();

        PSM.pdl.ATTACK_DURATION = PSM.pdl.BASE_ATTACK_DURATION; // delay between attacks to avoid animation canceling
        PSM.pdl.COMBO_DURATION = PSM.pdl.BASE_COMBO_DURATION; // duration to execute another attack before exiting 
        PSM.Anim.ChangeAnimationState(AnimName); 
        PSM.pdl.COMBO_INDEX++;
        PSM.Char.ApplyMeleeDamage(PSM.pdl.ATTACK_DAMAGE);

        if (!PSM.pdl.INVOKE_IS_GROUNDED(PSM.RB2D, PSM.GroundLayer)) return;
        PSM.pdl.INVOKE_GROUND_DRAG(PSM.RB2D, PSM.pdl.BASE_GROUND_DRAG, 3f);
        AttackPush();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        PSM.pdl.CAN_ATTACK = TimeComboDelay();
        bool change = TimeComboDuration();
        
        if (!change) return;
        PSM.ChangeState(PSM.movingState);
    }

    private bool TimeComboDelay()
    {
        PSM.pdl.ATTACK_DURATION = PSM.pdl.ATTACK_DURATION > 0 ?
            PSM.pdl.ATTACK_DURATION - Time.deltaTime
            : 0;

        return PSM.pdl.ATTACK_DURATION == 0;
    }

    private bool TimeComboDuration()
    {
        PSM.pdl.COMBO_DURATION = PSM.pdl.COMBO_DURATION > 0 ?
            PSM.pdl.COMBO_DURATION - Time.deltaTime
            : 0;

        return PSM.pdl.COMBO_DURATION == 0;
    }

    private void AttackPush()
    {
        float facing = PSM.pdl.IS_FACING_RIGHT ? 1f : -1f;
        Vector2 vel = PSM.RB2D.velocity;
        vel.x += facing * PSM.pdl.ATTACK_PUSH_VALUE;
        PSM.RB2D.velocity = vel;
    }
}
