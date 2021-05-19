using UnityEngine;

public class Dash : PlayerState
{
    private PlayerData playerData;
    private PlayerInputs playerInputs;
    private DashCooldown dashCooldown;
    private bool dashFinished;
    private float dashTimer;
    private UnityEngine.Vector3 dashVector;
    private UnityEngine.Rigidbody playerRb;
    public Dash(PlayerCharacter playerCharacter) : base(playerCharacter)
    {
        playerCharacter.rotation.rotationEnabled = false;
        playerRb = playerCharacter.playerRb;
        playerData = playerCharacter.playerData;
        playerInputs = playerCharacter.playerInputs;
        dashCooldown = playerCharacter.dashCooldown;
    }

    public override void Start()
    {
        if (!dashCooldown.dashOnCooldown) DashSetup();
        else Transitions();
    }
    public override void StateUpdate()
    {
        if (!dashFinished) PerformDash();
    }
    public override void Collisions(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ground"))
        {
            EndDash();
        }
    }

    #region Dash
    private void DashSetup()
    {
        dashFinished = false;
        float speed = playerData.dashDistance / playerData.dashDuration;
        UnityEngine.Vector3 forward = _playerCharacter.transform.GetChild(0).forward;
        dashVector = new UnityEngine.Vector3(forward.x, forward.y, forward.z) * speed;
        dashTimer = playerData.dashDuration;
    }
    private void PerformDash()
    {
        if (dashTimer > 0)
        {
            dashTimer -= UnityEngine.Time.deltaTime;
            playerRb.velocity = dashVector;
        }
        else EndDash();
    }
    private void EndDash()
    {
        playerRb.velocity = UnityEngine.Vector3.zero;
        dashFinished = true;
        dashCooldown.SetDashOnCooldown();
        Transitions();
    }
    #endregion

    #region Transitions
    private void Transitions()
    {
        if (playerInputs.MovementInput == UnityEngine.Vector3.zero) ReturnToIdle();
        else ReturnToMovement();
    }
    private void ReturnToIdle()
    {
        _playerCharacter.SetState(new Idle(_playerCharacter));
    }
    private void ReturnToMovement()
    {
        _playerCharacter.SetState(new Moving(_playerCharacter));
    }
    #endregion
}
