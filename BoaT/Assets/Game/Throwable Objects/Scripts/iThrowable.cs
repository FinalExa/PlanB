using UnityEngine;
public interface IThrowable
{
    float Weight { get; set; }
    GameObject Self { get; set; }
    bool isInsidePlayerRange { get; set; }
    void AttachToPlayer(GameObject playerHand);
    void DetachFromPlayer(float throwDistance, float flightTime, float stopValueThrow);

}
