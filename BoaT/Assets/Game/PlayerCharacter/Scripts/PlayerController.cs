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
        //FIX THIS ASAP
        IThrowable otherObject = other.gameObject.GetComponent<IThrowable>();
        if (otherObject != null)
        {
            otherObject.IsInsidePlayerRange = true;
            Collider otherCol = otherObject.Self.GetComponent<Collider>();
            if (!objectsInPlayerRange.Contains(otherCol)) objectsInPlayerRange.Add(otherCol);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        IThrowable otherObject = other.gameObject.GetComponent<IThrowable>();
        if (otherObject != null)
        {
            otherObject.IsInsidePlayerRange = false;
            objectsInPlayerRange.Remove(otherObject.Self.GetComponent<Collider>());
        }
    }
}
