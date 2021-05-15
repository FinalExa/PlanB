using UnityEngine;
public abstract class StateMachine : MonoBehaviour
{
    protected PlayerState _state;

    public void SetState(PlayerState state)
    {
        _state = state;
        state.Start();
    }
}
