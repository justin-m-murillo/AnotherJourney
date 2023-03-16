using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimCallbackManager : MonoBehaviour
{
    [SerializeField] PlayerSM _psm;

    public void CallbackAttackAnimComplete(int index)
    {
        //_psm.attackStates[index].AnimComplete = true;
    }
}
