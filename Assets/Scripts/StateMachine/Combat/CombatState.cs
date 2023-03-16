using UnityEngine;

public class CombatState : ContainerState
{
    public static float static_defaultComboDuration = 0.7f;
    public static float static_comboDuration = static_defaultComboDuration;

    public static float static_defaultComboDelay = 0.3f;
    public static float static_comboDelay = static_defaultComboDelay;
    public static bool static_canAttack = true;
    public static int static_comboIndex = 0;

    public CombatState(string name, PlayerSM stateMachine) : base(name, stateMachine)
    {
        _psm = (PlayerSM)stateMachine;

        //controls.PlayerControlsMap.Attack.performed += AttackPerformed;
        //controls.PlayerControlsMap.Attack.canceled += AttackCanceled;
    }

    public override void OnEnter()
    {
        base.OnEnter();

        //static_canAttack = false;
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
            CombatState.static_comboIndex = 0;
            stateMachine.ChangeState(_psm.idleState);
        }
    }

    public int Index() { return CombatState.static_comboIndex; }

    
    //public void AttackPerformed(InputAction.CallbackContext context) { }
    //public virtual void AttackCanceled(InputAction.CallbackContext context) { }


}
