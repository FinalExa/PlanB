using UnityEngine;
public class PlayerCharacter : StateMachine
{
    [HideInInspector] public PlayerController playerController;

    private void Awake()
    {
        playerController = this.gameObject.GetComponent<PlayerController>();
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
