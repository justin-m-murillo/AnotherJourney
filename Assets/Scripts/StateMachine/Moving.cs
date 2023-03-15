using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Moving : Grounded
{
    private bool isFacingRight = true;
    private float calcSpeed = 0f;

    public Moving(MovementSM stateMachine) : base("Moving", stateMachine) 
    {
        _movementSM = stateMachine;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        _movementSM.Anim.TriggerMove();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        
        if (Mathf.Abs(_movementSM.HorizontalInput) < Mathf.Epsilon)
        {
            stateMachine.ChangeState(_movementSM.idleState);
        }
    }

    public override void OnFixedUpdate() 
    {
        base.OnFixedUpdate();

        calcSpeed = _movementSM.IsGrounded() ? _movementSM.HorizontalInput * _movementSM.MovementSpeed : calcSpeed;
        
        _movementSM.RBody.velocity = new Vector2(
            calcSpeed, 
            _movementSM.RBody.velocity.y);

        if (!isFacingRight && _movementSM.HorizontalInput > 0f)
        {
            Flip();
        }
        if (isFacingRight && _movementSM.HorizontalInput < 0f)
        {
            Flip();
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = _movementSM.CharacterTransform.localScale;
        localScale.x *= -1f;
        _movementSM.CharacterTransform.localScale = localScale;
    }
}
