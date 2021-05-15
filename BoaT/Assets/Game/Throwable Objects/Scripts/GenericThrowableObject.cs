using UnityEngine;

public class GenericThrowableObject : MonoBehaviour, IThrowable
{
    public float Weight { get; set; }
    private Collider physicsCollider;
    private GameObject baseContainer;
    private Color baseColor;

    void Awake()
    {
        physicsCollider = this.gameObject.transform.GetChild(0).gameObject.GetComponent<Collider>();
        baseContainer = GameObject.FindGameObjectWithTag("GenericObjectsContainer");
        baseColor = this.gameObject.GetComponent<Renderer>().material.color;
    }

    void Start()
    {
        this.gameObject.transform.SetParent(baseContainer.transform);
    }

    public void AttachToPlayer(GameObject playerHand)
    {
        this.gameObject.GetComponent<Rigidbody>().useGravity = false;
        this.gameObject.transform.position = playerHand.transform.position;
        this.gameObject.transform.SetParent(playerHand.transform);
        physicsCollider.enabled = false;
    }
    public void DetachFromPlayer()
    {
        this.gameObject.transform.SetParent(baseContainer.transform);
        physicsCollider.enabled = true;
        this.gameObject.GetComponent<Rigidbody>().useGravity = true;
    }

    public void Highlighted(bool isHighlighted)
    {
        Material mat = this.gameObject.GetComponent<Renderer>().material;
        if (isHighlighted) mat.color = Color.red;
        else mat.color = baseColor;
    }
}
