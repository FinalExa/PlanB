using UnityEngine;

public class ThrowableObject : MonoBehaviour, IThrowable
{
    public float Weight { get; set; }
    public GameObject Self { get; set; }
    public bool isInsidePlayerRange { get; set; }
    private float throwSpeed;
    private float flightTimer;
    private float throwDistance;
    private float flightTime;
    private bool isAttachedToHand;
    private bool isFlying;
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
        this.gameObject.transform.SetParent(baseContainer.transform);
    }
    void Update()
    {
        if (isFlying) FlightTime();
    }
    public void AttachToPlayer(GameObject playerHand)
    {
        isFlying = false;
        isAttachedToHand = true;
        StopForce();
        gameObject.layer = 2;
        ActivateConstraints();
        this.gameObject.transform.position = playerHand.transform.position;
        this.gameObject.transform.SetParent(playerHand.transform);
        this.gameObject.transform.localRotation = Quaternion.identity;
        physicsCollider.enabled = false;
    }
    public void DetachFromPlayer(float throwDistanceObtained, float flightTimeObtained)
    {
        throwDistance = throwDistanceObtained;
        flightTime = flightTimeObtained;
        DeactivateConstraintsExceptGravity();
        gameObject.layer = 0;
        this.gameObject.transform.SetParent(baseContainer.transform);
        isAttachedToHand = false;
        physicsCollider.enabled = true;
        LaunchSelf();
    }
    private void LaunchSelf()
    {
        throwSpeed = throwDistance / flightTime;
        flightTimer = flightTime;
        isFlying = true;
    }
    private void FlightTime()
    {
        float relativeSpeed;
        if (flightTimer > 0)
        {
            float offsetToRemove = (throwSpeed * flightTime) * (flightTime - flightTimer);
            relativeSpeed = throwSpeed - offsetToRemove;
            SpeedFormula(relativeSpeed);
            flightTimer -= Time.deltaTime;
        }
        else
        {
            DeactivateConstraintsTotally();
            isFlying = false;
        }
    }
    private void SpeedFormula(float speed)
    {
        selfRB.velocity = new Vector3(transform.forward.x, transform.forward.y, transform.forward.z) * speed;
    }
    private void StopForce()
    {
        selfRB.velocity = Vector3.zero;
    }
    private void ActivateConstraints()
    {
        selfRB.constraints = RigidbodyConstraints.FreezeAll;
    }
    private void DeactivateConstraintsExceptGravity()
    {
        selfRB.constraints = RigidbodyConstraints.None | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }
    private void DeactivateConstraintsTotally()
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
