using UnityEngine;
public class PlayerCharacter : StateMachine
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float minSpeedValue;
    public float actualSpeed;
    public bool LeftHandOccupied { get; set; }
    public bool RightHandOccupied { get; set; }
    public float leftHandWeight;
    public float rightHandWeight;
    public float throwSpeed;
    public float dashDistance;
    public float dashDuration;
    public enum SelectedHand
    {
        Left,
        Right
    }
    [HideInInspector] public SelectedHand selectedHand;
    [HideInInspector] public Rotation rotation;
    [HideInInspector] public PlayerInputs playerInputs;
    [HideInInspector] public MouseData mouseData;
    public GameObject LeftHand;
    public GameObject RightHand;
    [HideInInspector] public Camera mainCamera;

    private void Awake()
    {
        playerInputs = this.gameObject.GetComponent<PlayerInputs>();
        mouseData = this.gameObject.GetComponent<MouseData>();
        mainCamera = FindObjectOfType<Camera>();
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
        LeftHandOccupied = false;
        RightHandOccupied = false;
        actualSpeed = movementSpeed;
        _state.Start();
    }
    public void UpdateSpeedValue()
    {
        actualSpeed = movementSpeed - (leftHandWeight + rightHandWeight);
        if (actualSpeed < minSpeedValue) actualSpeed = minSpeedValue;
    }

    public void PrintStuff(string stringToPrint)
    {
        print(stringToPrint);
    }
}
