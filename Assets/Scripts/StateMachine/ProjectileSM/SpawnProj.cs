using UnityEngine;

public class SpawnProj : ProjectileState
{
    public override void Init(string stateName, string animName, ProjSM stateMachine)
    {
        base.Init(stateName, animName, stateMachine);
    }

    public override void OnEnter()
    {
        base.OnEnter();
        _projsm.Anim.ChangeAnimationState(_animName);
        _projsm.Proj.Speed = _projsm.projdl.BASE_SPEED;
        _projsm.Proj.Damage = _projsm.projdl.BASE_DAMAGE;
        _projsm.Proj.ChargeTime = _projsm.projdl.BASE_CHARGE_TIME;
        _projsm.Proj.IsCharged = false;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        _projsm.Proj.IsCharged = ChargeProjectile();

        if (!_projsm.Proj.IsCharged) return;
        stateMachine.ChangeState(_projsm.chargedState);
    }

    private bool ChargeProjectile()
    {
        _projsm.Proj.ChargeTime = _projsm.Proj.ChargeTime < _projsm.projdl.BASE_CHARGE_TIME ?
            _projsm.Proj.ChargeTime + Time.deltaTime :
            _projsm.projdl.BASE_CHARGE_TIME;

        return _projsm.Proj.ChargeTime == _projsm.projdl.BASE_CHARGE_TIME;
    }
}
