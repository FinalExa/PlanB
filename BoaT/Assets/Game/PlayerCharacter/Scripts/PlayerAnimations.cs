using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    private PlayerCharacter playerCharacter;
    private string actualState;

    private void Awake()
    {
        playerCharacter = this.gameObject.GetComponent<PlayerCharacter>();
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
}
