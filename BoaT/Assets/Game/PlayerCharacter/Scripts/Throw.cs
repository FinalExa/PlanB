public class Throw : PlayerState
{
    public Throw(PlayerCharacter playerCharacter) : base(playerCharacter)
    {
        playerCharacter.rotation.enabled = false;
    }
    public override void Start()
    {
        CheckHand();
    }
    void CheckHand()
    {
        if (_playerCharacter.selectedHand == PlayerCharacter.SelectedHand.Left)
        {
            _playerCharacter.PrintStuff("Throw with Left Hand");
            ThrowLeftHand();
        }
        else if (_playerCharacter.selectedHand == PlayerCharacter.SelectedHand.Right)
        {
            _playerCharacter.PrintStuff("Throw with Right Hand");
            ThrowRightHand();
        }
    }

    void ThrowLeftHand()
    {
        if (_playerCharacter.LeftHand.transform.childCount > 0)
        {
            IThrowable iThrowable = _playerCharacter.LeftHand.transform.GetChild(0).gameObject.GetComponent<IThrowable>();
            iThrowable.DetachFromPlayer();
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
            iThrowable.DetachFromPlayer();
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
        ReturnToDestination();
    }
    void SetRightHandFree()
    {
        _playerCharacter.RightHandOccupied = false;
        ReturnToDestination();
    }
}
