using UnityEngine;
public class Throw : PlayerState
{
    private PlayerData playerData;
    private PlayerInputs playerInputs;
    private MouseData mouseData;
    public Throw(PlayerCharacter playerCharacter) : base(playerCharacter)
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

    #region Throw
    private void CheckHand()
    {
        if (playerData.selectedHand == PlayerData.SelectedHand.Left) ThrowLeftHand();
        else if (playerData.selectedHand == PlayerData.SelectedHand.Right) ThrowRightHand();
    }
    private void ThrowLeftHand()
    {
        if (_playerCharacter.LeftHand.transform.childCount > 0)
        {
            IThrowable iThrowable = _playerCharacter.LeftHand.transform.GetChild(0).gameObject.GetComponent<IThrowable>();
            LaunchObject(iThrowable);
        }
        SetHandFree();
    }
    private void ThrowRightHand()
    {
        if (_playerCharacter.RightHand.transform.childCount > 0)
        {
            IThrowable iThrowable = _playerCharacter.RightHand.transform.GetChild(0).gameObject.GetComponent<IThrowable>();
            LaunchObject(iThrowable);
        }
        SetHandFree();
    }
    private void LaunchObject(IThrowable iThrowable)
    {
        _playerCharacter.rotation.RotateObjectToLaunch(iThrowable.Self.transform, mouseData.GetClickPosition().point);
        iThrowable.DetachFromPlayer(playerData.throwDistance, playerData.throwFlightTime);
    }
    private void SetHandFree()
    {
        if (playerData.selectedHand == PlayerData.SelectedHand.Left)
        {
            playerData.LeftHandOccupied = false;
            playerData.leftHandWeight = 0;
        }
        else
        {
            playerData.RightHandOccupied = false;
            playerData.rightHandWeight = 0;
        }
        Transitions();
    }
    #endregion

    #region Transitions
    private void Transitions()
    {
        if (playerInputs.MovementInput == Vector3.zero) ReturnToIdle();
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
