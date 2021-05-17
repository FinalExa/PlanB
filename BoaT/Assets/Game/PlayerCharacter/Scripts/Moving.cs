public class Moving : PlayerState
{
    bool dashInput;
    public Moving(PlayerCharacter playerCharacter) : base(playerCharacter)
    {
        playerCharacter.rotation.rotationEnabled = true;
    }
    public override void StateUpdate()
    {
        Movement();
        StateChangesCheck();
    }

    private void Movement()
    {
        var forward = _playerCharacter.mainCamera.transform.forward;
        forward.y = 0f;
        var right = _playerCharacter.mainCamera.transform.right;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();
        var movementWithDirection = (_playerCharacter.playerInputs.MovementInput.x * forward) + (_playerCharacter.playerInputs.MovementInput.z * right);
        _playerCharacter.playerRB.velocity = new UnityEngine.Vector3(movementWithDirection.x, movementWithDirection.y, movementWithDirection.z) * _playerCharacter.playerData.actualSpeed;
    }

    private void StateChangesCheck()
    {
        GoToIdleState();
        GoToDashState();
        GoToHandsState();
    }

    #region ToIdleState
    private void GoToIdleState()
    {
        if ((_playerCharacter.playerInputs.MovementInput.x == 0) && (_playerCharacter.playerInputs.MovementInput.z == 0)) _playerCharacter.SetState(new Idle(_playerCharacter));
    }
    #endregion

    #region ToDashState
    private void GoToDashState()
    {
        GetDashInput();
        CheckTransitionToDash(dashInput);
    }
    private void GetDashInput()
    {
        dashInput = _playerCharacter.playerInputs.DashInput;
    }
    private void CheckTransitionToDash(bool dash)
    {
        if (dash && !_playerCharacter.playerData.LeftHandOccupied && !_playerCharacter.playerData.RightHandOccupied) _playerCharacter.SetState(new Dash(_playerCharacter));
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
        if (_playerCharacter.playerData.LeftHandOccupied == false && _playerCharacter.mouseData.CheckForThrowableObject() == true) GoToGrab();
        else if (_playerCharacter.playerData.LeftHandOccupied == true) GoToThrow();
    }
    private void CheckRightHandAction()
    {
        _playerCharacter.selectedHand = PlayerCharacter.SelectedHand.Right;
        if (_playerCharacter.playerData.RightHandOccupied == false && _playerCharacter.mouseData.CheckForThrowableObject() == true) GoToGrab();
        else if (_playerCharacter.playerData.RightHandOccupied == true) GoToThrow();
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
