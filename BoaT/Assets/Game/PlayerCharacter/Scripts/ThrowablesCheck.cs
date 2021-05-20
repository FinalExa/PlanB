using UnityEngine;

public class ThrowablesCheck : MonoBehaviour
{
    private PlayerCharacter playerCharacter;
    [HideInInspector] public PlayerData playerData;
    [SerializeField] private SphereCollider thisCollider;
    private void Awake()
    {
        playerCharacter = FindObjectOfType<PlayerCharacter>();
    }

    private void OnValidate()
    {
        thisCollider.radius = playerData.grabRange;
    }

    private void OnTriggerEnter(Collider other)
    {
        //FIX THIS ASAP
        IThrowable otherObject = other.gameObject.GetComponent<IThrowable>();
        if (otherObject != null)
        {
            otherObject.IsInsidePlayerRange = true;
            Collider otherCol = otherObject.Self.GetComponent<Collider>();
            if (!playerCharacter.objectsInPlayerRange.Contains(otherCol)) playerCharacter.objectsInPlayerRange.Add(otherCol);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        IThrowable otherObject = other.gameObject.GetComponent<IThrowable>();
        if (otherObject != null)
        {
            otherObject.IsInsidePlayerRange = false;
            playerCharacter.objectsInPlayerRange.Remove(otherObject.Self.GetComponent<Collider>());
        }
    }
}
