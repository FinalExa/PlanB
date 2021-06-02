﻿using UnityEngine;
using UnityEngine.AI;
public class SoulFlying : SoulState
{
    public SoulFlying(SoulStateMachine soulStateMachine) : base(soulStateMachine)
    {
    }
    public override void StateUpdate()
    {
        if (!_soulStateMachine.soulController.soulReferences.soulThrowableObject.isNotGrounded) StopFlight();
    }
    private void StopFlight()
    {
        _soulStateMachine.soulController.thisRigidbody.velocity = Vector3.zero;
        _soulStateMachine.soulController.thisRigidbody.angularVelocity = Vector3.zero;
        NavMeshAgent thisNavMeshAgent = _soulStateMachine.soulController.thisNavMeshAgent;
        thisNavMeshAgent.enabled = true;
        Transitions();
    }
    #region Transitions
    private void Transitions()
    {
        GoToIdle();
        GoToEscapePub();
    }
    private void GoToIdle()
    {
        if (_soulStateMachine.soulController.isInsideStorageRoom || !_soulStateMachine.soulController.thisNavMeshAgent.isOnNavMesh) _soulStateMachine.SetState(new SoulIdle(_soulStateMachine));
    }
    private void GoToEscapePub()
    {
        if (!_soulStateMachine.soulController.isInsideStorageRoom) _soulStateMachine.SetState(new SoulEscapePub(_soulStateMachine));
    }
    #endregion
}
