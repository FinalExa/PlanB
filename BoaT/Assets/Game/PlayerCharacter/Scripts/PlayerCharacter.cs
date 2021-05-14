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
    public SelectedHand selectedHand;
    [HideInInspector] public PlayerInputs playerInputs;
    [HideInInspector] public GameObject playerCharacter;

    private void Awake()
    {
        SetState(new Idle(this));
        playerInputs = this.gameObject.GetComponent<PlayerInputs>();
        playerCharacter = this.gameObject;
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
