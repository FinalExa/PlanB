﻿using UnityEngine;
using UnityEngine.AI;
public class SoulEscapePub : SoulState
{
    public SoulEscapePub(SoulStateMachine soulStateMachine) : base(soulStateMachine)
    {
    }
    public override void Start()
    {
        SetupEscapePub();
    }
    private void SetupEscapePub()
    {
        NavMeshAgent agent = _soulStateMachine.soulController.thisNavMeshAgent;
        Vector3 exitPos = _soulStateMachine.soulController.exit.transform.position;
        agent.SetDestination(exitPos);
    }
    public override void StateUpdate()
    {
        Transitions();
    }
    #region Transitions
    private void Transitions()
    {
        GoToGrabbed();
    }
    private void GoToGrabbed()
    {
        if (_soulStateMachine.soulController.soulReferences.soulThrowableObject.isAttachedToHand) _soulStateMachine.SetState(new SoulGrabbed(_soulStateMachine));
    }
    #endregion
}
