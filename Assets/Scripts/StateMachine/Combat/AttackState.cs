using UnityEngine;

public class AttackState : CombatState
{
    public AttackState(PlayerSM stateMachine, int index) : base("Attack" + (index + 1), "P_Attack" + (index + 1), stateMachine) { }

    public override void OnEnter()
    {
        base.OnEnter();

        if (_psm.psl.IsGrounded(_psm.RigBody, _psm.GroundLayer))
        {
            _psm.psl.ApplyGroundDrag(_psm.RigBody, _psm.DragFactor, 3f);
            AttackPush();
        }

        _psm.psl.comboDelay = _psm.psl.defaultComboDelay; // delay between attacks to avoid animation canceling
        _psm.psl.comboDuration = _psm.psl.defaultComboDuration; // duration to execute another attack before exiting 
        _psm.Anim.ChangeAnimationState(_animName); 
        _psm.psl.comboIndex++; 
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        _psm.psl.canAttack = TimeComboDelay();
        bool change = TimeComboDuration();
        if (!change) return;

        stateMachine.ChangeState(_psm.movingState);
    }

    private bool TimeComboDelay()
    {
        _psm.psl.comboDelay = _psm.psl.comboDelay > 0 ?
            _psm.psl.comboDelay - Time.deltaTime
            : 0;

        return _psm.psl.comboDelay == 0;
    }

    private bool TimeComboDuration()
    {
        _psm.psl.comboDuration = _psm.psl.comboDuration > 0 ?
            _psm.psl.comboDuration - Time.deltaTime
            : 0;

        return _psm.psl.comboDuration == 0;
    }

    private void AttackPush()
    {
        float facing = _psm.psl.isFacingRight ? 1f : -1f;
        Vector2 vel = _psm.RigBody.velocity;
        vel.x += facing * _psm.AttackPushValue;
        _psm.RigBody.velocity = vel;
    }
}
