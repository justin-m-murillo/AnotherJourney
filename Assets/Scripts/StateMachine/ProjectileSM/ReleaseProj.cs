public class ReleaseProj : ProjectileState
{
    public override void Init(string stateName, string animName, ProjSM stateMachine)
    {
        base.Init(stateName, animName, stateMachine);
    }

    public override void OnEnter()
    {
        base.OnEnter();

        _projsm.Anim.ChangeAnimationState(_animName);

        float factor = _projsm.Proj.ChargeTime / _projsm.projdl.BASE_CHARGE_TIME;

        _projsm.Proj.Speed *= factor;
        _projsm.Proj.Damage *= factor;


    }
}
