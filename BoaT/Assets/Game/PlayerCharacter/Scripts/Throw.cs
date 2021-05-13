public class Throw : PlayerState
{
    public Throw(PlayerCharacter playerCharacter) : base(playerCharacter)
    {
        playerCharacter.PrintStuff("Throw");
    }
    public override void Start()
    {
        SetHandsFree();
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
    void SetHandsFree()
    {
        _playerCharacter.LeftHandOccupied = false;
        _playerCharacter.RightHandOccupied = false;
    }
}
