using UnityEngine;

public class ThrowableObject : MonoBehaviour, IThrowable
{
    public float Weight { get; set; }
    public GameObject Self { get; set; }
    public bool isInsidePlayerRange { get; set; }

    private bool isAttachedToHand;
    private BoxCollider physicsCollider;
    private GameObject baseContainer;
    [HideInInspector] public Rigidbody selfRB;
    [HideInInspector] public ThrowableObjectData throwableObjectData;

    void Awake()
    {
        physicsCollider = this.gameObject.GetComponent<BoxCollider>();
        baseContainer = GameObject.FindGameObjectWithTag("GenericObjectsContainer");
        throwableObjectData.baseColor = this.gameObject.GetComponent<Renderer>().material.color;
        Self = this.gameObject;
        selfRB = Self.GetComponent<Rigidbody>();
    }

    void Start()
    {
        Weight = throwableObjectData.objectWeight;
        isAttachedToHand = false;
        this.gameObject.transform.SetParent(baseContainer.transform);
    }
    public void AttachToPlayer(GameObject playerHand)
    {
        isAttachedToHand = true;
        StopForce();
        gameObject.layer = 2;
        ActivateConstraints();
        this.gameObject.transform.position = playerHand.transform.position;
        this.gameObject.transform.SetParent(playerHand.transform);
        this.gameObject.transform.localRotation = Quaternion.identity;
        physicsCollider.enabled = false;
    }
    public void DetachFromPlayer(float throwSpeed)
    {
        DeactivateConstraints();
        gameObject.layer = 0;
        this.gameObject.transform.SetParent(baseContainer.transform);
        isAttachedToHand = false;
        physicsCollider.enabled = true;
        LaunchSelf(throwSpeed);
    }
    private void LaunchSelf(float throwSpeed)
    {
        selfRB.velocity = new Vector3(transform.forward.x, transform.forward.y, transform.forward.z) * throwSpeed;
    }
    private void StopForce()
    {
        selfRB.velocity = Vector3.zero;
    }
    private void ActivateConstraints()
    {
        selfRB.constraints = RigidbodyConstraints.FreezeAll;
    }
    private void DeactivateConstraints()
    {
        selfRB.constraints = RigidbodyConstraints.None | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && isAttachedToHand)
        {
            Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), physicsCollider);
        }
    }
}
