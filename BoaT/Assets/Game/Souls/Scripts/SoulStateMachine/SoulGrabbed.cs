public class SoulGrabbed : SoulState
{
    public SoulGrabbed(SoulStateMachine soulStateMachine) : base(soulStateMachine)
    {
    }
    public override void StateUpdate()
    {
        Transitions();
    }
    #region Transitions
    private void Transitions()
    {
        GoToFlying();
    }
    private void GoToFlying()
    {
        if (_soulStateMachine.soulController.soulReferences.throwableObject.isFlying) _soulStateMachine.SetState(new SoulFlying(_soulStateMachine));
    }
    #endregion
}
