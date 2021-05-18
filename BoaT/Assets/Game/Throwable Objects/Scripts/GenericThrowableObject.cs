using UnityEngine;

public class GenericThrowableObject : MonoBehaviour, IThrowable
{
    public float Weight { get; set; }
    public GameObject Self { get; set; }
    private bool isAttachedToHand;
    private Collider physicsCollider;
    private GameObject baseContainer;
    private Renderer thisRenderer;
    [HideInInspector] public Rigidbody selfRB;
    [HideInInspector] public ThrowableObjectData throwableObjectData;
    private MouseData mouseData;


    void Awake()
    {
        physicsCollider = this.gameObject.transform.GetChild(0).gameObject.GetComponent<Collider>();
        mouseData = FindObjectOfType<MouseData>();
        thisRenderer = this.gameObject.GetComponent<Renderer>();
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

    void Update()
    {
        HighlightSelf();
    }

    public void AttachToPlayer(GameObject playerHand)
    {
        isAttachedToHand = true;
        gameObject.layer = 2;
        this.gameObject.GetComponent<Rigidbody>().useGravity = false;
        this.gameObject.transform.position = playerHand.transform.position;
        this.gameObject.transform.SetParent(playerHand.transform);
        this.gameObject.transform.localRotation = Quaternion.identity;
        ActivateConstraints();
        physicsCollider.enabled = false;
    }
    public void DetachFromPlayer()
    {
        DeactivateConstraints();
        isAttachedToHand = false;
        gameObject.layer = 0;
        this.gameObject.transform.SetParent(baseContainer.transform);
        physicsCollider.enabled = true;
        this.gameObject.GetComponent<Rigidbody>().useGravity = true;
    }
    public void LaunchSelf(float launchSpeed)
    {
        selfRB.velocity = new Vector3(transform.forward.x, transform.forward.y, transform.forward.z) * launchSpeed;
    }
    public void StopForce()
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

    public void HighlightSelf()
    {
        Collider collider = mouseData.GetClickPosition().collider;
        if (collider != null && GameObject.ReferenceEquals(collider.gameObject, this.gameObject)) thisRenderer.material.color = throwableObjectData.highlightColor;
        else thisRenderer.material.color = throwableObjectData.baseColor;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && isAttachedToHand)
        {
            Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), physicsCollider);
        }
    }
}
