public class CustomerGoToLocation : CustomerState
{
    private bool movingIssued;
    public CustomerGoToLocation(CustomerStateMachine customerStateMachine) : base(customerStateMachine)
    {
    }

    public override void Start()
    {
        movingIssued = false;
        _customerStateMachine.customerController.thisNavMeshAgent.enabled = true;
    }
    public override void StateUpdate()
    {
        if (_customerStateMachine.customerController.seatToTake != null && !movingIssued) MoveToTarget();
        if (_customerStateMachine.customerController.thisNavMeshAgent.isStopped && movingIssued) GoToWaitingForInteraction();
    }

    private void MoveToTarget()
    {
        if (!_customerStateMachine.customerController.leave) _customerStateMachine.customerController.ChooseSeat();
        _customerStateMachine.customerController.thisNavMeshAgent.SetDestination(_customerStateMachine.customerController.targetedLocation.transform.position);
        movingIssued = true;
    }

    private void GoToWaitingForInteraction()
    {
        _customerStateMachine.SetState(new CustomerWaitingForInteraction(_customerStateMachine));
    }
}
