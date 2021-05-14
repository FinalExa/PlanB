using UnityEngine;

public class GenericThrowableObject : MonoBehaviour, iThrowable
{
    public float Weight { get; set; }

    public void AttachToPlayer(GameObject playerHand)
    {
        this.gameObject.transform.position = playerHand.transform.position;
        this.gameObject.transform.SetParent(playerHand.transform);
    }
    public void GetThrown(GameObject playerHand)
    {

    }
}
