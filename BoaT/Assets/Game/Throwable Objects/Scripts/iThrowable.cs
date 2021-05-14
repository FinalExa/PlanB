using UnityEngine;
public interface iThrowable
{
    float Weight { get; set; }
    void AttachToPlayer(GameObject playerHand);
    void GetThrown(GameObject playerHand);
}
