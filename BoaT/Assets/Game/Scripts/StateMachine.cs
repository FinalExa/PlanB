using System;
using UnityEngine;
public abstract class StateMachine : MonoBehaviour
{
    protected State _state;
    [HideInInspector] public string stateRef;
    public static Action stateChanged;

    public void SetState(State state)
    {
        _state = state;
        stateChanged();
        state.Start();
    }
    private void Start()
    {
        _state.Start();
    }
    private void Update()
    {
        _state.StateUpdate();
    }
}
