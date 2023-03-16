using UnityEngine;

public class Moving : Grounded
{
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

        if (!static_isFacingRight && static_horizontalInput > 0f)
        {
            Flip();
        }
        if (static_isFacingRight && static_horizontalInput < 0f)
        {
            Flip();
        }

        if (Mathf.Abs(static_horizontalInput) < Mathf.Epsilon)
        {
            stateMachine.ChangeState(_psm.idleState);
        }
    }

    public override void OnFixedUpdate() 
    {
        base.OnFixedUpdate();

        Vector2 vel = _psm.RigBody.velocity;
        vel.x = static_horizontalInput * _psm.MovementSpeed;
        _psm.RigBody.velocity = vel;
    }

    private void Flip()
    {
        static_isFacingRight = !static_isFacingRight;
        Vector3 localScale = _psm.CharacterTransform.localScale;
        localScale.x *= -1f;
        _psm.CharacterTransform.localScale = localScale;
    }
}
