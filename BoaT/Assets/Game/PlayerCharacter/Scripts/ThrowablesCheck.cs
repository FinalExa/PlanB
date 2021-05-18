using UnityEngine;

public class ThrowablesCheck : MonoBehaviour
{
    private PlayerCharacter playerCharacter;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private SphereCollider thisCollider;
    private void Awake()
    {
        playerCharacter = FindObjectOfType<PlayerCharacter>();
        thisCollider = this.gameObject.GetComponent<SphereCollider>();
    }

    private void Start()
    {
        thisCollider.radius = playerData.grabRange;
    }
    private void OnTriggerEnter(Collider other)
    {
        IThrowable otherObject = other.gameObject.GetComponent<IThrowable>();
        if (otherObject != null)
        {
            otherObject.isInsidePlayerRange = true;
            playerCharacter.objectsInPlayerRange.Add(otherObject.Self.GetComponent<Collider>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        IThrowable otherObject = other.gameObject.GetComponent<IThrowable>();
        if (otherObject != null)
        {
            otherObject.isInsidePlayerRange = false;
            playerCharacter.objectsInPlayerRange.Remove(otherObject.Self.GetComponent<Collider>());
        }
    }
}
