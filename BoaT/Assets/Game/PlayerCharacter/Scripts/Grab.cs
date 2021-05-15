public class Grab : PlayerState
{

    public Grab(PlayerCharacter playerCharacter) : base(playerCharacter)
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
            SetLeftHandOccupied();

        }
        else if (_playerCharacter.selectedHand == PlayerCharacter.SelectedHand.Right)
        {
            SetRightHandOccupied();
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

    void SetLeftHandOccupied()
    {
        IThrowable iThrowable = _playerCharacter.mouseData.PassThrowableObject().GetComponent<IThrowable>();
        iThrowable.StopForce();
        iThrowable.AttachToPlayer(_playerCharacter.LeftHand);
        _playerCharacter.LeftHandOccupied = true;
        ReturnToDestination();
    }
    void SetRightHandOccupied()
    {
        IThrowable iThrowable = _playerCharacter.mouseData.PassThrowableObject().GetComponent<IThrowable>();
        iThrowable.StopForce();
        iThrowable.AttachToPlayer(_playerCharacter.RightHand);
        _playerCharacter.LeftHandOccupied = true;
        _playerCharacter.RightHandOccupied = true;
        ReturnToDestination();
    }
}
