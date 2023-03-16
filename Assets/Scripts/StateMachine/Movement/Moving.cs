using UnityEngine;

public class Moving : Grounded
{
    private bool isFacingRight = true;

    public Moving(MovementSM stateMachine) : base("Moving", stateMachine) 
    {
        _movementSM = (MovementSM)stateMachine;
    }

    public override void OnEnter()
    {
        base.OnEnter();

        _movementSM.HorizontalInput = 0f;

        _movementSM.Anim.TriggerMove();
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
            stateMachine.ChangeState(_movementSM.idleState);
        }
    }

    public override void OnFixedUpdate() 
    {
        base.OnFixedUpdate();

        Vector2 vel = _movementSM.RigBody.velocity;
        vel.x = _horizontalInput * _movementSM.MovementSpeed;
        _movementSM.RigBody.velocity = vel;
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = _movementSM.CharacterTransform.localScale;
        localScale.x *= -1f;
        _movementSM.CharacterTransform.localScale = localScale;
    }
}
