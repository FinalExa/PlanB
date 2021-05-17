using UnityEngine;
public class PlayerCharacter : StateMachine
{
    [HideInInspector] public PlayerData playerData;
    [HideInInspector] public Rotation rotation;
    [HideInInspector] public PlayerInputs playerInputs;
    [HideInInspector] public MouseData mouseData;
    public GameObject LeftHand;
    public GameObject RightHand;

    private void Awake()
    {
        playerInputs = this.gameObject.GetComponent<PlayerInputs>();
        mouseData = this.gameObject.GetComponent<MouseData>();
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


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.gameObject.transform.position, playerData.grabRange);
    }
}
