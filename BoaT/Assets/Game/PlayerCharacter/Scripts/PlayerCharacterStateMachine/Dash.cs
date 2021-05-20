﻿using UnityEngine;

public class Dash : PlayerState
{
    private bool dashFinished;
    private float dashTimer;
    private Vector3 dashVector;
    public Dash(PlayerCharacter playerCharacter) : base(playerCharacter)
    {
    }

    public override void Start()
    {
        DashCooldown dashCooldown = _playerCharacter.playerController.playerReferences.dashCooldown;
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
        PlayerData playerData = _playerCharacter.playerController.playerReferences.playerData;
        dashFinished = false;
        float speed = playerData.dashDistance / playerData.dashDuration;
        Vector3 forward = _playerCharacter.transform.GetChild(0).forward;
        dashVector = new Vector3(forward.x, forward.y, forward.z) * speed;
        dashTimer = playerData.dashDuration;
    }
    private void PerformDash()
    {
        if (dashTimer > 0)
        {
            Rigidbody playerRb = _playerCharacter.playerController.playerReferences.playerRb;
            dashTimer -= Time.deltaTime;
            playerRb.velocity = dashVector;
        }
        else EndDash();
    }
    private void EndDash()
    {
        Rigidbody playerRb = _playerCharacter.playerController.playerReferences.playerRb;
        DashCooldown dashCooldown = _playerCharacter.playerController.playerReferences.dashCooldown;
        playerRb.velocity = Vector3.zero;
        dashFinished = true;
        dashCooldown.SetOnCooldown();
        Transitions();
    }
    #endregion

    #region Transitions
    private void Transitions()
    {
        PlayerInputs playerInputs = _playerCharacter.playerController.playerReferences.playerInputs;
        if (playerInputs.MovementInput == Vector3.zero) ReturnToIdle();
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
