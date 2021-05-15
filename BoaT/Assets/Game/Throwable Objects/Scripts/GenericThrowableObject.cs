using UnityEngine;

public class GenericThrowableObject : MonoBehaviour, iThrowable
{
    public float Weight { get; set; }
    private Collider physicsCollider;

    void Awake()
    {
        physicsCollider = this.gameObject.transform.GetChild(0).gameObject.GetComponent<Collider>();
    }

    public void AttachToPlayer(GameObject playerHand)
    {
        this.gameObject.transform.position = playerHand.transform.position;
        this.gameObject.transform.SetParent(playerHand.transform);
        physicsCollider.enabled = false;
    }
    public void GetThrown(GameObject playerHand)
    {

    }
}
