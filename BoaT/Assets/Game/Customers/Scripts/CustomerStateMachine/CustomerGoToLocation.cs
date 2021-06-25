using UnityEngine.AI;
public class CustomerGoToLocation : CustomerState
{
    public CustomerGoToLocation(CustomerStateMachine customerStateMachine) : base(customerStateMachine)
    {
    }

    public override void Start()
    {
        MoveToTarget();
        GoToWaitingForInteraction();
    }
    public override void StateUpdate()
    {
        if (_customerStateMachine.customerController.thisNavMeshAgent.pathStatus == NavMeshPathStatus.PathComplete) GoToWaitingForInteraction();
    }

    private void MoveToTarget()
    {
        if (_customerStateMachine.customerController.targetedLocation == null) _customerStateMachine.customerController.ChooseSeat();
        _customerStateMachine.customerController.thisNavMeshAgent.SetDestination(_customerStateMachine.customerController.targetedLocation.transform.position);
    }

    private void GoToWaitingForInteraction()
    {
        _customerStateMachine.SetState(new CustomerWaitingForInteraction(_customerStateMachine));
    }
}
