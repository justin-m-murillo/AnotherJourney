using UnityEngine;

public class CombatState : ContainerState
{
    public CombatState(string name, PlayerSM stateMachine) : base(name, stateMachine)
    {
        _psm = (PlayerSM)stateMachine;

        //controls.PlayerControlsMap.Attack.performed += AttackPerformed;
        //controls.PlayerControlsMap.Attack.canceled += AttackCanceled;
    }

    public override void OnEnter()
    {
        base.OnEnter();

        static_canAttack = false;
        static_comboDelay = static_defaultComboDelay;
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        static_comboDelay = static_comboDelay > 0 ?
            static_comboDelay - Time.deltaTime
            : 0;

        if (static_comboDelay == 0)
        {
            static_canAttack = true;
        }

        static_comboDuration = static_comboDuration > 0 ?
            static_comboDuration - Time.deltaTime
            : 0;

        if (static_comboDuration == 0)
        {
            static_comboIndex = 0;
            stateMachine.ChangeState(_psm.idleState);
        }
    }

    public int Index() { return static_comboIndex; }

    
    //public void AttackPerformed(InputAction.CallbackContext context) { }
    //public virtual void AttackCanceled(InputAction.CallbackContext context) { }


}
