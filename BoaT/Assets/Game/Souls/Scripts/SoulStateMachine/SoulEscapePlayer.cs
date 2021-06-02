using UnityEngine;
public class SoulEscapePlayer : SoulState
{
    public SoulEscapePlayer(SoulStateMachine soulStateMachine) : base(soulStateMachine)
    {
    }
    public override void Start()
    {
        SetupEscape();
    }
    public override void StateUpdate()
    {
        EndEscape();
    }
    private void SetupEscape()
    {
        if (_soulStateMachine.soulController.playerIsInRange != null && _soulStateMachine.soulController.thisNavMeshAgent.enabled == true)
        {
            Vector3 playerPos = _soulStateMachine.soulController.playerIsInRange.transform.position;
            Vector3 soulPos = _soulStateMachine.soulController.gameObject.transform.position;
            Vector3 destination = new Vector3(soulPos.x + (soulPos.x - playerPos.x), soulPos.y, soulPos.z + (soulPos.z - playerPos.z));
            _soulStateMachine.soulController.thisNavMeshAgent.isStopped = false;
            _soulStateMachine.soulController.thisNavMeshAgent.SetDestination(destination);
        }
    }
    private void EndEscape()
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
        if (_soulStateMachine.soulController.playerIsInRange == null ||
            !_soulStateMachine.soulController.thisNavMeshAgent.isOnNavMesh)
        {
            _soulStateMachine.SetState(new SoulIdle(_soulStateMachine));
        }
    }
    private void GoToGrabbed()
    {
        if (_soulStateMachine.soulController.soulReferences.soulThrowableObject.isAttachedToHand)
        {
            _soulStateMachine.SetState(new SoulGrabbed(_soulStateMachine));
        }
    }
    #endregion
}
