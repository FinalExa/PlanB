public class CustomerGoToLocation : CustomerState
{
    public CustomerGoToLocation(CustomerStateMachine customerStateMachine) : base(customerStateMachine)
    {
    }

    public override void Start()
    {
        _customerStateMachine.customerController.thisNavMeshAgent.enabled = true;
        MoveToTarget();
    }
    public override void StateUpdate()
    {
        if (_customerStateMachine.customerController.thisNavMeshAgent.destination == _customerStateMachine.gameObject.transform.position) GoToWaitingForInteraction();
    }

    private void MoveToTarget()
    {
        if (!_customerStateMachine.customerController.leave) _customerStateMachine.customerController.ChooseSeat();
        _customerStateMachine.customerController.thisNavMeshAgent.SetDestination(_customerStateMachine.customerController.targetedLocation.transform.position);
    }

    private void GoToWaitingForInteraction()
    {
        _customerStateMachine.SetState(new CustomerWaitingForInteraction(_customerStateMachine));
    }
}
