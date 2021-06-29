public class CustomerWaitingForOrder : CustomerState
{
    public CustomerWaitingForOrder(CustomerStateMachine customerStateMachine) : base(customerStateMachine)
    {
    }

    public override void Start()
    {
        _customerStateMachine.customerController.customerReferences.customerVignette.SetupVignette(_customerStateMachine.customerController.chosenType, _customerStateMachine.customerController.chosenIngredients);
        StartSetup();
        //GoToGoToLocation();
    }

    private void StartSetup()
    {
        _customerStateMachine.customerController.targetedLocation = _customerStateMachine.customerController.exitDoor;
        _customerStateMachine.customerController.thisTable.TableClear(_customerStateMachine.customerController.thisTableId);
        _customerStateMachine.customerController.leave = true;
    }

    private void GoToGoToLocation()
    {
        _customerStateMachine.SetState(new CustomerGoToLocation(_customerStateMachine));
    }
}
