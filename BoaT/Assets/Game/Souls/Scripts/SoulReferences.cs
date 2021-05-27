using UnityEngine;

public class SoulReferences : MonoBehaviour
{
    [HideInInspector] public ThrowableObject throwableObject;

    private void Awake()
    {
        throwableObject = this.gameObject.GetComponent<ThrowableObject>();
    }
}
