public class Idle : PlayerState
{
    float frontInput;
    float sideInput;
    public Idle(PlayerCharacter playerCharacter) : base(playerCharacter)
    {
    }

    public override void StateUpdate()
    {
        GetMovementInput();
        MovementSwitch(frontInput, sideInput);
    }

    void GetMovementInput()
    {
        frontInput = _playerCharacter.playerInputs.FrontInput;
        sideInput = _playerCharacter.playerInputs.SideInput;
    }

    void MovementSwitch(float front, float side)
    {
        if ((front != 0) || (side != 0)) _playerCharacter.SetState(new Moving(_playerCharacter));
    }
}
