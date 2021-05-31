using UnityEngine;
using UnityEngine.AI;
public class SoulEscapePub : SoulState
{
    public SoulEscapePub(SoulStateMachine soulStateMachine) : base(soulStateMachine)
    {
    }
    public override void Start()
    {
        _soulStateMachine.soulController.thisNavMeshAgent.enabled = true;
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
    }
    private void GoToGrabbed()
    {
        if (_soulStateMachine.soulController.soulReferences.throwableObject.isAttachedToHand) _soulStateMachine.SetState(new SoulGrabbed(_soulStateMachine));
    }
    #endregion
}
