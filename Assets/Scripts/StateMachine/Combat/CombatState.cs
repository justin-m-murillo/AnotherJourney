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

        //static_canAttack = false;
        _psm.psl.jumpCooldown = _psm.psl.defaultJumpCooldown;
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        _psm.psl.comboDelay = _psm.psl.comboDelay > 0 ?
            _psm.psl.comboDelay - Time.deltaTime
            : 0;

        if (_psm.psl.comboDelay == 0)
        {
            _psm.psl.canAttack = true;
        }

        _psm.psl.comboDuration = _psm.psl.comboDuration > 0 ?
            _psm.psl.comboDuration - Time.deltaTime
            : 0;

        if (_psm.psl.comboDuration == 0)
        {
            _psm.psl.comboIndex = 0;
            stateMachine.ChangeState(_psm.idleState);
        }
    }

    public int Index() { return _psm.psl.comboIndex; }

    
    //public void AttackPerformed(InputAction.CallbackContext context) { }
    //public virtual void AttackCanceled(InputAction.CallbackContext context) { }


}
