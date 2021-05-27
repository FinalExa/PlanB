using UnityEngine;
public class SoulController : MonoBehaviour
{
    public bool isInsideStorageRoom;
    [HideInInspector] public SoulReferences soulReferences;
    private void Awake()
    {
        soulReferences = this.gameObject.GetComponent<SoulReferences>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) Physics.IgnoreCollision(this.GetComponent<Collider>(), other);
        if (other.CompareTag("StorageRoom")) isInsideStorageRoom = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("StorageRoom")) isInsideStorageRoom = false;
    }
}
