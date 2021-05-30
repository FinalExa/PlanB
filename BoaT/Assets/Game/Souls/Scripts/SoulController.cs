using UnityEngine;
using UnityEngine.AI;
public class SoulController : MonoBehaviour
{
    public bool isInsideStorageRoom;
    public NavMeshAgent thisNavMeshAgent;
    public Rigidbody thisRigidbody;
    [HideInInspector] public bool playerIsInRange;
    [HideInInspector] public SoulReferences soulReferences;
    [SerializeField] private float soulDetectionRange;
    private void Awake()
    {
        soulReferences = this.gameObject.GetComponent<SoulReferences>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("StorageRoom")) isInsideStorageRoom = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("StorageRoom")) isInsideStorageRoom = false;
    }
}
