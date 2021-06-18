using UnityEngine;

public class PlayerRange : MonoBehaviour
{
    private PlayerController playerController;
    [SerializeField] private SphereCollider playerRange;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }
    private void Start()
    {
        playerRange.radius = playerController.playerReferences.playerData.grabRange;
    }

    private void OnTriggerEnter(Collider other)
    {
        ObjectIsInRange(other);
    }

    private void ObjectIsInRange(Collider other)
    {
        IThrowable otherObject = other.gameObject.GetComponent<IThrowable>();
        if (otherObject != null)
        {
            Collider otherCol = otherObject.Self.GetComponent<Collider>();
            if (!playerController.objectsInPlayerRange.Contains(otherCol))
            {
                otherObject.IsInsidePlayerRange = true;
                playerController.objectsInPlayerRange.Add(otherCol);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ObjectIsOutOfRange(other);
    }

    private void ObjectIsOutOfRange(Collider other)
    {
        IThrowable otherObject = other.gameObject.GetComponent<IThrowable>();
        if (otherObject != null && Vector2.Distance(new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.z), new Vector2(other.gameObject.transform.position.x, other.gameObject.transform.position.z)) > playerController.playerReferences.playerData.grabRange)
        {
            Collider otherCol = otherObject.Self.GetComponent<Collider>();
            if (playerController.objectsInPlayerRange.Contains(otherCol))
            {
                otherObject.IsInsidePlayerRange = false;
                playerController.objectsInPlayerRange.Remove(otherCol);
            }
        }
    }

}
