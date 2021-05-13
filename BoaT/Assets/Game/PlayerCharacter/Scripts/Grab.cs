public class Grab : PlayerState
{
    public Grab(PlayerCharacter playerCharacter) : base(playerCharacter)
    {
        playerCharacter.PrintStuff("Grab");
    }
    public override void Start()
    {
        SetHandsOccupied();
        ReturnToDestination();
    }

    void ReturnToDestination()
    {
        ReturnToIdle();
        ReturnToMovement();
    }

    void ReturnToIdle()
    {
        if ((_playerCharacter.playerInputs.MovementInput.x == 0) && (_playerCharacter.playerInputs.MovementInput.z == 0)) _playerCharacter.SetState(new Idle(_playerCharacter));
    }
    void ReturnToMovement()
    {
        if ((_playerCharacter.playerInputs.MovementInput.x != 0) || (_playerCharacter.playerInputs.MovementInput.z != 0)) _playerCharacter.SetState(new Moving(_playerCharacter));
    }
    void SetHandsOccupied()
    {
        _playerCharacter.LeftHandOccupied = true;
        _playerCharacter.RightHandOccupied = true;
    }
}
