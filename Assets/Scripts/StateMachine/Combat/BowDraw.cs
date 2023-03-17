using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowDraw : CombatState
{
    public BowDraw(PlayerSM stateMachine) : base("BowDraw", stateMachine) { }

    public override void OnEnter()
    {
        base.OnEnter();
        _psm.psl.bowFireDelay = _psm.psl.defaultBowFireDelay;

        if (_psm.psl.IsGrounded(_psm.RigBody, _psm.GroundLayer))
        {
            Vector2 vel = _psm.RigBody.velocity;
            vel.x = _psm.psl.bowWalkSpeed * _psm.psl.horizontalInput;
            _psm.RigBody.velocity = vel;
        }
        
        _psm.Anim.TriggerBowDraw();
    }

    public override void OnUpdate()
    { 
        base.OnUpdate();
        TimeBowFireDelay();

        if (_psm.psl.bowDrawn == false)
        {
            stateMachine.ChangeState(_psm.bowRelease);
        }    
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();

        if (!_psm.psl.IsGrounded(_psm.RigBody, _psm.GroundLayer)) return;

        if (Mathf.Abs(_psm.psl.horizontalInput) > Mathf.Epsilon)
        {
            Vector2 vel = _psm.RigBody.velocity;
            vel.x = _psm.psl.bowWalkSpeed * _psm.psl.horizontalInput;
            _psm.RigBody.velocity = vel;
        }
    }

    private void TimeBowFireDelay()
    {
        _psm.psl.bowFireDelay = _psm.psl.bowFireDelay > 0 ?
            _psm.psl.bowFireDelay - Time.deltaTime : 
            0;

        if (Mathf.Abs(_psm.psl.bowFireDelay) < Mathf.Epsilon)
        {
            _psm.psl.canBow = true;
        }
    }
}
