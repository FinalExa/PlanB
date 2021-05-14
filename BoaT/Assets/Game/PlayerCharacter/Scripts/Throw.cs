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
            SetLeftHandFree();

        }
        else if (_playerCharacter.selectedHand == PlayerCharacter.SelectedHand.Right)
        {
            _playerCharacter.PrintStuff("Throw with Right Hand");
            SetRightHandFree();
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
