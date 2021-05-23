using UnityEngine;
public abstract class StateMachine : MonoBehaviour
{
    protected PlayerState _state;
    [HideInInspector] public string stateRef;

    public void SetState(PlayerState state)
    {
        _state = state;
        stateRef = _state.ToString();
        state.Start();
    }
}
