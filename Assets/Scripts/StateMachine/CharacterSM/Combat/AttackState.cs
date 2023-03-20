using UnityEngine;

public class AttackState : CombatState
{
    //public AttackState(PlayerSM stateMachine, int index) : base("Attack" + (index + 1), "P_Attack" + (index + 1), stateMachine) { }
    public override void Init(string stateName, string animName, PlayerSM stateMachine)
    {
        base.Init(stateName, animName, stateMachine);
    }

    public override void OnEnter()
    {
        base.OnEnter();

        _psm.pdl.ATTACK_DURATION = _psm.pdl.BASE_ATTACK_DURATION; // delay between attacks to avoid animation canceling
        _psm.pdl.COMBO_DURATION = _psm.pdl.BASE_COMBO_DURATION; // duration to execute another attack before exiting 
        _psm.Anim.ChangeAnimationState(_animName); 
        _psm.pdl.COMBO_INDEX++;

        if (!_psm.pdl.INVOKE_IS_GROUNDED(_psm.RigBody, _psm.GroundLayer)) return;
        _psm.pdl.INVOKE_GROUND_DRAG(_psm.RigBody, _psm.pdl.BASE_GROUND_DRAG, 3f);
        AttackPush();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        _psm.pdl.CAN_ATTACK = TimeComboDelay();
        bool change = TimeComboDuration();
        
        if (!change) return;
        stateMachine.ChangeState(_psm.movingState);
    }

    private bool TimeComboDelay()
    {
        _psm.pdl.ATTACK_DURATION = _psm.pdl.ATTACK_DURATION > 0 ?
            _psm.pdl.ATTACK_DURATION - Time.deltaTime
            : 0;

        return _psm.pdl.ATTACK_DURATION == 0;
    }

    private bool TimeComboDuration()
    {
        _psm.pdl.COMBO_DURATION = _psm.pdl.COMBO_DURATION > 0 ?
            _psm.pdl.COMBO_DURATION - Time.deltaTime
            : 0;

        return _psm.pdl.COMBO_DURATION == 0;
    }

    private void AttackPush()
    {
        float facing = _psm.pdl.IS_FACING_RIGHT ? 1f : -1f;
        Vector2 vel = _psm.RigBody.velocity;
        vel.x += facing * _psm.pdl.ATTACK_PUSH_VALUE;
        _psm.RigBody.velocity = vel;
    }
}
