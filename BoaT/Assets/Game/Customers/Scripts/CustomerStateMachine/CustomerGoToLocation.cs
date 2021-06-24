public class CustomerGoToLocation : CustomerState
{
    public CustomerGoToLocation(CustomerStateMachine customerStateMachine) : base(customerStateMachine)
    {
    }

    public override void Start()
    {
        GoToWaitingForInteraction();
    }

    private void GoToWaitingForInteraction()
    {
        _customerStateMachine.SetState(new CustomerWaitingForInteraction(_customerStateMachine));
    }
}
