public class ReleaseProj : ProjectileState
{
    public ReleaseProj(string stateName, string animName, ProjSM stateMachine) :
        base(stateName, animName, stateMachine)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();

        PrSM.Anim.ChangeAnimationState(AnimName);

        float factor = PrSM.Proj.ChargeTime / PrSM.projdl.BASE_CHARGE_TIME;

        PrSM.Proj.Speed *= factor;
        PrSM.Proj.Damage *= factor;
    }
}
