using UnityEngine;
public class PlayerCharacter : StateMachine
{
    public bool LeftHandOccupied { get; set; }
    public bool RightHandOccupied { get; set; }
    public enum SelectedHand
    {
        Left,
        Right
    }
    [HideInInspector] public SelectedHand selectedHand;
    [HideInInspector] public Rotation rotation;
    [HideInInspector] public PlayerInputs playerInputs;
    [HideInInspector] public GameObject playerCharacterGameObject;
    [HideInInspector] public Camera mainCamera;
    public float movementSpeed;

    private void Awake()
    {
        playerInputs = this.gameObject.GetComponent<PlayerInputs>();
        playerCharacterGameObject = this.gameObject;
        mainCamera = FindObjectOfType<Camera>();
        rotation = FindObjectOfType<Rotation>();
        rotation.enabled = false;
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
        _state.Start();
    }

    public void PrintStuff(string stringToPrint)
    {
        print(stringToPrint);
    }
}
