using UnityEngine;
public class Grab : PlayerState
{
    public Grab(PlayerCharacter playerCharacter) : base(playerCharacter)
    {
        playerCharacter.playerController.playerReferences.rotation.rotationEnabled = false;
    }

    public override void Start()
    {
        CheckHand();
    }

    #region Grab
    private void CheckHand()
    {
        PlayerController.SelectedHand selectedHand = _playerCharacter.playerController.selectedHand;
        if (selectedHand == PlayerController.SelectedHand.Left) SetHandOccupied(selectedHand);
        else if (selectedHand == PlayerController.SelectedHand.Right) SetHandOccupied(selectedHand);
    }
    private void SetHandOccupied(PlayerController.SelectedHand selectedHand)
    {

        IThrowable iThrowable = _playerCharacter.playerController.playerReferences.objectsOnMouse.PassThrowableObject().GetComponent<IThrowable>();
        if (selectedHand == PlayerController.SelectedHand.Left) LeftHand(iThrowable);
        else RightHand(iThrowable);
        Transitions();
    }
    private void LeftHand(IThrowable iThrowable)
    {
        iThrowable.AttachToPlayer(_playerCharacter.playerController.LeftHand);
        _playerCharacter.playerController.LeftHandOccupied = true;
        _playerCharacter.playerController.leftHandWeight = iThrowable.Weight;
    }
    private void RightHand(IThrowable iThrowable)
    {
        iThrowable.AttachToPlayer(_playerCharacter.playerController.RightHand);
        _playerCharacter.playerController.RightHandOccupied = true;
        _playerCharacter.playerController.rightHandWeight = iThrowable.Weight;
    }
    #endregion

    #region Transitions
    private void Transitions()
    {
        PlayerInputs playerInputs = _playerCharacter.playerController.playerReferences.playerInputs;
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
