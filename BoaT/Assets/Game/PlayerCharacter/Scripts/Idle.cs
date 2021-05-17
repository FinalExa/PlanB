public class Idle : PlayerState
{
    private PlayerData playerData;
    private PlayerInputs playerInputs;
    public Idle(PlayerCharacter playerCharacter) : base(playerCharacter)
    {
        playerData = playerCharacter.playerData;
        playerInputs = playerCharacter.playerInputs;
        playerCharacter.rotation.rotationEnabled = true;
    }

    public override void StateUpdate()
    {
        Transitions();
    }

    #region Transitions
    private void Transitions()
    {
        GoToMovementState();
        GoToDashState();
        GoToHandsState();
    }
    #region ToMovementState
    private void GoToMovementState()
    {
        if ((playerInputs.MovementInput != UnityEngine.Vector3.zero)) _playerCharacter.SetState(new Moving(_playerCharacter));
    }
    #endregion
    #region ToDashState
    private void GoToDashState()
    {
        if (playerInputs.DashInput && !playerData.LeftHandOccupied && !playerData.RightHandOccupied) _playerCharacter.SetState(new Dash(_playerCharacter));
    }
    #endregion
    #region ToHandsStates
    private void GoToHandsState()
    {
        if (playerInputs.LeftHandInput || playerInputs.RightHandInput)
        {
            if (playerInputs.LeftHandInput) playerData.selectedHand = PlayerData.SelectedHand.Left;
            else playerData.selectedHand = PlayerData.SelectedHand.Right;
            _playerCharacter.SetState(new Hands(_playerCharacter));
        }
    }
    #endregion
    #endregion
}
