using UnityEngine;
public class SoulController : MonoBehaviour
{
    [HideInInspector] public SoulReferences soulReferences;

    private void Awake()
    {
        soulReferences = this.gameObject.GetComponent<SoulReferences>();
    }
}
