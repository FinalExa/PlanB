using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    protected State _state;

    public void SetState(State state)
    {
        _state = state;
        state.Start();
    }
}
