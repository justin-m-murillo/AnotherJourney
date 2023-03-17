using UnityEngine;

public class AttackState : CombatState
{
    public AttackState(PlayerSM stateMachine, int index) : base("Attack" + (index + 1), stateMachine)
    {
        _psm = (PlayerSM)stateMachine;
    }

    public override void OnEnter()
    {
        base.OnEnter();

        if (Grounded.IsGrounded())
        {
            Grounded.ApplyGroundDrag(3f);
            AttackPush();
        }
        _psm.psl.comboDuration = _psm.psl.defaultComboDuration;
        _psm.psl.comboDelay = _psm.psl.defaultComboDelay;
        _psm.Anim.TriggerAttack(name);
        
        _psm.psl.comboIndex++;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

    }

    private void AttackPush()
    {
        float facing = _psm.psl.isFacingRight ? 1f : -1f;
        Vector2 vel = _psm.RigBody.velocity;
        vel.x += facing * _psm.AttackPushValue;
        _psm.RigBody.velocity = vel;
    }
}
