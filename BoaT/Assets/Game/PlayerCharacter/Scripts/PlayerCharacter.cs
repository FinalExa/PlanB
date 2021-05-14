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
    [HideInInspector] public PlayerInputs playerInputs;
    [HideInInspector] public GameObject playerCharacterGameObject;
    [HideInInspector] public Rigidbody playerCharacterRigidbody;
    public float movementSpeed;

    private void Awake()
    {
        SetState(new Idle(this));
        playerInputs = this.gameObject.GetComponent<PlayerInputs>();
        playerCharacterGameObject = this.gameObject;
        playerCharacterRigidbody = playerCharacterGameObject.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        _state.StateUpdate();
    }
    private void Start()
    {
        _state.Start();
        LeftHandOccupied = false;
        RightHandOccupied = false;
    }

    public void PrintStuff(string stringToPrint)
    {
        print(stringToPrint);
    }
}
