public class Dash : PlayerState
{

    public Dash(PlayerCharacter playerCharacter) : base(playerCharacter)
    {
        playerCharacter.PrintStuff("Dash");
    }

    public override void Start()
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
}
