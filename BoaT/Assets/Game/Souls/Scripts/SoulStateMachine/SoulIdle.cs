using UnityEngine;
using UnityEngine.AI;
public class SoulIdle : SoulState
{
    public SoulIdle(SoulStateMachine soulStateMachine) : base(soulStateMachine)
    {
    }
    public override void Start()
    {
        NavMeshAgent thisNavMeshAgent = _soulStateMachine.soulController.thisNavMeshAgent;
        thisNavMeshAgent.enabled = true;
        thisNavMeshAgent.velocity = Vector3.zero;
        _soulStateMachine.soulController.thisRigidbody.velocity = Vector3.zero;
        thisNavMeshAgent.isStopped = true;
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
