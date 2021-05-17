public class Hands : PlayerState
{
    private PlayerData playerData;
    private MouseData mouseData;
    private PlayerInputs playerInputs;
    public Hands(PlayerCharacter playerCharacter) : base(playerCharacter)
    {
        playerData = playerCharacter.playerData;
        mouseData = playerCharacter.mouseData;
        playerInputs = playerCharacter.playerInputs;
    }

    public override void Start()
    {
        CheckHandToUse();
    }

    private void CheckHandToUse()
    {
        if (playerData.selectedHand == PlayerData.SelectedHand.Left) CheckLeftHandAction();
        else if (playerData.selectedHand == PlayerData.SelectedHand.Right) CheckRightHandAction();
    }

    private void CheckLeftHandAction()
    {
        playerData.selectedHand = PlayerData.SelectedHand.Left;
        if (!playerData.LeftHandOccupied)
        {
            CheckIfThrowableIsSelected();
        }
        else GoToThrow();
    }
    private void CheckRightHandAction()
    {
        playerData.selectedHand = PlayerData.SelectedHand.Right;
        if (!playerData.RightHandOccupied)
        {
            CheckIfThrowableIsSelected();
        }
        else GoToThrow();
    }

    private void CheckIfThrowableIsSelected()
    {
        if (mouseData.CheckForThrowableObject() == true) CheckIfObjectIsInPlayerRange();
        else CheckForIdleOrMovement();
    }

    private void CheckIfObjectIsInPlayerRange()
    {
        bool noObjectInRange = true;
        UnityEngine.Vector3 playerPos = _playerCharacter.gameObject.transform.position;
        UnityEngine.Collider[] colliders = UnityEngine.Physics.OverlapSphere(playerPos, playerData.grabRange);
        foreach (var collider in colliders)
        {
            if (collider == mouseData.GetClickPosition().collider)
            {
                noObjectInRange = false;
                GoToGrab();
                break;
            }
        }
        if (noObjectInRange) CheckForIdleOrMovement();
    }
    void CheckForIdleOrMovement()
    {
        if (playerInputs.MovementInput == UnityEngine.Vector3.zero) GoToIdle();
        else GoToMoving();
    }
    private void GoToGrab()
    {
        _playerCharacter.SetState(new Grab(_playerCharacter));
    }
    private void GoToThrow()
    {
        _playerCharacter.SetState(new Throw(_playerCharacter));
    }
    private void GoToIdle()
    {
        _playerCharacter.SetState(new Idle(_playerCharacter));
    }
    private void GoToMoving()
    {
        _playerCharacter.SetState(new Moving(_playerCharacter));
    }
}
