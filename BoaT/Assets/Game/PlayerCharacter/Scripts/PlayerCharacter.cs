using UnityEngine;
public class PlayerCharacter : StateMachine
{
    public bool LeftHandOccupied { get; set; }
    public bool RightHandOccupied { get; set; }
    [HideInInspector] public PlayerInputs playerInputs;

    private void Awake()
    {
        SetState(new Idle(this));
        playerInputs = this.gameObject.GetComponent<PlayerInputs>();
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
}
