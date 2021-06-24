using UnityEngine;
public class CustomerStateMachine : StateMachine
{
    [HideInInspector] public CustomerController customerController;

    private void Awake()
    {
        customerController = this.gameObject.GetComponent<CustomerController>();
    }

    private void OnEnable()
    {
        customerController.targetedLocation = customerController.seatToTake;
        SetState(new CustomerGoToLocation(this));
    }
}
