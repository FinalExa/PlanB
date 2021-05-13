using UnityEngine;
public class PlayerCharacter : StateMachine
{
    public bool LeftHand { get; set; }
    public bool RightHand { get; set; }
    [HideInInspector] public PlayerInputs playerInputs;

    private void Awake()
    {
        playerInputs = this.gameObject.GetComponent<PlayerInputs>();
    }
    private void Start()
    {
        SetState(new Idle(this));
    }
}
