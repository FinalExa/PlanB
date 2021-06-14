using System;
public class SoulIdle : SoulState
{
    public static Action<SoulController> soulIsIdle;
    public SoulIdle(SoulStateMachine soulStateMachine) : base(soulStateMachine)
    {
    }
    public override void Start()
    {
        soulIsIdle(_soulStateMachine.soulController);
        if (_soulStateMachine.soulController.thisNavMeshAgent.isOnNavMesh) _soulStateMachine.soulController.thisNavMeshAgent.isStopped = true;
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
        if (_soulStateMachine.soulController.soulReferences.soulThrowableObject.isAttachedToHand) _soulStateMachine.SetState(new SoulGrabbed(_soulStateMachine));
    }
    private void GoToEscapeThePlayer()
    {
        if (_soulStateMachine.soulController.playerIsInRange) _soulStateMachine.SetState(new SoulEscapePlayer(_soulStateMachine));
    }
    #endregion
}
