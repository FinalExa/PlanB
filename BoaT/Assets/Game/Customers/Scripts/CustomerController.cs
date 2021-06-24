using UnityEngine;

public class CustomerController : MonoBehaviour, ICanBeInteracted
{
    [SerializeField] private GameObject[] customerModels;
    [HideInInspector] public GameObject exitDoor;
    [HideInInspector] public GameObject seatToTake;
    [HideInInspector] public GameObject targetedLocation;
    [HideInInspector] public bool interactionReceived;
    [HideInInspector] public bool waitingForOrder;
    public GameObject Self { get; set; }
    private GameObject selectedModel;

    private void Awake()
    {
        Self = this.gameObject;
        exitDoor = GameObject.FindGameObjectWithTag("Exit");
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
