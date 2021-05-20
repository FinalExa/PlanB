﻿using UnityEngine;
public class Moving : PlayerState
{
    private PlayerData playerData;
    private PlayerInputs playerInputs;
    private Rigidbody playerRb;
    private Camera mainCamera;
    public Moving(PlayerCharacter playerCharacter) : base(playerCharacter)
    {
        playerData = playerCharacter.playerData;
        playerInputs = playerCharacter.playerInputs;
        playerRb = _playerCharacter.playerRb;
        mainCamera = GameObject.FindObjectOfType<Camera>();
        playerCharacter.rotation.rotationEnabled = true;
    }
    public override void Start()
    {
        UpdateSpeedValue();
    }
    public override void StateUpdate()
    {
        Movement();
        Transitions();
    }

    #region Movement
    private void UpdateSpeedValue()
    {
        playerData.actualSpeed = playerData.movementSpeed - (playerData.leftHandWeight + playerData.rightHandWeight);
        if (playerData.actualSpeed < playerData.minSpeedValue) playerData.actualSpeed = playerData.minSpeedValue;
    }
    private void Movement()
    {
        Vector3 movementWithDirection = MovementInitialization();
        playerRb.velocity = new Vector3(movementWithDirection.x, movementWithDirection.y, movementWithDirection.z) * playerData.actualSpeed;
    }

    private Vector3 MovementInitialization()
    {
        Vector3 forward = mainCamera.transform.forward;
        forward.y = 0f;
        Vector3 right = mainCamera.transform.right;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();
        return (playerInputs.MovementInput.x * forward) + (playerInputs.MovementInput.z * right);
    }
    #endregion

    #region Transitions
    private void Transitions()
    {
        GoToIdleState();
        GoToDashState();
        GoToHandsState();
    }
    #region ToIdleState
    private void GoToIdleState()
    {
        if (playerInputs.MovementInput == Vector3.zero) _playerCharacter.SetState(new Idle(_playerCharacter));
    }
    #endregion
    #region ToDashState
    private void GoToDashState()
    {
        if (playerInputs.DashInput && !_playerCharacter.playerData.LeftHandOccupied && !_playerCharacter.playerData.RightHandOccupied) _playerCharacter.SetState(new Dash(_playerCharacter));
    }
    #endregion
    #region ToHandsStates
    private void GoToHandsState()
    {
        if (playerInputs.LeftHandInput || playerInputs.RightHandInput)
        {
            if (playerInputs.LeftHandInput) playerData.selectedHand = PlayerData.SelectedHand.Left;
            else playerData.selectedHand = PlayerData.SelectedHand.Right;
            _playerCharacter.SetState(new Hands(_playerCharacter));
        }
    }
    #endregion
    #endregion
}
