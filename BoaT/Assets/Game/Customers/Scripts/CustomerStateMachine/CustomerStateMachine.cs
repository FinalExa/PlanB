using UnityEngine;
public class CustomerStateMachine : StateMachine
{
    [HideInInspector] public CustomerController customerController;

    private void Awake()
    {
        customerController = this.gameObject.GetComponent<CustomerController>();
        SetState(new CustomerGoToLocation(this));
    }
}
