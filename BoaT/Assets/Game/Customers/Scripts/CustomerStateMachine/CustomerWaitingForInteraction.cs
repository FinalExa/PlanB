public class CustomerWaitingForInteraction : CustomerState
{
    public CustomerWaitingForInteraction(CustomerStateMachine customerStateMachine) : base(customerStateMachine)
    {
    }

    public override void StateUpdate()
    {
        if (_customerStateMachine.customerController.interactionReceived) GenerateOrder();
    }

    private void GenerateOrder()
    {
        // behaviour
        GoToWaitingForOrder();
    }

    private void GoToWaitingForOrder()
    {
        _customerStateMachine.SetState(new CustomerWaitingForOrder(_customerStateMachine));
    }
}
