using System.Collections.Generic;
using UnityEngine;
public class PlayerCharacter : StateMachine
{
    public PlayerData playerData;
    [HideInInspector] public Rotation rotation;
    [HideInInspector] public PlayerInputs playerInputs;
    [HideInInspector] public MouseData mouseData;
    [HideInInspector] public ObjectsOnMouse objectsOnMouse;
    [HideInInspector] public Rigidbody playerRb;
    [HideInInspector] public DashCooldown dashCooldown;
    public List<Collider> objectsInPlayerRange;
    public GameObject LeftHand;
    public GameObject RightHand;

    private void Awake()
    {
        playerInputs = this.gameObject.GetComponent<PlayerInputs>();
        playerRb = this.gameObject.GetComponent<Rigidbody>();
        dashCooldown = this.gameObject.GetComponent<DashCooldown>();
        mouseData = FindObjectOfType<MouseData>();
        objectsOnMouse = FindObjectOfType<ObjectsOnMouse>();
        rotation = FindObjectOfType<Rotation>();
        SetState(new Idle(this));
    }
    private void Start()
    {
        _state.Start();
    }
    private void Update()
    {
        _state.StateUpdate();
    }
    private void OnCollisionStay(Collision collision)
    {
        _state.Collisions(collision);
    }
}
