using UnityEngine;
using UnityEngine.AI;
public class SoulEscapePlayer : SoulState
{
    public SoulEscapePlayer(SoulStateMachine soulStateMachine) : base(soulStateMachine)
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
        GoToIdle();
        GoToGrabbed();
    }
    private void GoToIdle()
    {
        if (!_soulStateMachine.soulController.playerIsInRange) _soulStateMachine.SetState(new SoulIdle(_soulStateMachine));
    }
    private void GoToGrabbed()
    {
        if (_soulStateMachine.soulController.soulReferences.throwableObject.isAttachedToHand) _soulStateMachine.SetState(new SoulGrabbed(_soulStateMachine));
    }
    #endregion
}
