using UnityEngine;

public class CustomerController : MonoBehaviour, ICanBeInteracted
{
    [SerializeField] private GameObject[] customerModels;
    [SerializeField] private GameObject exitDoor;
    private GameObject seatToTake;
    private GameObject targetedLocation;
    [HideInInspector] public bool interactionReceived;
    [HideInInspector] public bool waitingForOrder;
    public GameObject Self { get; set; }
    private GameObject selectedModel;

    private void Awake()
    {
        Self = this.gameObject;
    }
    private void Start()
    {
        RandomizeModel();
    }
    private void Update()
    {
        if (interactionReceived) interactionReceived = false;
    }

    public void RandomizeModel()
    {
        int randIndex = Random.Range(0, customerModels.Length);
        selectedModel = customerModels[randIndex];
        selectedModel.SetActive(true);
    }

    public void Interaction()
    {
        interactionReceived = true;
    }
}
