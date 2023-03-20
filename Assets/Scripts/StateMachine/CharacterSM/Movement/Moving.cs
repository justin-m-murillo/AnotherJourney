using UnityEngine;

public class Moving : Grounded
{
    public override void Init(string stateName, string animName, PlayerSM stateMachine)
    {
        base.Init(stateName, animName, stateMachine);
    }

    public override void OnEnter()
    {
        base.OnEnter();

        //_psm.HorizontalInput = 0f;
        _psm.Anim.ChangeAnimationState(_animName);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (!_psm.pdl.IS_FACING_RIGHT && _psm.pdl.HORIZONTAL_INPUT > 0f)
        {
            Flip();
        }
        if (_psm.pdl.IS_FACING_RIGHT && _psm.pdl.HORIZONTAL_INPUT < 0f)
        {
            Flip();
        }

        if (Mathf.Abs(_psm.pdl.HORIZONTAL_INPUT) < Mathf.Epsilon)
        {
            stateMachine.ChangeState(_psm.idleState);
        }
    }

    public override void OnFixedUpdate() 
    {
        base.OnFixedUpdate();

        Vector2 vel = _psm.RigBody.velocity;
        vel.x = _psm.pdl.HORIZONTAL_INPUT * _psm.pdl.BASE_MOVE_SPEED;
        _psm.RigBody.velocity = vel;
    }

    private void Flip()
    {
        _psm.pdl.IS_FACING_RIGHT = !_psm.pdl.IS_FACING_RIGHT;
        Vector3 localScale = _psm.CharacterTransform.localScale;
        localScale.x *= -1f;
        _psm.CharacterTransform.localScale = localScale;
    }
}
