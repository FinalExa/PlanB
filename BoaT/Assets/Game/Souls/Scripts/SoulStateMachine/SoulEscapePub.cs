public class SoulEscapePub : SoulState
{
    public SoulEscapePub(SoulStateMachine soulStateMachine) : base(soulStateMachine)
    {
    }
    public override void StateUpdate()
    {
        Transitions();
    }
    #region Transitions
    private void Transitions()
    {
        GoToGrabbed();
    }
    private void GoToGrabbed()
    {
        if (_soulStateMachine.soulController.soulReferences.throwableObject.isAttachedToHand) _soulStateMachine.SetState(new SoulGrabbed(_soulStateMachine));
    }
    #endregion
}
