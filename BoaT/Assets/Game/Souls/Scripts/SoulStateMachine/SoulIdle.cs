﻿public class SoulIdle : SoulState
{
    public SoulIdle(SoulStateMachine soulStateMachine) : base(soulStateMachine)
    {
    }
    public override void Start()
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
    }
    private void GoToGrabbed()
    {
        if (_soulStateMachine.soulController.soulReferences.throwableObject.isAttachedToHand) _soulStateMachine.SetState(new SoulGrabbed(_soulStateMachine));
    }
    private void GoToEscapeThePlayer()
    {
        if (_soulStateMachine.soulController.playerIsInRange) _soulStateMachine.SetState(new SoulEscapePlayer(_soulStateMachine));
    }
    #endregion
}
