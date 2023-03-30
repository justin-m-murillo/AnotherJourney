using UnityEngine;

public class SpawnProj : ProjectileState
{
    public SpawnProj(string stateName, string animName, ProjSM stateMachine) :
        base(stateName, animName, stateMachine)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        PrSM.Anim.ChangeAnimationState(AnimName);
        PrSM.Proj.Speed = PrSM.projdl.BASE_SPEED;
        PrSM.Proj.Damage = PrSM.projdl.BASE_DAMAGE;
        PrSM.Proj.ChargeTime = PrSM.projdl.BASE_CHARGE_TIME;
        PrSM.Proj.IsCharged = false;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        PrSM.Proj.IsCharged = ChargeProjectile();

        if (!PrSM.Proj.IsCharged) return;
        PrSM.ChangeState(PrSM.chargedState);
    }

    private bool ChargeProjectile()
    {
        PrSM.Proj.ChargeTime = PrSM.Proj.ChargeTime < PrSM.projdl.BASE_CHARGE_TIME ?
            PrSM.Proj.ChargeTime + Time.deltaTime :
            PrSM.projdl.BASE_CHARGE_TIME;

        return PrSM.Proj.ChargeTime == PrSM.projdl.BASE_CHARGE_TIME;
    }
}
