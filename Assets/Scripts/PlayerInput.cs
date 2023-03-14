using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] CharMoveController _cmc;
    [SerializeField] PlayerCombat _pc;

    public void JumpInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _cmc.Jump(true);
        }

        if (context.canceled)
        {
            _cmc.Jump(false);
        }
    }

    public void MoveInput(InputAction.CallbackContext context)
    {
        _cmc.Move(context.ReadValue<Vector2>().x);
    }

    public void AttackInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _pc.Attack();
        }
    }
}
