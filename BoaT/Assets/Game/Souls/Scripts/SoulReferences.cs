using UnityEngine;

public class SoulReferences : MonoBehaviour
{
    [HideInInspector] public SoulThrowable soulThrowableObject;
    public SoulData soulData;
    private void Awake()
    {
        soulThrowableObject = this.gameObject.GetComponent<SoulThrowable>();
    }
}
