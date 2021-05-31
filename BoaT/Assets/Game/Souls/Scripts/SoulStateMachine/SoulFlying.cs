public class SoulFlying : SoulState
{
    public SoulFlying(SoulStateMachine soulStateMachine) : base(soulStateMachine)
    {
    }
    public override void StateUpdate()
    {
        if (_soulStateMachine.soulController.soulReferences.throwableObject.isNotGrounded) Transitions();
    }
    #region Transitions
    private void Transitions()
    {
        GoToIdle();
        GoToEscapePub();
    }
    private void GoToIdle()
    {
        if (_soulStateMachine.soulController.isInsideStorageRoom) _soulStateMachine.SetState(new SoulIdle(_soulStateMachine));
    }
    private void GoToEscapePub()
    {
        if (!_soulStateMachine.soulController.isInsideStorageRoom) _soulStateMachine.SetState(new SoulEscapePub(_soulStateMachine));
    }
    #endregion
}
