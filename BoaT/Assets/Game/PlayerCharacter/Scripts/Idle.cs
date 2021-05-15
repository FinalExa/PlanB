public class Idle : PlayerState
{
    private bool dashInput;
    public Idle(PlayerCharacter playerCharacter) : base(playerCharacter)
    {
        playerCharacter.rotation.rotationEnabled = true;
        playerCharacter.PrintStuff("Idle");
    }

    public override void StateUpdate()
    {
        GoToMovementState();
        GoToDashState();
        GoToHandsState();
    }

    #region ToMovementState
    void GoToMovementState()
    {
        if ((_playerCharacter.playerInputs.MovementInput.x != 0) || (_playerCharacter.playerInputs.MovementInput.z != 0)) _playerCharacter.SetState(new Moving(_playerCharacter));
    }
    #endregion

    #region ToDashState
    void GoToDashState()
    {
        GetDashInput();
        CheckTransitionToDash(dashInput);
    }
    void GetDashInput()
    {
        dashInput = _playerCharacter.playerInputs.DashInput;
    }
    void CheckTransitionToDash(bool dash)
    {
        if (dash) _playerCharacter.SetState(new Dash(_playerCharacter));
    }
    #endregion

    #region ToHandsStates
    private void GoToHandsState()
    {
        GetHandsInput();
    }
    private void GetHandsInput()
    {
        if (_playerCharacter.playerInputs.LeftHandInput) CheckLeftHandAction();
        if (_playerCharacter.playerInputs.RightHandInput) CheckRightHandAction();
    }
    private void CheckLeftHandAction()
    {
        _playerCharacter.selectedHand = PlayerCharacter.SelectedHand.Left;
        if (_playerCharacter.LeftHandOccupied == false && _playerCharacter.mouseData.CheckForThrowableObject() == true) GoToGrab();
        else if (_playerCharacter.LeftHandOccupied == true) GoToThrow();
    }
    private void CheckRightHandAction()
    {
        _playerCharacter.selectedHand = PlayerCharacter.SelectedHand.Right;
        if (_playerCharacter.RightHandOccupied == false && _playerCharacter.mouseData.CheckForThrowableObject() == true) GoToGrab();
        else if (_playerCharacter.RightHandOccupied == true) GoToThrow();
    }
    private void GoToGrab()
    {
        _playerCharacter.SetState(new Grab(_playerCharacter));
    }
    private void GoToThrow()
    {
        _playerCharacter.SetState(new Throw(_playerCharacter));
    }
    #endregion
}
