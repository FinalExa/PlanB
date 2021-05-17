public class Grab : PlayerState
{
    private Rotation rotation;
    private PlayerData playerData;
    private PlayerInputs playerInputs;
    private MouseData mouseData;
    public Grab(PlayerCharacter playerCharacter) : base(playerCharacter)
    {
        rotation = playerCharacter.rotation;
        playerData = playerCharacter.playerData;
        playerInputs = playerCharacter.playerInputs;
        mouseData = playerCharacter.mouseData;
        playerCharacter.rotation.rotationEnabled = false;
    }

    public override void Start()
    {
        CheckHand();
    }
    void CheckHand()
    {
        if (playerData.selectedHand == PlayerData.SelectedHand.Left) SetHandOccupied(playerData.selectedHand);
        else if (playerData.selectedHand == PlayerData.SelectedHand.Right) SetHandOccupied(playerData.selectedHand);
    }

    void ReturnToDestination()
    {
        if (playerInputs.MovementInput == UnityEngine.Vector3.zero) ReturnToIdle();
        else ReturnToMovement();
    }
    void ReturnToIdle()
    {
        _playerCharacter.SetState(new Idle(_playerCharacter));
    }
    void ReturnToMovement()
    {
        _playerCharacter.SetState(new Moving(_playerCharacter));
    }

    void SetHandOccupied(PlayerData.SelectedHand selectedHand)
    {
        IThrowable iThrowable = mouseData.PassThrowableObject().GetComponent<IThrowable>();
        iThrowable.StopForce();
        if (selectedHand == PlayerData.SelectedHand.Left) LeftHand(iThrowable);
        else RightHand(iThrowable);
        ReturnToDestination();
    }
    void LeftHand(IThrowable iThrowable)
    {
        iThrowable.AttachToPlayer(_playerCharacter.LeftHand);
        playerData.LeftHandOccupied = true;
        playerData.leftHandWeight = iThrowable.Weight;
    }
    void RightHand(IThrowable iThrowable)
    {
        iThrowable.AttachToPlayer(_playerCharacter.RightHand);
        playerData.RightHandOccupied = true;
        playerData.rightHandWeight = iThrowable.Weight;
    }
}
