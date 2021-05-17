public class Grab : PlayerState
{
    private PlayerData playerData;
    private PlayerInputs playerInputs;
    private MouseData mouseData;
    public Grab(PlayerCharacter playerCharacter) : base(playerCharacter)
    {
        playerData = playerCharacter.playerData;
        playerInputs = playerCharacter.playerInputs;
        mouseData = playerCharacter.mouseData;
        playerCharacter.rotation.rotationEnabled = false;
    }

    public override void Start()
    {
        CheckHand();
    }

    #region Grab
    private void CheckHand()
    {
        PlayerData.SelectedHand selectedHand = playerData.selectedHand;
        if (selectedHand == PlayerData.SelectedHand.Left) SetHandOccupied(selectedHand);
        else if (selectedHand == PlayerData.SelectedHand.Right) SetHandOccupied(selectedHand);
    }
    private void SetHandOccupied(PlayerData.SelectedHand selectedHand)
    {
        IThrowable iThrowable = mouseData.PassThrowableObject().GetComponent<IThrowable>();
        iThrowable.StopForce();
        if (selectedHand == PlayerData.SelectedHand.Left) LeftHand(iThrowable);
        else RightHand(iThrowable);
        Transitions();
    }
    private void LeftHand(IThrowable iThrowable)
    {
        iThrowable.AttachToPlayer(_playerCharacter.LeftHand);
        playerData.LeftHandOccupied = true;
        playerData.leftHandWeight = iThrowable.Weight;
    }
    private void RightHand(IThrowable iThrowable)
    {
        iThrowable.AttachToPlayer(_playerCharacter.RightHand);
        playerData.RightHandOccupied = true;
        playerData.rightHandWeight = iThrowable.Weight;
    }
    #endregion

    #region Transitions
    private void Transitions()
    {
        if (playerInputs.MovementInput == UnityEngine.Vector3.zero) ReturnToIdle();
        else ReturnToMovement();
    }
    private void ReturnToIdle()
    {
        _playerCharacter.SetState(new Idle(_playerCharacter));
    }
    private void ReturnToMovement()
    {
        _playerCharacter.SetState(new Moving(_playerCharacter));
    }
    #endregion
}
