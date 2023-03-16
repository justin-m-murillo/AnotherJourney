using UnityEngine;

public class Moving : Grounded
{
    private bool isFacingRight = true;

    public Moving(PlayerSM stateMachine) : base("Moving", stateMachine) 
    {
        _psm = (PlayerSM)stateMachine;
    }

    public override void OnEnter()
    {
        base.OnEnter();

        //_psm.HorizontalInput = 0f;
        _psm.Anim.TriggerMove();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (!isFacingRight && _horizontalInput > 0f)
        {
            Flip();
        }
        if (isFacingRight && _horizontalInput < 0f)
        {
            Flip();
        }

        if (Mathf.Abs(_horizontalInput) < Mathf.Epsilon)
        {
            stateMachine.ChangeState(_psm.idleState);
        }
    }

    public override void OnFixedUpdate() 
    {
        base.OnFixedUpdate();

        Vector2 vel = _psm.RigBody.velocity;
        vel.x = _horizontalInput * _psm.MovementSpeed;
        _psm.RigBody.velocity = vel;
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = _psm.CharacterTransform.localScale;
        localScale.x *= -1f;
        _psm.CharacterTransform.localScale = localScale;
    }
}
