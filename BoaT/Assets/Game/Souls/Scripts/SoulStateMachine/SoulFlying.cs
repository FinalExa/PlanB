public class SoulFlying : SoulState
{
    public SoulFlying(SoulStateMachine soulStateMachine) : base(soulStateMachine)
    {
    }
    public override void StateUpdate()
    {
        Transitions();
    }
    #region Transitions
    private void Transitions()
    {
        GoToIdle();
    }
    private void GoToIdle()
    {
        if (!_soulStateMachine.soulController.soulReferences.throwableObject.isFlying) _soulStateMachine.SetState(new SoulIdle(_soulStateMachine));
    }
    #endregion
}
