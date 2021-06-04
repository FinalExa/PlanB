public class SoulAnimations : Animations
{
    private SoulStateMachine soulStateMachine;

    public override void Awake()
    {
        base.Awake();
        soulStateMachine = this.gameObject.GetComponent<SoulStateMachine>();
    }

    private void OnEnable()
    {
        animator = soulStateMachine.soulController.soulTypes[soulStateMachine.soulController.thisSoulTypeIndex].soulAnimator;
    }

    private void Update()
    {
        UpdateAnimatorValues();
    }
}
