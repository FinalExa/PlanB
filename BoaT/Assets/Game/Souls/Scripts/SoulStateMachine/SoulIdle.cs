public class SoulIdle : SoulState
{
    public SoulIdle(SoulStateMachine soulStateMachine) : base(soulStateMachine)
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
        GoToEscapeThePlayer();
        GoToEscapeThePub();
    }
    private void GoToGrabbed()
    {
        if (_soulStateMachine.soulController.soulReferences.throwableObject.isAttachedToHand) _soulStateMachine.SetState(new SoulGrabbed(_soulStateMachine));
    }
    private void GoToEscapeThePlayer()
    {

    }
    private void GoToEscapeThePub()
    {

    }
    #endregion
}
