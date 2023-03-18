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
        
        _psm.psl.bowChargeTimer = _psm.psl.defaultBowChargeTimer;

        if (_psm.psl.IsGrounded(_psm.RigBody, _psm.GroundLayer))
        {
            Vector2 vel = _psm.RigBody.velocity;
            vel.x = _psm.psl.bowWalkSpeed * _psm.psl.horizontalInput;
            _psm.RigBody.velocity = vel;
        }
        
        _psm.Anim.ChangeAnimationState(_animName);
    }

    public override void OnExit()
    {
        base.OnExit();

        _psm.psl.bowChargeTimer = 0f;
    }

    public override void OnUpdate()
    { 
        base.OnUpdate();
        _psm.psl.canBow = TimeBowFireDelay();

        if (_psm.psl.bowDrawn == false)
        {
            stateMachine.ChangeState(_psm.bowRelease);
        }    
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();
        if (!_psm.psl.IsGrounded(_psm.RigBody, _psm.GroundLayer)) return;
        _psm.psl.SetModifiedMovementSpeed(_psm.RigBody, _psm.psl.bowWalkSpeed);
    }

    private bool TimeBowFireDelay()
    {
        _psm.psl.bowChargeTimer = _psm.psl.bowChargeTimer > 0 ?
            _psm.psl.bowChargeTimer - Time.deltaTime : 
            0;

        return _psm.psl.bowChargeTimer == 0;
    }
}
