public class Moving : PlayerState
{
    bool dashInput;
    public Moving(PlayerCharacter playerCharacter) : base(playerCharacter)
    {
        playerCharacter.PrintStuff("Moving");
    }
    public override void StateUpdate()
    {
        GoToIdleState();
        GoToDashState();
        GoToHandsState();
    }

    #region ToIdleState
    void GoToIdleState()
    {
        if ((_playerCharacter.playerInputs.MovementInput.x == 0) && (_playerCharacter.playerInputs.MovementInput.z == 0)) _playerCharacter.SetState(new Idle(_playerCharacter));
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
        if (_playerCharacter.LeftHandOccupied == false) GoToGrab();
        else GoToThrow();
    }
    private void CheckRightHandAction()
    {
        _playerCharacter.selectedHand = PlayerCharacter.SelectedHand.Right;
        if (_playerCharacter.RightHandOccupied == false) GoToGrab();
        else GoToThrow();
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
