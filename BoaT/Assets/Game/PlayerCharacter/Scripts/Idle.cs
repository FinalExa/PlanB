using System;

public class Idle : PlayerState
{
    private bool dashInput;
    public enum SelectedHand
    {
        Left,
        Right,
        None
    }
    SelectedHand handContainer;
    public static Action<SelectedHand> passHand;
    public Idle(PlayerCharacter playerCharacter) : base(playerCharacter)
    {
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
        else if (_playerCharacter.playerInputs.RightHandInput) CheckRightHandAction();
    }
    private void CheckLeftHandAction()
    {
        handContainer = SelectedHand.Left;
        if (_playerCharacter.LeftHandOccupied == false) GoToGrab();
        else GoToThrow();
    }
    private void CheckRightHandAction()
    {
        handContainer = SelectedHand.Right;
        if (_playerCharacter.RightHandOccupied == false) GoToGrab();
        else GoToThrow();
    }
    private void GoToGrab()
    {
        _playerCharacter.SetState(new Grab(_playerCharacter));
        passHand(handContainer);
        handContainer = SelectedHand.None;
    }
    private void GoToThrow()
    {
        _playerCharacter.SetState(new Throw(_playerCharacter));
        passHand(handContainer);
        handContainer = SelectedHand.None;
    }
    #endregion
}
