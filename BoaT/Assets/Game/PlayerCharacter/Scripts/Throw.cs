public class Throw : PlayerState
{
    public Throw(PlayerCharacter playerCharacter) : base(playerCharacter)
    {
        playerCharacter.rotation.rotationEnabled = false;
    }
    public override void Start()
    {
        CheckHand();
    }
    void CheckHand()
    {
        if (_playerCharacter.selectedHand == PlayerCharacter.SelectedHand.Left)
        {
            ThrowLeftHand();
        }
        else if (_playerCharacter.selectedHand == PlayerCharacter.SelectedHand.Right)
        {
            ThrowRightHand();
        }
    }

    void ThrowLeftHand()
    {
        if (_playerCharacter.LeftHand.transform.childCount > 0)
        {
            IThrowable iThrowable = _playerCharacter.LeftHand.transform.GetChild(0).gameObject.GetComponent<IThrowable>();
            _playerCharacter.rotation.RotateObjectToLaunch(iThrowable.Self.transform, _playerCharacter.mouseData.GetClickPosition().point);
            iThrowable.DetachFromPlayer();
            iThrowable.LaunchSelf(_playerCharacter.throwSpeed);
            SetLeftHandFree();
        }
        else
        {
            SetLeftHandFree();
            ReturnToDestination();
        }
    }
    void ThrowRightHand()
    {
        if (_playerCharacter.RightHand.transform.childCount > 0)
        {
            IThrowable iThrowable = _playerCharacter.RightHand.transform.GetChild(0).gameObject.GetComponent<IThrowable>();
            _playerCharacter.rotation.RotateObjectToLaunch(iThrowable.Self.transform, _playerCharacter.mouseData.GetClickPosition().point);
            iThrowable.DetachFromPlayer();
            iThrowable.LaunchSelf(_playerCharacter.throwSpeed);
            SetRightHandFree();
        }
        else
        {
            SetRightHandFree();
            ReturnToDestination();
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

    void SetLeftHandFree()
    {
        _playerCharacter.LeftHandOccupied = false;
        _playerCharacter.leftHandWeight = 0;
        _playerCharacter.UpdateSpeedValue();
        ReturnToDestination();
    }
    void SetRightHandFree()
    {
        _playerCharacter.RightHandOccupied = false;
        _playerCharacter.rightHandWeight = 0;
        _playerCharacter.UpdateSpeedValue();
        ReturnToDestination();
    }
}
