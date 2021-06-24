public class CustomerWaitingForOrder : CustomerState
{
    public CustomerWaitingForOrder(CustomerStateMachine customerStateMachine) : base(customerStateMachine)
    {
    }

    public override void Start()
    {
        GoToGoToLocation();
    }

    private void GoToGoToLocation()
    {
        _customerStateMachine.SetState(new CustomerGoToLocation(_customerStateMachine));
    }
}
