public class ChargedProj : ProjectileState
{
    public override void Init(string stateName, string animName, ProjSM stateMachine)
    {
        base.Init(stateName, animName, stateMachine);
    }

    public override void OnEnter()
    {
        base.OnEnter();

        _projsm.Anim.ChangeAnimationState(_animName);
    }
}
