﻿using UnityEngine;
public class Hands : PlayerState
{
    public Hands(PlayerCharacter playerCharacter) : base(playerCharacter)
    {
    }

    public override void Start()
    {
        _playerCharacter.playerController.objectClicked = _playerCharacter.playerController.playerReferences.objectsOnMouse.GetClickPosition().collider;
        CheckHandToUse();
    }

    private void CheckHandToUse()
    {
        if (_playerCharacter.playerController.selectedHand == PlayerController.SelectedHand.Left) CheckHandAction(_playerCharacter.playerController.selectedHand);
        else if (_playerCharacter.playerController.selectedHand == PlayerController.SelectedHand.Right) CheckHandAction(_playerCharacter.playerController.selectedHand);
    }

    private void CheckHandAction(PlayerController.SelectedHand selectedHand)
    {
        if (selectedHand == PlayerController.SelectedHand.Left)
        {
            if (!_playerCharacter.playerController.LeftHandOccupied) CheckIfThrowableIsSelected();
            else GoToThrow();
        }
        else
        {
            if (!_playerCharacter.playerController.RightHandOccupied) CheckIfThrowableIsSelected();
            else GoToThrow();
        }
    }
    private void CheckIfThrowableIsSelected()
    {
        ObjectsOnMouse objectsOnMouse = _playerCharacter.playerController.playerReferences.objectsOnMouse;
        if (objectsOnMouse.CheckForThrowableObject(_playerCharacter.playerController.objectClicked) == true) CheckIfObjectIsInPlayerRange();
        else Transitions();
    }
    private void CheckIfObjectIsInPlayerRange()
    {
        bool noObjectInRange = true;
        foreach (var collider in _playerCharacter.playerController.objectsInPlayerRange)
        {
            if (collider == _playerCharacter.playerController.objectClicked)
            {
                noObjectInRange = false;
                GoToGrab();
                break;
            }
        }
        if (noObjectInRange) Transitions();
    }

    #region Transitions
    private void Transitions()
    {
        PlayerInputs playerInputs = _playerCharacter.playerController.playerReferences.playerInputs;
        if (playerInputs.MovementInput == Vector3.zero) GoToIdle();
        else GoToMoving();
    }
    private void GoToGrab()
    {
        _playerCharacter.SetState(new Grab(_playerCharacter));
    }
    private void GoToThrow()
    {
        _playerCharacter.SetState(new Throw(_playerCharacter));
    }
    private void GoToIdle()
    {
        _playerCharacter.SetState(new Idle(_playerCharacter));
    }
    private void GoToMoving()
    {
        _playerCharacter.SetState(new Moving(_playerCharacter));
    }
    #endregion
}
