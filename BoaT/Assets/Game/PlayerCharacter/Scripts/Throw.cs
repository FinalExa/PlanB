public class Throw : PlayerState
{
    public Throw(PlayerCharacter playerCharacter) : base(playerCharacter)
    {
        Idle.passHand += CheckHand;
        playerCharacter.PrintStuff("Throw");
    }
    public override void Start()
    {
        ReturnToDestination();
    }
    void CheckHand(Idle.SelectedHand hand)
    {
        bool doOnce = false;
        if (doOnce == false)
        {
            if (hand == Idle.SelectedHand.Left)
            {
                _playerCharacter.PrintStuff("Left");
                hand = Idle.SelectedHand.None;
                SetLeftHandFree();
                ReturnToDestination();
            }
            else if (hand == Idle.SelectedHand.Right)
            {
                _playerCharacter.PrintStuff("Right");
                hand = Idle.SelectedHand.None;
                SetRightHandFree();
                ReturnToDestination();
            }
            doOnce = true;
        }
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
    void SetLeftHandFree()
    {
        _playerCharacter.LeftHandOccupied = false;
    }
    void SetRightHandFree()
    {
        _playerCharacter.RightHandOccupied = false;
    }
}
