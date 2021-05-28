using UnityEngine;
public class SoulController : MonoBehaviour
{
    public bool isInsideStorageRoom;
    [HideInInspector] public bool playerIsInRange;
    [HideInInspector] public SoulReferences soulReferences;
    [SerializeField] private float soulDetectionRange;
    private void Awake()
    {
        soulReferences = this.gameObject.GetComponent<SoulReferences>();
    }
    private void GetPlayerInRange()
    {
        bool playerFound = false;
        Collider[] colliders = Physics.OverlapSphere(this.transform.position, soulDetectionRange);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                playerFound = true;
                playerIsInRange = true;
                break;
            }
        }
        if (playerFound) playerIsInRange = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) playerIsInRange = true;
        if (other.CompareTag("StorageRoom")) isInsideStorageRoom = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) playerIsInRange = false;
        if (other.CompareTag("StorageRoom")) isInsideStorageRoom = false;
    }
}
