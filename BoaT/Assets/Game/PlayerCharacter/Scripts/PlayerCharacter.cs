using UnityEngine;
public class PlayerCharacter : StateMachine
{
    [HideInInspector] public PlayerData playerData;
    [HideInInspector] public Rotation rotation;
    [HideInInspector] public PlayerInputs playerInputs;
    [HideInInspector] public MouseData mouseData;
    [HideInInspector] public ObjectsOnMouse objectsOnMouse;
    [HideInInspector] public Rigidbody playerRb;
    [HideInInspector] public Collider[] objectsInPlayerRange;
    public GameObject LeftHand;
    public GameObject RightHand;

    private void Awake()
    {
        playerInputs = this.gameObject.GetComponent<PlayerInputs>();
        playerRb = this.gameObject.GetComponent<Rigidbody>();
        mouseData = FindObjectOfType<MouseData>();
        objectsOnMouse = FindObjectOfType<ObjectsOnMouse>();
        rotation = FindObjectOfType<Rotation>();
        rotation.rotationEnabled = false;
        SetState(new Idle(this));
    }
    private void Update()
    {
        _state.StateUpdate();
    }
    private void Start()
    {
        playerData.LeftHandOccupied = false;
        playerData.RightHandOccupied = false;
        playerData.actualSpeed = playerData.movementSpeed;
        _state.Start();
    }
    private void OnCollisionStay(Collision collision)
    {
        _state.Collisions(collision);
    }
    public Collider[] ObjectsInPlayerRange()
    {
        Vector3 playerPos = gameObject.transform.position;
        return Physics.OverlapSphere(playerPos, playerData.grabRange);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.gameObject.transform.position, playerData.grabRange);
    }
}
