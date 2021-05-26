using System;
using UnityEngine;
public abstract class StateMachine : MonoBehaviour
{
    protected PlayerState _state;
    [HideInInspector] public string stateRef;
    public static Action stateChanged;

    public void SetState(PlayerState state)
    {
        _state = state;
        stateChanged();
        state.Start();
    }
}
