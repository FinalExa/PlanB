using UnityEngine;

public class PlayerReferences : MonoBehaviour
{
    public PlayerData playerData;
    [HideInInspector] public Rotation rotation;
    [HideInInspector] public PlayerInputs playerInputs;
    [HideInInspector] public ObjectsOnMouse objectsOnMouse;
    [HideInInspector] public Rigidbody playerRb;
    [HideInInspector] public DashCooldown dashCooldown;
    [HideInInspector] public Camera mainCamera;


    private void Awake()
    {
        rotation = FindObjectOfType<Rotation>();
        playerInputs = this.gameObject.GetComponent<PlayerInputs>();
        objectsOnMouse = FindObjectOfType<ObjectsOnMouse>();
        playerRb = this.gameObject.GetComponent<Rigidbody>();
        dashCooldown = this.gameObject.GetComponent<DashCooldown>();
        mainCamera = GameObject.FindObjectOfType<Camera>();
    }
}
