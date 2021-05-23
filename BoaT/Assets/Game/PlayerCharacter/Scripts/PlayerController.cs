using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [HideInInspector] public PlayerReferences playerReferences;
    public List<Collider> objectsInPlayerRange;
    public GameObject LeftHand;
    public GameObject RightHand;
    public bool LeftHandOccupied { get; set; }
    public bool RightHandOccupied { get; set; }
    [HideInInspector] public float leftHandWeight;
    [HideInInspector] public float rightHandWeight;
    [HideInInspector] public Collider objectClicked;
    [SerializeField] private SphereCollider thisTrigger;
    public enum SelectedHand
    {
        Left,
        Right
    }
    [HideInInspector] public SelectedHand selectedHand;

    private void Awake()
    {
        playerReferences = this.gameObject.GetComponent<PlayerReferences>();
        thisTrigger = this.gameObject.GetComponent<SphereCollider>();
    }
    private void Start()
    {
        thisTrigger.radius = playerReferences.playerData.grabRange;
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
            if (!objectsInPlayerRange.Contains(otherCol))
            {
                otherObject.IsInsidePlayerRange = true;
                objectsInPlayerRange.Add(otherCol);
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
        if (otherObject != null && Vector2.Distance(new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.z), new Vector2(other.gameObject.transform.position.x, other.gameObject.transform.position.z)) > playerReferences.playerData.grabRange)
        {
            Collider otherCol = otherObject.Self.GetComponent<Collider>();
            if (objectsInPlayerRange.Contains(otherCol))
            {
                otherObject.IsInsidePlayerRange = false;
                objectsInPlayerRange.Remove(otherCol);
            }
        }
    }
}
