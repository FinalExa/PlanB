using UnityEngine;
public class SoulIdle : SoulState
{
    public SoulIdle(SoulStateMachine soulStateMachine) : base(soulStateMachine)
    {
        Debug.Log(soulStateMachine.stateRef);
    }
    #region Transitions

    #endregion
}
