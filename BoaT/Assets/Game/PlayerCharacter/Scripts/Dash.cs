using UnityEngine;

public class Dash : PlayerState
{
    private bool dashFinished;
    private float speed;
    private UnityEngine.Vector3 forward;
    private float dashTimer;
    public Dash(PlayerCharacter playerCharacter) : base(playerCharacter)
    {
        playerCharacter.rotation.rotationEnabled = false;
    }

    public override void Start()
    {
        dashFinished = false;
        speed = _playerCharacter.dashDistance / _playerCharacter.dashDuration;
        forward = _playerCharacter.transform.GetChild(0).forward;
        dashTimer = _playerCharacter.dashDuration;
    }

    public override void StateUpdate()
    {
        if (!dashFinished) PerformDash();
        else ReturnToDestination();
    }

    public override void Collisions(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ground"))
        {
            dashFinished = true;
            _playerCharacter.PrintStuff("ciao");
        }
    }

    void PerformDash()
    {
        if (dashTimer > 0)
        {
            dashTimer -= UnityEngine.Time.deltaTime;
            _playerCharacter.gameObject.transform.Translate(forward * speed * UnityEngine.Time.deltaTime);
        }
        else
        {
            dashFinished = true;
        }
    }

    void ReturnToDestination()
    {
        if ((_playerCharacter.playerInputs.MovementInput.x == 0) && (_playerCharacter.playerInputs.MovementInput.z == 0)) ReturnToIdle();
        else if ((_playerCharacter.playerInputs.MovementInput.x != 0) || (_playerCharacter.playerInputs.MovementInput.z != 0)) ReturnToMovement();
    }

    void ReturnToIdle()
    {
        _playerCharacter.SetState(new Idle(_playerCharacter));
    }
    void ReturnToMovement()
    {
        _playerCharacter.SetState(new Moving(_playerCharacter));
    }
}
