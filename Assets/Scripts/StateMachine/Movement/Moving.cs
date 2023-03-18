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

        if (!_psm.psl.isFacingRight && _psm.psl.horizontalInput > 0f)
        {
            Flip();
        }
        if (_psm.psl.isFacingRight && _psm.psl.horizontalInput < 0f)
        {
            Flip();
        }

        if (Mathf.Abs(_psm.psl.horizontalInput) < Mathf.Epsilon)
        {
            stateMachine.ChangeState(_psm.idleState);
        }
    }

    public override void OnFixedUpdate() 
    {
        base.OnFixedUpdate();

        Vector2 vel = _psm.RigBody.velocity;
        vel.x = _psm.psl.horizontalInput * _psm.MovementSpeed;
        _psm.RigBody.velocity = vel;
    }

    private void Flip()
    {
        _psm.psl.isFacingRight = !_psm.psl.isFacingRight;
        Vector3 localScale = _psm.CharacterTransform.localScale;
        localScale.x *= -1f;
        _psm.CharacterTransform.localScale = localScale;
    }
}
