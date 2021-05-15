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
            _playerCharacter.PrintStuff("Grab with Left Hand");
            GrabLeftHand();

        }
        else if (_playerCharacter.selectedHand == PlayerCharacter.SelectedHand.Right)
        {
            _playerCharacter.PrintStuff("Grab with Right Hand");
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
        var iThrowable = _playerCharacter.mouseData.PassThrowableObject().GetComponent<iThrowable>();
        iThrowable.AttachToPlayer(_playerCharacter.LeftHand);
        _playerCharacter.LeftHandOccupied = true;
        ReturnToDestination();
    }
    void SetRightHandOccupied()
    {
        var iThrowable = _playerCharacter.mouseData.PassThrowableObject().GetComponent<iThrowable>();
        iThrowable.AttachToPlayer(_playerCharacter.RightHand);
        _playerCharacter.LeftHandOccupied = true;
        _playerCharacter.RightHandOccupied = true;
        ReturnToDestination();
    }
}
