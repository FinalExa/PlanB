using UnityEngine;
using UnityEngine.AI;
public class SoulController : MonoBehaviour
{
    [HideInInspector] public bool isInsideStorageRoom;
    [HideInInspector] public bool collidedWithOther;
    public NavMeshAgent thisNavMeshAgent;
    public Rigidbody thisRigidbody;
    [HideInInspector] public GameObject playerIsInRange;
    [HideInInspector] public SoulReferences soulReferences;
    [HideInInspector] public GameObject exit;
    public SoulType[] soulTypes;
    public enum SoulColor { Red, Green, Blue, Yellow, Purple };
    public SoulColor thisSoulColor;
    private void Awake()
    {
        soulReferences = this.gameObject.GetComponent<SoulReferences>();
        exit = GameObject.FindGameObjectWithTag("Exit");
    }
    private void Start()
    {
        TEMPSelectSoul();
        thisNavMeshAgent.speed = soulReferences.soulData.soulMovementSpeed;
        thisNavMeshAgent.acceleration = soulReferences.soulData.soulAcceleration;
    }
    private void TEMPSelectSoul()
    {
        int soulIndex = Random.Range(0, soulTypes.Length);
        thisSoulColor = soulTypes[soulIndex].soulColor;
        soulTypes[soulIndex].soulMeshContainer.transform.parent.gameObject.SetActive(true);
        soulReferences.highlightable.thisGraphicsObject = soulTypes[soulIndex].soulMeshContainer;
        soulReferences.soulThrowableObject.thisGraphicsObject = soulTypes[soulIndex].soulMeshContainer;
        soulReferences.soulThrowableObject.SetBaseColor();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("StorageRoom")) isInsideStorageRoom = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("StorageRoom") && !other.CompareTag("Player")) isInsideStorageRoom = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ground") && !collision.gameObject.CompareTag("Player")) collidedWithOther = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ground") && !collision.gameObject.CompareTag("Player")) collidedWithOther = false;
    }
}
[System.Serializable]
public class SoulType
{
    public SoulController.SoulColor soulColor;
    public GameObject soulMeshContainer;
}
