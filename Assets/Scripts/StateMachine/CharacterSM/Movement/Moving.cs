using UnityEngine;

public class Moving : Grounded
{
    public Moving(string stateName, string animName, PlayerSM stateMachine) :
        base(stateName, animName, stateMachine)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();

        PSM.Anim.ChangeAnimationState(AnimName);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (!PSM.pdl.IS_FACING_RIGHT && PSM.pdl.HORIZONTAL_INPUT > 0f)
        {
            Flip();
        }
        if (PSM.pdl.IS_FACING_RIGHT && PSM.pdl.HORIZONTAL_INPUT < 0f)
        {
            Flip();
        }

        if (Mathf.Abs(PSM.pdl.HORIZONTAL_INPUT) < Mathf.Epsilon)
        {
            PSM.ChangeState(PSM.idleState);
        }
    }

    public override void OnFixedUpdate() 
    {
        base.OnFixedUpdate();

        Vector2 vel = PSM.RB2D.velocity;
        vel.x = PSM.pdl.HORIZONTAL_INPUT * PSM.pdl.BASE_MOVE_SPEED;
        PSM.RB2D.velocity = vel;
    }

    private void Flip()
    {
        PSM.pdl.IS_FACING_RIGHT = !PSM.pdl.IS_FACING_RIGHT;
        Vector3 localScale = PSM.CharacterTransform.localScale;
        localScale.x *= -1f;
        PSM.CharacterTransform.localScale = localScale;
    }
}
