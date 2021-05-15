public class Grab : PlayerState
{

    public Grab(PlayerCharacter playerCharacter) : base(playerCharacter)
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
            GrabLeftHand();

        }
        else if (_playerCharacter.selectedHand == PlayerCharacter.SelectedHand.Right)
        {
            GrabRightHand();
        }
    }

    void GrabLeftHand()
    {
        if (_playerCharacter.mouseData.CheckForThrowableObject() == true)
        {
            SetLeftHandOccupied();
        }
        else ReturnToDestination();
    }

    void GrabRightHand()
    {
        if (_playerCharacter.mouseData.CheckForThrowableObject() == true)
        {
            SetRightHandOccupied();
        }
        else ReturnToDestination();
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

    void SetLeftHandOccupied()
    {
        IThrowable iThrowable = _playerCharacter.mouseData.PassThrowableObject().GetComponent<IThrowable>();
        iThrowable.AttachToPlayer(_playerCharacter.LeftHand);
        _playerCharacter.LeftHandOccupied = true;
        ReturnToDestination();
    }
    void SetRightHandOccupied()
    {
        IThrowable iThrowable = _playerCharacter.mouseData.PassThrowableObject().GetComponent<IThrowable>();
        iThrowable.AttachToPlayer(_playerCharacter.RightHand);
        _playerCharacter.LeftHandOccupied = true;
        _playerCharacter.RightHandOccupied = true;
        ReturnToDestination();
    }
}
