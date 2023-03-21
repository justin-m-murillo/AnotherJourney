using UnityEngine;

public class MagicDraw : CombatState
{
    public override void Init(string stateName, string animName, PlayerSM stateMachine)
    {
        base.Init(stateName, animName, stateMachine);
    }

    public override void OnEnter()
    {
        base.OnEnter();

        _psm.Anim.ChangeAnimationState(_animName);

        _psm.pdl.CAN_MAGIC = false;
        _psm.pdl.MAGIC_DRAWN = true;

        _psm.pdl.MAGIC_CHARGE_TIMER = _psm.pdl.BASE_MAGIC_CHARGE_TIMER;

        _psm.LoadedProjectile = Instantiate(
            _psm.magicPrefab,
            _psm.magicSpawnPosition);

        if (!_psm.pdl.INVOKE_IS_GROUNDED(
            _psm.RigBody,
            _psm.GroundLayer))
            return;

        Vector2 vel = _psm.RigBody.velocity;
        vel.x = _psm.pdl.BOW_WALK_SPEED * _psm.pdl.HORIZONTAL_INPUT;
        _psm.RigBody.velocity = vel;
    }

    public override void OnExit()
    {
        base.OnExit();

        _psm.pdl.MAGIC_CHARGE_TIMER = 0f;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        _psm.pdl.CAN_MAGIC = StateTimer(ref _psm.pdl.MAGIC_CHARGE_TIMER, 0, true);

        if (_psm.pdl.MAGIC_DRAWN) return;
        stateMachine.ChangeState(_psm.magicRelease);
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();

        if (!_psm.pdl.INVOKE_IS_GROUNDED(_psm.RigBody, _psm.GroundLayer)) return;
        _psm.pdl.INVOKE_SET_MODIFIED_MOVE_SPEED(_psm.RigBody, _psm.pdl.MAGIC_WALK_SPEED);
    }
}
