using UnityEngine;

public class Animations : MonoBehaviour
{
    [HideInInspector] public bool waitForAnimation;
    [SerializeField] protected Animator playerAnimator;
    [HideInInspector] protected PlayerCharacter playerCharacter;
    [SerializeField] private string[] statesToExclude;
    private string actualState;

    public virtual void Awake()
    {
        playerCharacter = this.gameObject.GetComponent<PlayerCharacter>();
        StateMachine.stateChanged += UpdateAnimatorValues;
    }
    public virtual void Start()
    {
        SetupStateBool();
    }

    public virtual void UpdateAnimatorValues()
    {
        AnimatorStateUpdate();
    }

    public virtual void AnimatorStateUpdate()
    {
        if (actualState != playerCharacter.stateRef && NoStatesToIgnore())
        {
            if (!string.IsNullOrEmpty(actualState)) playerAnimator.SetBool(actualState, false);
            SetupStateBool();
        }
    }
    public virtual void SetupStateBool()
    {
        actualState = playerCharacter.stateRef;
        playerAnimator.SetBool(actualState, true);
    }
    public virtual void AnimationIsOver()
    {
        waitForAnimation = false;
    }
    private bool NoStatesToIgnore()
    {
        bool passed = true;
        for (int i = 0; i < statesToExclude.Length; i++)
        {
            if (playerCharacter.stateRef == statesToExclude[i])
            {
                passed = false;
                break;
            }
        }
        return passed;
    }
}
