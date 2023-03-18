using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowDraw : CombatState
{
    //public BowDraw(PlayerSM stateMachine) : base("BowDraw", "P_BowDraw", stateMachine) { }
    public override void Init(string stateName, string animName, PlayerSM stateMachine)
    {
        base.Init(stateName, animName, stateMachine);
    }

    public override void OnEnter()
    {
        base.OnEnter();
        
        _psm.pdl.BOW_CHARGE_TIMER = _psm.pdl.DEFAULT_BOW_CHARGE_TIMER;

        if (_psm.pdl.INVOKE_IS_GROUNDED(_psm.RigBody, _psm.GroundLayer))
        {
            Vector2 vel = _psm.RigBody.velocity;
            vel.x = _psm.pdl.BOW_WALK_SPEED * _psm.pdl.HORIZONTAL_INPUT;
            _psm.RigBody.velocity = vel;
        }
        
        _psm.Anim.ChangeAnimationState(_animName);
    }

    public override void OnExit()
    {
        base.OnExit();

        _psm.pdl.BOW_CHARGE_TIMER = 0f;
    }

    public override void OnUpdate()
    { 
        base.OnUpdate();
        _psm.pdl.CAN_BOW = TimeBowFireDelay();

        if (_psm.pdl.BOW_DRAWN == false)
        {
            stateMachine.ChangeState(_psm.bowRelease);
        }    
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();
        if (!_psm.pdl.INVOKE_IS_GROUNDED(_psm.RigBody, _psm.GroundLayer)) return;
        _psm.pdl.INVOKE_SET_MODIFIED_MOVE_SPEED(_psm.RigBody, _psm.pdl.BOW_WALK_SPEED);
    }

    private bool TimeBowFireDelay()
    {
        _psm.pdl.BOW_CHARGE_TIMER = _psm.pdl.BOW_CHARGE_TIMER > 0 ?
            _psm.pdl.BOW_CHARGE_TIMER - Time.deltaTime : 
            0;

        return _psm.pdl.BOW_CHARGE_TIMER == 0;
    }
}
