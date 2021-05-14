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
        SetLeftHandOccupied();
    }

    void GrabRightHand()
    {
        SetRightHandOccupied();
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
        _playerCharacter.LeftHandOccupied = true;
        ReturnToDestination();
    }
    void SetRightHandOccupied()
    {
        _playerCharacter.RightHandOccupied = true;
        ReturnToDestination();
    }
}
