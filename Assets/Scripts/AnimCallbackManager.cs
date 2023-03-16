using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimCallbackManager : MonoBehaviour
{
    [SerializeField] CombatSM _csm;

    public void CallbackAttackAnimComplete(int index)
    {
        _csm.attackStates[index].AnimComplete = true;
    }
}
