using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [HideInInspector] public bool waitForAnimation;
    [SerializeField] private Animator playerAnimator;
    private PlayerCharacter playerCharacter;
    private string actualState;

    private void Awake()
    {
        playerCharacter = this.gameObject.GetComponent<PlayerCharacter>();
        PlayerAnimationsBehaviour.onAnimationEnd += AnimationIsOver;
    }
    private void Start()
    {
        SetupStateBool();
    }
    private void Update()
    {
        AnimatorStateUpdate();
    }

    private void AnimatorStateUpdate()
    {
        if (actualState != playerCharacter.stateRef && playerCharacter.stateRef != "Hands")
        {
            playerAnimator.SetBool(actualState, false);
            SetupStateBool();
        }
    }
    private void SetupStateBool()
    {
        actualState = playerCharacter.stateRef;
        playerAnimator.SetBool(actualState, true);
    }

    private void AnimationIsOver()
    {
        waitForAnimation = false;
    }
}
