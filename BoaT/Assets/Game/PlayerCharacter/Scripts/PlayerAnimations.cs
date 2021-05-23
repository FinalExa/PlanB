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
        HandsChecks();
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
    private void HandsChecks()
    {
        PlayerController playerController = playerCharacter.playerController;
        ActiveHand(playerController);
        HandsStatus(playerController);
    }

    private void ActiveHand(PlayerController playerController)
    {
        if (playerController.selectedHand == PlayerController.SelectedHand.Left && !playerAnimator.GetBool("LeftHandSelected"))
        {
            playerAnimator.SetBool("RightHandSelected", false);
            playerAnimator.SetBool("LeftHandSelected", true);
        }
        else if (playerController.selectedHand == PlayerController.SelectedHand.Right && !playerAnimator.GetBool("RightHandSelected"))
        {
            playerAnimator.SetBool("LeftHandSelected", false);
            playerAnimator.SetBool("RightHandSelected", true);
        }
    }
    private void HandsStatus(PlayerController playerController)
    {
        if (!playerController.LeftHandOccupied && !playerController.RightHandOccupied && !playerAnimator.GetBool("HandsFree"))
        {
            playerAnimator.SetBool("LeftFreeRightOccupied", false);
            playerAnimator.SetBool("LeftOccupiedRightFree", false);
            playerAnimator.SetBool("HandsOccupied", false);
            playerAnimator.SetBool("HandsFree", true);
        }
        else if (!playerController.LeftHandOccupied && playerController.RightHandOccupied && !playerAnimator.GetBool("LeftFreeRightOccupied"))
        {
            playerAnimator.SetBool("HandsFree", false);
            playerAnimator.SetBool("LeftOccupiedRightFree", false);
            playerAnimator.SetBool("HandsOccupied", false);
            playerAnimator.SetBool("LeftFreeRightOccupied", true);
        }
        else if (playerController.LeftHandOccupied && !playerController.RightHandOccupied && !playerAnimator.GetBool("LeftOccupiedRightFree"))
        {
            playerAnimator.SetBool("HandsFree", false);
            playerAnimator.SetBool("LeftFreeRightOccupied", false);
            playerAnimator.SetBool("HandsOccupied", false);
            playerAnimator.SetBool("LeftOccupiedRightFree", true);
        }
        else if (playerController.LeftHandOccupied && playerController.RightHandOccupied && !playerAnimator.GetBool("HandsOccupied"))
        {
            playerAnimator.SetBool("HandsFree", false);
            playerAnimator.SetBool("LeftFreeRightOccupied", false);
            playerAnimator.SetBool("LeftOccupiedRightFree", false);
            playerAnimator.SetBool("HandsOccupied", true);
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
