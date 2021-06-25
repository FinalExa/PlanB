using UnityEngine;
using UnityEngine.AI;

public class CustomerController : MonoBehaviour, ICanBeInteracted
{
    [SerializeField] private GameObject[] customerModels;
    [HideInInspector] public GameObject exitDoor;
    [HideInInspector] public GameObject seatToTake;
    [HideInInspector] public GameObject targetedLocation;
    [HideInInspector] public bool interactionReceived;
    [HideInInspector] public bool waitingForOrder;
    public NavMeshAgent thisNavMeshAgent;
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
    public void ChooseSeat()
    {
        Table[] tablesList = FindObjectsOfType<Table>();
        int randIndex = Random.Range(0, tablesList.Length);
        SeatInfo[] seatInfos = tablesList[randIndex].seatInfo;
        for (int i = 0; i < seatInfos.Length; i++)
        {
            if (!seatInfos[i].seatIsOccupied)
            {
                seatToTake = tablesList[randIndex].seatInfo[i].seatTarget;
                tablesList[randIndex].seatInfo[i].seatIsOccupied = true;
                tablesList[randIndex].seatInfo[i].customer = this;
                targetedLocation = seatToTake;
                break;
            }
        }
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
