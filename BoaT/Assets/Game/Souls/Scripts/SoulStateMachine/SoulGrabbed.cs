﻿using UnityEngine;
public class SoulGrabbed : SoulState
{
    public SoulGrabbed(SoulStateMachine soulStateMachine) : base(soulStateMachine)
    {
        _soulStateMachine.soulController.thisNavMeshAgent.isStopped = true;
        _soulStateMachine.soulController.thisNavMeshAgent.enabled = false;
    }
    public override void Start()
    {
        _soulStateMachine.soulController.gameObject.transform.localPosition = Vector3.zero;
    }
    public override void StateUpdate()
    {
        Transitions();
    }
    #region Transitions
    private void Transitions()
    {
        GoToFlying();
    }
    private void GoToFlying()
    {
        if (_soulStateMachine.soulController.soulReferences.soulThrowableObject.isFlying) _soulStateMachine.SetState(new SoulFlying(_soulStateMachine));
    }
    #endregion
}
