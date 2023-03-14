using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    [SerializeField] CharMoveController _cmc;

    private Animator _anim;
    
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _anim.SetBool("IsMoving", _cmc.isMoving);
        _anim.SetBool("IsGrounded", _cmc.IsGrounded());

        int airInput;
        if ( !_cmc.IsGrounded() )
        {
            airInput = _cmc.y_diff switch
            {
                > 0 => 1,
                < 0 => -1,
                _ => 0,
            };
        }
        else
        {
            airInput = 0;
        }
        _anim.SetInteger("IsAir", airInput);

        int attackInput = _cmc.attackComboCount;
        _anim.SetInteger("IsAttacking", attackInput);

    }

    public void TerminateAttackCombo()
    {
        _cmc.attackComboCount = 0;
    }
}
