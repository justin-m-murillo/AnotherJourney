using UnityEngine;

public class PInstantiate : MonoBehaviour
{
    public static GameObject P_Instantiate(GameObject original, Transform parent)
    {
        return Instantiate(original, parent);
    }
}
