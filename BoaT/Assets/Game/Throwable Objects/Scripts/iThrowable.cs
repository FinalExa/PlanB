using UnityEngine;
public interface IThrowable
{
    float Weight { get; set; }
    GameObject Self { get; set; }
    void AttachToPlayer(GameObject playerHand);
    void DetachFromPlayer();
    void LaunchSelf(float launchSpeed);
    void Highlighted(bool isHighlighted);
}
