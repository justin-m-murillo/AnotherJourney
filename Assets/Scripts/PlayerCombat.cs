using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] Animator _anim;
    [SerializeField] float _comboDuration;
    [SerializeField] float _comboDelay;
    [SerializeField] string[] _meleeComboMoves;

    private float _duration;
    private float _delay;
    private int _attackIndex;
    private bool _isAttacking;

    void Start()
    {
        _duration = 0f;
        _delay = 0f;
        _attackIndex = 0;
        _isAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(_duration);
        if (_isAttacking)
        {
            _duration = _duration > 0 ? _duration - Time.deltaTime : 0;
            _delay = _delay > 0 ? _delay - Time.deltaTime : 0;
        }

        if (_duration == 0)
        {
            _isAttacking = false;
            _attackIndex = 0;
        }
    }

    public void Attack()
    {
        if (_delay > 0)
        {
            return;
        }

        if (_attackIndex < _meleeComboMoves.Length)
        {
            _isAttacking = true;
            _duration = _comboDuration;
            _delay = _comboDelay;
            _anim.SetTrigger(_meleeComboMoves[_attackIndex]);
            _attackIndex++;
        }
    }
}
