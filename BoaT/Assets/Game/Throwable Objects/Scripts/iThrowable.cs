using UnityEngine;
public interface IThrowable
{
    float Weight { get; set; }
    void AttachToPlayer(GameObject playerHand);
    void DetachFromPlayer();

    void Highlighted(bool isHighlighted);
}
