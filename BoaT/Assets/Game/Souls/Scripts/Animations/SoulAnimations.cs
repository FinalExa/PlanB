public class SoulAnimations : Animations
{
    private SoulStateMachine soulStateMachine;

    public override void Awake()
    {
        base.Awake();
        soulStateMachine = (SoulStateMachine)stateMachineToRead;
    }
    public override void OnEnable()
    {
        animator = soulStateMachine.soulController.soulTypes[soulStateMachine.soulController.thisSoulTypeIndex].soulAnimator;
        base.OnEnable();
    }
}
