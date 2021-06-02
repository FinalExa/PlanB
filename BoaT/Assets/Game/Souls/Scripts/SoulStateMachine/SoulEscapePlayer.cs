using UnityEngine;
using UnityEngine.AI;
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
        if (CheckForEscapedPlayer()) EndEscape();
    }
    private void SetupEscape()
    {
        if (_soulStateMachine.soulController.playerIsInRange != null)
        {
            Vector3 playerPos = _soulStateMachine.soulController.playerIsInRange.transform.position;
            Vector3 soulPos = _soulStateMachine.soulController.gameObject.transform.position;
            Vector3 destination = new Vector3(soulPos.x + (soulPos.x - playerPos.x), soulPos.y, soulPos.z + (soulPos.z - playerPos.z));
            NavMeshSetDestination(destination);
        }
    }
    private void NavMeshSetDestination(Vector3 destination)
    {
        if (_soulStateMachine.soulController.thisNavMeshAgent.enabled == true)
        {
            NavMeshAgent agent = _soulStateMachine.soulController.thisNavMeshAgent;
            agent.isStopped = false;
            agent.SetDestination(destination);
        }
    }
    private bool CheckForEscapedPlayer()
    {
        bool status = false;
        NavMeshAgent agent = _soulStateMachine.soulController.thisNavMeshAgent;
        if (agent.pathStatus == NavMeshPathStatus.PathComplete || _soulStateMachine.soulController.playerIsInRange == null) status = true;
        return status;
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
        if (!_soulStateMachine.soulController.playerIsInRange || !_soulStateMachine.soulController.thisNavMeshAgent.isOnNavMesh) _soulStateMachine.SetState(new SoulIdle(_soulStateMachine));
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
