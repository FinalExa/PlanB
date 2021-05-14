public class Grab : PlayerState
{

    public Grab(PlayerCharacter playerCharacter) : base(playerCharacter)
    {
        Idle.passHand += CheckHand;
        playerCharacter.PrintStuff("Grab");
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
                SetLeftHandOccupied();
                ReturnToDestination();
            }
            else if (hand == Idle.SelectedHand.Right)
            {
                _playerCharacter.PrintStuff("Right");
                hand = Idle.SelectedHand.None;
                SetRightHandOccupied();
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

    void SetLeftHandOccupied()
    {
        _playerCharacter.LeftHandOccupied = true;
    }
    void SetRightHandOccupied()
    {
        _playerCharacter.RightHandOccupied = true;
    }
}
