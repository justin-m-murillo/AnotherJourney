public class ChargedProj : ProjectileState
{
    public ChargedProj(string stateName, string animName, ProjSM stateMachine) :
        base(stateName, animName, stateMachine)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();

        PrSM.Anim.ChangeAnimationState(AnimName);
    }
}
