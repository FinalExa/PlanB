﻿using UnityEngine;
public class Throw : PlayerState
{
    public Throw(PlayerCharacter playerCharacter) : base(playerCharacter)
    {
        playerCharacter.playerController.playerReferences.rotation.rotationEnabled = false;
    }
    public override void Start()
    {
        CheckHand();
    }

    #region Throw
    private void CheckHand()
    {
        if (_playerCharacter.playerController.selectedHand == PlayerController.SelectedHand.Left) ThrowLeftHand();
        else ThrowRightHand();
    }
    private void ThrowLeftHand()
    {
        if (_playerCharacter.playerController.LeftHand.transform.childCount > 0)
        {
            IThrowable iThrowable = _playerCharacter.playerController.LeftHand.transform.GetChild(0).gameObject.GetComponent<IThrowable>();
            LaunchObject(iThrowable);
        }
        SetHandFree();
    }
    private void ThrowRightHand()
    {
        if (_playerCharacter.playerController.RightHand.transform.childCount > 0)
        {
            IThrowable iThrowable = _playerCharacter.playerController.RightHand.transform.GetChild(0).gameObject.GetComponent<IThrowable>();
            LaunchObject(iThrowable);
        }
        SetHandFree();
    }
    private void LaunchObject(IThrowable iThrowable)
    {
        _playerCharacter.playerController.playerReferences.rotation.RotateObjectToLaunch(iThrowable.Self.transform, _playerCharacter.playerController.playerReferences.objectsOnMouse.GetClickPosition().point);
        iThrowable.DetachFromPlayer(_playerCharacter.playerController.playerReferences.playerData.throwDistance, _playerCharacter.playerController.playerReferences.playerData.throwFlightTime);
    }
    private void SetHandFree()
    {
        if (_playerCharacter.playerController.selectedHand == PlayerController.SelectedHand.Left)
        {
            _playerCharacter.playerController.LeftHandOccupied = false;
            _playerCharacter.playerController.leftHandWeight = 0;
        }
        else
        {
            _playerCharacter.playerController.RightHandOccupied = false;
            _playerCharacter.playerController.rightHandWeight = 0;
        }
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
