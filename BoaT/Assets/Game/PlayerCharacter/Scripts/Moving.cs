public class Moving : PlayerState
{
    private Rotation rotation;
    private PlayerData playerData;
    private PlayerInputs playerInputs;
    private UnityEngine.Rigidbody playerRB;
    private UnityEngine.Camera mainCamera;
    public Moving(PlayerCharacter playerCharacter) : base(playerCharacter)
    {
        rotation = playerCharacter.rotation;
        playerData = playerCharacter.playerData;
        playerInputs = playerCharacter.playerInputs;
        playerRB = _playerCharacter.GetComponent<UnityEngine.Rigidbody>();
        mainCamera = UnityEngine.GameObject.FindObjectOfType<UnityEngine.Camera>();
        rotation.rotationEnabled = true;
    }
    public override void Start()
    {
        UpdateSpeedValue();
    }
    public override void StateUpdate()
    {
        Movement();
        Transitions();
    }

    #region Movement
    private void UpdateSpeedValue()
    {
        playerData.actualSpeed = playerData.movementSpeed - (playerData.leftHandWeight + playerData.rightHandWeight);
        if (playerData.actualSpeed < playerData.minSpeedValue) playerData.actualSpeed = playerData.minSpeedValue;
    }
    private void Movement()
    {
        UnityEngine.Vector3 movementWithDirection = MovementInitialization();
        playerRB.velocity = new UnityEngine.Vector3(movementWithDirection.x, movementWithDirection.y, movementWithDirection.z) * playerData.actualSpeed;
    }

    private UnityEngine.Vector3 MovementInitialization()
    {
        UnityEngine.Vector3 forward = mainCamera.transform.forward;
        forward.y = 0f;
        UnityEngine.Vector3 right = mainCamera.transform.right;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();
        return (playerInputs.MovementInput.x * forward) + (playerInputs.MovementInput.z * right);
    }
    #endregion

    #region Transitions
    private void Transitions()
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
        if (playerInputs.DashInput && !_playerCharacter.playerData.LeftHandOccupied && !_playerCharacter.playerData.RightHandOccupied) _playerCharacter.SetState(new Dash(_playerCharacter));
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
