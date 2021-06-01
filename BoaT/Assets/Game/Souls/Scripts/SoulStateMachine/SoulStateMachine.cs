﻿using UnityEngine;

public class SoulStateMachine : StateMachine
{
    [HideInInspector] public SoulController soulController;
    private void Awake()
    {
        soulController = this.gameObject.GetComponent<SoulController>();
        SetState(new SoulIdle(this));
    }

    public void StateNamePrint()
    {
        print(stateRef);
    }
}
